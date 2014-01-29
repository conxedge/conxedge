using System;
using System.Globalization;
using B = ConXEdge.BLL;
using M = ConXedge.Model;

namespace ConXEdge.WebSite.Module.Projects
{
    public partial class PourEdit : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["pid"]))
            {
                B.PourInfoBLL bll = new B.PourInfoBLL();
                M.PourInfo model = bll.GetModelByID(Request["pid"]);
                this.hfpid.Value = model.Pourid;
                this.Name.Text = model.PourName;
                this.hdProject.Value = model.Projectid;
                this.hdProduct.Value = model.Productid;
                this.txtCreateDate.Value = model.CreateDate.ToString("dd/MM/yyyy");
                this.hdMaturityMethod.Value = model.MaturityMethod;
                this.Started.Value = model.Started.ToString("dd/MM/yyyy HH:mm:ss");
                this.Finished.Value = model.Finished.ToString("dd/MM/yyyy HH:mm:ss");
                this.Volume.Text = model.PourVolume.ToString();
                this.SetupBy.Text = model.SetupBy;
                this.hdContact.Value = model.Contactid;
                this.hdStopType.Value = model.StopType;
                this.XHours.Text = model.Xhours.ToString();
                this.hdPourType.Value = model.PourType.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.PourInfoBLL bll = new B.PourInfoBLL();
            M.PourInfo model = bll.GetModelByID(hfpid.Value);
            IFormatProvider culture = new CultureInfo("en-AU", true);
            model.CreateDate = DateTime.Parse(this.txtCreateDate.Value, culture);
            model.Finished = DateTime.Parse(this.Finished.Value, culture);
            model.MaturityMethod = this.hdMaturityMethod.Value;
            model.PourName = this.Name.Text;
            model.PourVolume = int.Parse(this.Volume.Text);
            model.Productid = hdProduct.Value;
            model.Projectid = hdProject.Value;
            model.SetupBy = this.SetupBy.Text;
            model.Started = DateTime.Parse(this.Started.Value, culture);
            model.Contactid = hdContact.Value;
            model.StopType = hdStopType.Value;
            model.PourType = hdPourType.Value;
            if (model.StopType == "3" || model.StopType == "4")
            {
                model.Xhours = int.Parse(XHours.Text);
            }
             
            M.Message msg = bll.Update(model);
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
            ResponseScript(" window.close();");
        }

    }
}