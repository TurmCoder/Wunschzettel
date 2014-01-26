using System.Collections.Generic;
using System.ComponentModel;

namespace Wunschzettel.Core
{
    public class Person:BaseEntity
    {
        public virtual string Vorname { get; set; }

        public virtual string Nachname { get; set; }

        public virtual bool IsAdmin { get; protected internal set; }

        public virtual IList<Wish> Wishlist { get; protected internal set; }

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