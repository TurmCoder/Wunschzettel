using System.Collections.Generic;

namespace Wunschzettel
{
    public interface IDatabaseAccessLayer
    {
        void AddWish(Wish wish);
        void AddWishes(IEnumerable<Wish> wishes);
        Wish GetWish(int id);
        IEnumerable<Wish> GetWishes(int personId);
        Person GetPerson(int personId);
        void SavePerson(Person person);
    }
}