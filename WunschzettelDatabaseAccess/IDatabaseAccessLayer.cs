using System.Collections.Generic;
using NHibernate;
using Wunschzettel.Core;

namespace Wunschzettel
{
    public interface IDatabaseAccessLayer
    {
        void Initalize(Schema schema);
        void AddWish(Wish wish);
        void AddWishes(IEnumerable<Wish> wishes);
        Wish GetWish(int id);
        IEnumerable<Wish> GetWishes(int personId);
        Person GetPerson(int personId);
        void SavePerson(Person person);
        ITransaction Transaction { get; }
    }
}