using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.UI;
using ConXedge.Model;

namespace ConXEdge.WebSite.AppCode
{
    public class PageBase : Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.Theme = "Default";
        }
        protected override void OnInit(EventArgs e)
        {
            LoadJs();
            base.OnInit(e);
            //进行用户登陆验证（单点登陆）
            if (CurrentUserInfo == null)
            {
                //ResponseScript("window.parent.location='/Login.aspx'");
                this.Page.Response.Redirect("/Login.aspx", true);
                this.Page.Response.End();                
            }
        }

        /// <summary>
        /// 获取当前用户
        /// </summary>
        public UserInfo CurrentUserInfo
        {
            get
            {
                if (Session["CurrentUser"] == null)
                {
                    return null;
                }
                return Session["CurrentUser"] as UserInfo;
            }
        }

        /// <summary>
        /// 加载JS
        /// </summary>
        private void LoadJs()
        {
            //LinkJs(this, "~/JavaScript/jquery-1.7.1.min.js");
            //表格隔行换色和鼠标移动事件 
            //LinkJs(this, "~/JavaScript/SetStyle.js");
        }

        /// <summary>
        /// 弹出提示消息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="strMessage"></param>
        protected void ShowMessage(string strMessage)
        {
            StringBuilder _strScript = new StringBuilder();
            _strScript.Append(@"<script type='text/javascript' defer>");
            _strScript.Append("alert('" + strMessage + "');");
            _strScript.Append(@"</script>");
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", _strScript.ToString());
        }
        /// <summary>
        /// 输出脚本（页头）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="strScript"></param>
        protected void ResponseScript(string strScript)
        {
            StringBuilder _strScript = new StringBuilder();
            _strScript.Append(@"<script type='text/javascript' defer>");
            _strScript.Append(strScript);
            _strScript.Append(@"</script>");
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", _strScript.ToString());
        }
        /// <summary>
        /// 正常加载Js
        /// </summary>
        /// <param name="pPage">要加载的页面</param>
        /// <param name="sJsUrl">js的url</param>
        public void LinkJs(Page pPage, string sJsUrl)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl hgcLoadJs = new System.Web.UI.HtmlControls.HtmlGenericControl();
            hgcLoadJs.TagName = "script";
            hgcLoadJs.Attributes.Add("type", "text/javascript");
            hgcLoadJs.Attributes.Add("src", Page.ResolveClientUrl(sJsUrl)); //ResolveClientUrl:获取浏览器可以使用的 URL
            Page.Header.Controls.Add(hgcLoadJs);

        }
        /// <summary>
        /// 正常加载CSS
        /// </summary>
        /// <param name="pPage">要加载的页面</param>
        /// <param name="sStyleLink">样式url</param>
        public void LinkStyle(Page pPage, string sStyleLink)
        {
            System.Web.UI.HtmlControls.HtmlLink hlLink = new System.Web.UI.HtmlControls.HtmlLink();
            hlLink.Attributes.Add("rel", "stylesheet");
            hlLink.Attributes.Add("type", "text/css");
            hlLink.Attributes.Add("href", sStyleLink);
            Page.Header.Controls.Add(hlLink);

        }
        /// <summary>
        /// 获取参数名称
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public string GetParam(string idx)
        {
            string sResult = string.Empty;
            if (Request.RequestType.ToLower() == "post")
            {
                sResult = Request.Form[idx];
            }
            else if (Request.RequestType.ToLower() == "get")
            {
                sResult = Request.QueryString[idx];
            }
            return sResult;
        }
    }
}