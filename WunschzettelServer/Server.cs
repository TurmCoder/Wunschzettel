using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using Service2;

namespace Wunschzettel
{
    public class Server: IServer
    {
        private readonly IDatabaseAccessLayer database;

        public Server(IDatabaseAccessLayer database)
        {
            this.database = database;
        }

        public void AddWish(Wish wish)
        {
            this.database.AddWish(wish);
        }

        public void AddWishes(IEnumerable<Wish> wishes)
        {
            this.database.AddWishes(wishes);
        }

        public Wish GetWish(int id)
        {
            return this.database.GetWish(id);
        }

        public IEnumerable<Wish> GetWishes(int personId)
        {
            return this.database.GetWishes(personId);
        }

        public Person GetPerson(int personId)
        {
            return this.database.GetPerson(personId);
        }

        public void SavePerson(Person person)
        {
            this.database.SavePerson(person);
        }

        public void Run()
        {
            this.HostService();
        }

        private void HostService()
        {
            var host = this.GetHost();

            host.Open();
            Console.WriteLine("Service is up and running");
            Console.WriteLine("Press enter to quit ");
            Console.ReadLine();
            host.Close();
        }

        private WebServiceHost GetHost()
        {
            var host = new WebServiceHost(typeof (WunschzettelService2));

            return host;
        }
    }
}