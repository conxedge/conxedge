using System;
using System.Globalization;
using B = ConXEdge.BLL;
using M = ConXedge.Model;

namespace ConXEdge.WebSite.Module.Projects
{
    public partial class PourAdd : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.PourInfoBLL bll = new B.PourInfoBLL();
            M.PourInfo model = new M.PourInfo();
            model.Pourid = Guid.NewGuid().ToString();
            IFormatProvider culture = new CultureInfo("en-AU", true);
            model.CreateDate = DateTime.Parse(this.txtCreateDate.Value, culture);
            model.Finished = DateTime.Parse(this.Finished.Value, culture);
            model.MaturityMethod = this.hdMaturityMethod.Value;
            model.PourName = this.Name.Text;
            model.PourVolume = int.Parse(this.Volume.Text);
            model.Productid = hdProduct.Value;
            model.Projectid = hdProject.Value;
            model.Contactid = hdContact.Value;
            model.StopType = hdStopType.Value;
            model.PourType = hdPourType.Value;
            if (model.StopType == "3" || model.StopType == "4")
            {
                model.Xhours = int.Parse(XHours.Text);
            }
            model.SetupBy = this.SetupBy.Text;
            model.Started = DateTime.Parse(this.Started.Value, culture);
            model.Status = "0";
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
            ResponseScript("window.location.href='PourList.aspx';");
        }

    }
}