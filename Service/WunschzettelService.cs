using System.Collections.Generic;
using StructureMap;
using Wunschzettel.Core;

namespace Wunschzettel
{
    public class WunschzettelService : IWunschzettelService
    {
        private readonly IDatabaseAccessLayer database;

        public WunschzettelService(IDatabaseAccessLayer database)
        {
            this.database = database;
        }

        public User Login(LoginData data)
        {
            return this.database.Login(data.Username, data.Password);
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
    }
}