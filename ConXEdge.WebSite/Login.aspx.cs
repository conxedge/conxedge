using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using M = ConXedge.Model;
using BLL = ConXEdge.BLL;
using Hzjg.Common.Utility;
using System.Text;

namespace ConXEdge.WebSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.Theme = "Default";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("CurrentUser");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BLL.UserInfoBLL bll = new BLL.UserInfoBLL();
            string pwd = Crypt.MD5_EnCrypt(txtPwd.Text);
            M.UserInfo user = bll.UserLogin(txtUserName.Text, pwd);
            if (user != null)
            {
                Session.Remove("CurrentUser");
                Session.Add("CurrentUser", user);
                ResponseScript("window.parent.location='/Default.aspx'");
            }
            else
            {
                MessageBox.Show(this.Page, "Login failure!");
            }
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
    }
}