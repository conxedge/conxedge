using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using M = ConXedge.Model;
using B = ConXEdge.BLL;

namespace ConXEdge.WebSite.Module.Projects
{
    public partial class ContactAdd : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.ContactInfoBLL bll = new B.ContactInfoBLL();
            M.ContactInfo model = new M.ContactInfo();
            model.Contactid = Guid.NewGuid().ToString();
            model.Contact = Contact.Text;
            model.Email = Email.Text;
            model.Companyid = base.CurrentUserInfo.Companyid;
             
            M.Message msg = bll.Add(model);
            if (msg.State == M.MessageState.Success)
            {
                ResponseScript("alert('Save Success!');window.close();");
            }
            else
            {
                ResponseScript(string.Format("alert('Save Failure:{0}');",msg.Msg));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResponseScript("window.location.href='ContactList.aspx';");
        }

    }
}