using System.Collections.Generic;

namespace Wunschzettel
{
    public class Person
    {
        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public bool IsAdmin { get; private set; }

        public IEnumerable<Wish> Wishlist { get; private set; }

        public Person()
        {
            this.Wishlist = new List<Wish>();
        }

        public Person(bool isAdmin): this()
        {
            this.IsAdmin = isAdmin;
        }
    }
}