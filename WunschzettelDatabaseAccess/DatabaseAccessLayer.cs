using System.Collections.Generic;
using NHibernate;
using Wunschzettel.Core;

namespace Wunschzettel
{
    public class DatabaseAccessLayer: IDatabaseAccessLayer
    {
        private ISession session;
        private readonly ISessionFactoryBuilder sessionFactoryBuilder;

        public bool SessionIsOpen
        {
            get { return this.session.IsOpen; }
        }

        public ITransaction Transaction
        {
            get { return this.session.Transaction; }
        }

        public User Login(string user, string pass)
        {
            throw new System.NotImplementedException();
        }

        public DatabaseAccessLayer(ISessionFactoryBuilder sessionFactoryBuilder)
        {
            this.sessionFactoryBuilder = sessionFactoryBuilder;
        }

        public void Initalize(Schema schema)
        {
            var factory = this.sessionFactoryBuilder.CreateSessionFactory(schema);

            this.session = factory.OpenSession();
        }

        public void AddWish(Wish wish)
        {
            throw new System.NotImplementedException();
        }

        public void AddWishes(IEnumerable<Wish> wishes)
        {
            throw new System.NotImplementedException();
        }

        public Wish GetWish(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Wish> GetWishes(int personId)
        {
            throw new System.NotImplementedException();
        }

        public Person GetPerson(int personId)
        {
            return this.session.Get<Person>(personId);
        }

        public void SavePerson(Person person)
        {
            this.session.Save(person);
        }
    }
}
