using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Wunschzettel.Core;

namespace Wunschzettel
{
    public class ClientServiceConsumer : IClientServiceConsumer
    {
        private readonly WunschzettelSerializer serializer;
        private WebClient client;

        public ClientServiceConsumer(WunschzettelSerializer serializer)
        {
            this.serializer = serializer;
            this.InitializeClient();
        }

        public bool Login()
        {
            var result = this.client.DownloadString("Login");

            return result.Contains("LoggedIn");
        }

        public Person GetPerson(int i)
        {
            var methodString = String.Format("GetPerson?personId={0}", i);

            var response = this.client.DownloadString(methodString);

            var person = this.serializer.Deserialize<Person>(response);

            return person;
        }

        

        private void InitializeClient()
        {
            this.client = new WebClient();

            this.client.BaseAddress = "http://localhost:8000/service/";
            this.client.Headers["Content-type"] = "application/json";
        }
    }
}