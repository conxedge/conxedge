using System;
using System.Windows.Forms;
using ConXEdge.Server;

namespace ConXEdge.Test
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMain : Form
    {
        ServiceControl serviceControl = new ServiceControl();

        public frmMain()
        {
            InitializeComponent();
            btnStopService.Enabled = false;
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            serviceControl.Start();
            btnStartService.Enabled = false;
            btnStopService.Enabled = true;
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            serviceControl.Stop();
            btnStartService.Enabled = true;
            btnStopService.Enabled = false;
        }
    }
}
