using Utility;
using Wunschzettel.Core;

namespace Wunschzettel.Tests
{
    public class DatabaseData
    {
        public static Person Person
        {
            get 
            { 
                var person = new Person(false)
                {
                    Vorname = "Vorname",
                    Nachname = "Nachname",
                };

                var wish = new Wish {Name = "Pony"};

                person.Wishlist.Add(wish);

                return person;
            }
        }
        public static User User
        {
            get 
            { 
                var user = new User("Login", Hasher.GetSha512("Login"));

                return user;
            }
        }

    }
}