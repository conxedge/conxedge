using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace ConXEdge.Common.PagerBar
{
    /// <summary>
    /// 自定义分页控件
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:PagerBar runat=server></{0}:PagerBar>")]
    public class PagerBar : WebControl
    {
        private int _current_page = 1;
        private string _url = "";
        private int _recordcount = 0;
        private int _pagesize = 15;
        private string _other_query_string;
        private string _page_arg_name;
        private string _exceptKeys = "";
        private static Regex RegNumber = new Regex("^[0-9]+$");

        /// <summary>
        /// 构造函数
        /// </summary>
        public PagerBar()
        {
            this.CurrentPage = 1;
            this.URL = "";
            this.PageArgName = "page";
            this.OtherQueryString = "";

            this.Init += new EventHandler(PageIndex_Init);
        }

        #region 控件初始化执行事件
        private void PageIndex_Init(object sender, EventArgs e)
        {
            //初始化当前面
            this.CurrentPage = 1;

            string value = "";

            HttpRequest request = HttpContext.Current.Request;
            //request.
            //this.URL = Path.GetFileName(request.Path);

            this.URL = request.RawUrl;
            int queryStart = this.URL.IndexOf('?');
            if (queryStart > -1)
            {
                this.URL = this.URL.Substring(0, this.URL.IndexOf('?'));
            }
            //this.URL = request.RawUrl.Substring(0,;

            string[] keys = request.QueryString.AllKeys;
            string[] exceptKeys = ExceptionString.Split(',');

            foreach (string key in keys)
            {
                value = request[key];
                value = value.Replace("'", "").Replace("<", "").Replace(">", "");
                if (key.ToLower() == this.PageArgName.ToLower())
                {
                    if (!IsNumber(value))
                    {
                        this.CurrentPage = 1;//如果输入的页面不是整数，则将它设置为第一页
                    }
                    else
                    {
                        int curPage = 1;

                        try
                        {
                            curPage = int.Parse(value);
                        }
                        catch
                        {
                            curPage = 1;
                        }
                        this.CurrentPage = curPage;
                    }
                }
                else
                {
                    bool except = false;
                    foreach (string k in exceptKeys)
                    {
                        if (k == key)
                        {
                            except = true;
                            break;
                        }
                    }
                    if (!except)
                    {
                        this.OtherQueryString += "&" + key + "=" + HttpUtility.UrlEncode(value);
                    }
                }
            }
        }
        #endregion

        #region 控件属性
        /// <summary>
        /// 是否数字字符串 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 例外的参数名
        /// </summary>
        public string ExceptionString
        {
            get
            {
                return _exceptKeys;
            }
            set
            {
                _exceptKeys = value;
            }
        }

        /// <summary>
        /// 分面参数名称
        /// </summary>
        public string PageArgName
        {
            get
            {
                return _page_arg_name;
            }
            set
            {
                _page_arg_name = value;
            }
        }

        /// <summary>
        /// 控件自定义ID
        /// </summary>
        private string PagerID
        {
            get
            {
                return this.ID + "_pager";
            }
        }

        /// <summary>
        /// 查询参数
        /// </summary>
        private string OtherQueryString
        {
            get
            {
                return _other_query_string;
            }
            set
            {
                _other_query_string = value;
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount
        {
            get
            {
                return _recordcount;
            }
            set
            {
                _recordcount = value;
            }
        }

        /// <summary>
        /// 页尺寸
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pagesize;
            }
            set
            {
                _pagesize = value;
            }
        }

        /// <summary>
        /// 地址
        /// </summary>
        private string URL
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        /// <summary>
        /// 页码
        /// </summary>
        public int CurrentPage
        {
            get
            {
                return _current_page;
            }
            set
            {
                _current_page = value;
            }
        }
        #endregion

        /// <summary>
        /// 重写输出
        /// </summary>
        /// <param name="output"></param>
        protected override void RenderContents(HtmlTextWriter output)
        {
            string _returnValue;
            //string _filter = @"^[1-9]\d*$";
            int _pageCount = 0;
            int _tempTopPage = 0, _tempEndPage = 0;
            string _url = this.URL;//绝对路径;

            //计算页数
            if (this.RecordCount % this.PageSize == 0)
            {
                _pageCount = this.RecordCount / this.PageSize;
            }
            else
            {
                _pageCount = Convert.ToInt32(this.RecordCount / this.PageSize) + 1;
            }

            if (this.CurrentPage > _pageCount)
                this.CurrentPage = _pageCount;

            if (this.OtherQueryString != "" && this.OtherQueryString.Substring(0, 1) != "&")
                this.OtherQueryString = "&" + this.OtherQueryString;
            //判断网址是否存在条件
            _url += "?";

            //组合字符串
            if (this.RecordCount <= 0)
            {
                _returnValue = "<div class='pagenav'><span>RecordCount：0，&nbsp;CurrentPage：0/0，&nbsp;PageSize：" + this.PageSize.ToString() + "</span>";
                _returnValue += "<a class='pagenumb' href='#'><<<</a>";
                _returnValue += "<a class='pagenumb' href='#'>1</a>";
                _returnValue += "<a class='pagenumb' href='#'>......</a>";
                _returnValue += "<a class='pagenumb' href='#'>1</a>";
                _returnValue += "<a class='pagenumb' href='#'>>>></a>";
            }
            else
            {
                //提示
                _returnValue = "<div class='pagenav'><span>RecordCount：" + this.RecordCount.ToString() + "，&nbsp;CurrentPage：" + this.CurrentPage.ToString() + "/" + _pageCount.ToString() + "，&nbsp;PageSize：" + this.PageSize.ToString() + "&nbsp;</span>";
                //第一页
                _returnValue += "<a class='pagenumb' title='FirstPage' href='";
                _returnValue += _url + this.PageArgName + "=1" + this.OtherQueryString;
                _returnValue += "'><<<</a>";


                if (_pageCount <= 5)
                {
                    _tempTopPage = 1;
                    _tempEndPage = _pageCount;
                }
                else
                {
                    if (this.CurrentPage - 2 >= 1)
                        _tempTopPage = this.CurrentPage - 2;
                    else
                        _tempTopPage = 1;

                    if (this.CurrentPage + 5 > _pageCount)
                    {
                        _tempEndPage = _pageCount;
                        _tempTopPage = _pageCount - 5;
                    }
                    else
                    {
                        _tempEndPage = _tempTopPage + 5;
                    }
                }

                //自动跳转项
                string _strSelectControl = "<select onchange='javascript:location.href=this.value;'>";

                for (int _showPage = _tempTopPage; _showPage <= _tempEndPage; _showPage++)
                {
                    if (_showPage.Equals(this.CurrentPage))
                    {
                        //当前页
                        _returnValue += "<a class='pagenumb_now'>" + _showPage.ToString() + "</a>";
                        _strSelectControl += "<option selected='selected' value='" + _url + this.PageArgName + "=" + _showPage.ToString() + this.OtherQueryString + "'>" + _showPage.ToString() + "</option>";
                    }
                    else
                    {
                        //可变页
                        _returnValue += "<a class='pagenumb' title='" + _showPage.ToString() + "' href='";
                        _returnValue += _url + this.PageArgName + "=" + _showPage.ToString() + this.OtherQueryString;
                        _returnValue += "'>" + _showPage.ToString() + "</a>";

                        _strSelectControl += "<option value='" + _url + this.PageArgName + "=" + _showPage.ToString() + this.OtherQueryString + "'>" + _showPage.ToString() + "</option>";
                    }
                }

                _strSelectControl += "</select>";

                //省略号,下一页
                if (this.CurrentPage >= _pageCount)
                    _returnValue += "<a class='pagenumb' title='Last Page' href='#'>......</a>";
                else
                {
                    _returnValue += "<a class='pagenumb' title='Next Page（" + Convert.ToString(this.CurrentPage + 1) + "）' href='";
                    _returnValue += _url + this.PageArgName + "=" + Convert.ToString(this.CurrentPage + 1) + this.OtherQueryString;
                    _returnValue += "'>......</a>";
                }
                //最后页
                _returnValue += "<a class='pagenumb' title='Last Page' href='";
                _returnValue += _url + this.PageArgName + "=" + _pageCount.ToString() + this.OtherQueryString;
                _returnValue += "'>>>></a>";

                _returnValue += "&nbsp;&nbsp;" + _strSelectControl + "</div>";
            }
            output.Write(_returnValue);
        }
    }
}
