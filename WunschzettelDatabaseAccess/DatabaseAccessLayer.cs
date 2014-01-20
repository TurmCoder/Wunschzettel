using System.Collections.Generic;

namespace Wunschzettel
{
    public class DatabaseAccessLayer: IDatabaseAccessLayer
    {
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
            throw new System.NotImplementedException();
        }

        public void SavePerson(Person person)
        {
            throw new System.NotImplementedException();
        }
    }
}
