using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using Wunschzettel.Core;

namespace Wunschzettel
{
    public class Server: IServer, IDisposable
    {
        private readonly IDatabaseAccessLayer database;
        private WebServiceHost host;

        public Server(IDatabaseAccessLayer database)
        {
            this.database = database;
        }

        public bool HostIsUp
        {
            get { return this.host.State == CommunicationState.Opened; }
        }

        public void Run()
        {
            this.database.Initalize(Schema.Keep);

            this.HostService();
        }

        private void HostService()
        {
            this.InitializeHost();

            this.host.Open();

            Console.WriteLine("Server is running.\r\nPress key to close.");
            Console.Read();
        }

        private void InitializeHost()
        {
            this.host = new WebServiceHost(typeof(WunschzettelService), new Uri("http://localhost:8000"));
            this.host.AddServiceEndpoint(typeof(IWunschzettelService), new WebHttpBinding(), "service");

            this.host.Description.Behaviors.Add(new WunschzettelServiceBehavior(() => new WunschzettelService(this.database)));

            var debugBehavior = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            debugBehavior.HttpHelpPageEnabled = true;
        }

        public void ShutDown()
        {
            this.host.Close();
        }

        public void Dispose()
        {
            this.ShutDown();
        }
    }
}