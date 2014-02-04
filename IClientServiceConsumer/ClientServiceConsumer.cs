using System;
using System.Net;
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

        public User Login(LoginData data)
        {
            var serializedData = this.serializer.Serialize<LoginData>(data);

            var dataStream = Encoding.UTF8.GetBytes(serializedData);

            var responeStream = this.client.UploadData("Login", dataStream);

            var respone = Encoding.UTF8.GetString(responeStream);

            var user = this.serializer.Deserialize<User>(respone);

            return user;
        }

        public Person GetPerson(int i)
        {
            var methodString = String.Format("GetPerson?personId={0}", i);

            var response = this.client.DownloadString(methodString);

            var person = this.serializer.Deserialize<Person>(response);

            //var person = new Person()
            //    {
            //        Id = 1,
            //        Nachname = "Knutson",
            //        Vorname = "Knut"
            //    };

            return person;
        }

        private void InitializeClient()
        {
            this.client = new WebClient
                {
                    BaseAddress = "http://localhost:8000/service/"
                };

            this.client.Headers["Content-type"] = "application/json";
        }
    }
}