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
    public partial class ProductAdd : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.ProductInfoBLL bll = new B.ProductInfoBLL();
            M.ProductInfo model = new M.ProductInfo();
            model.Productid = Guid.NewGuid().ToString();
            model.Code = Code.Text;
            model.Supplier = Supplier.Text;
            model.Description = Description.Text;
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
            ResponseScript("window.location.href='ProductList.aspx';");
        }

    }
}