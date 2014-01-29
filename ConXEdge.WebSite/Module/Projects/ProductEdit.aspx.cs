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
    public partial class ProductEdit : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            B.ProductInfoBLL bll = new B.ProductInfoBLL();
            if (!string.IsNullOrEmpty(Request["pid"]))
            {
                M.ProductInfo m = bll.GetModelByID(Request["pid"]);
                this.hfpid.Value = m.Productid;
                this.Code.Text = m.Code;
                this.Supplier.Text = m.Supplier;
                this.Description.Text = m.Description;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.ProductInfoBLL bll = new B.ProductInfoBLL();
            M.ProductInfo model = bll.GetModelByID(this.hfpid.Value);
            model.Code = Code.Text;
            model.Supplier = Supplier.Text;
            model.Description = Description.Text;
             
            M.Message msg = bll.Update(model);
            if (msg.State == M.MessageState.Success)
            {
                ResponseScript("alert('Edit Success!');window.close();");
            }
            else
            {
                ResponseScript(string.Format("alert('Edit Failure:{0}');", msg.Msg));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResponseScript("window.location.href='ProductList.aspx';");
        }

    }
}