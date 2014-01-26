using System.Collections.Generic;
using Wunschzettel.Core;

namespace Wunschzettel
{
    public class WunschzettelService : IWunschzettelService
    {
        private readonly IDatabaseAccessLayer database;

        public WunschzettelService()
        {
        }

        public WunschzettelService(IDatabaseAccessLayer database)
        {
            this.database = database;
        }

        public string Login()
        {
            return "LoggedIn";
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