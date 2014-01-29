using System.ServiceProcess;
using ConXEdge.Server;

namespace ConXEdge.Service
{
    public partial class Service : ServiceBase
    {
        ServiceControl serviceControl = new ServiceControl();

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            serviceControl.Start();
        }

        protected override void OnStop()
        {
            serviceControl.Stop();
        }
    }
}
