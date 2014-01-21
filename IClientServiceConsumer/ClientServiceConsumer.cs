using System.Net;

namespace Wunschzettel
{
    public class ClientServiceConsumer : IClientServiceConsumer
    {
        private WebClient client;

        public ClientServiceConsumer()
        {
            this.InitializeClient();
        }

        public bool Login()
        {
            var result = this.client.DownloadString("Login");

            return result.Contains("LoggedIn");
        }

        private void InitializeClient()
        {
            this.client = new WebClient();

            this.client.BaseAddress = "http://localhost:8000/service/";
            
        }
    }
}