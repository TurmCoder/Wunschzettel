using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Wunschzettel;

namespace Service2
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "Service1" sowohl im Code als auch in der SVC- und der Konfigurationsdatei ändern.
    // HINWEIS: Wählen Sie zum Starten des WCF-Testclients zum Testen dieses Diensts Service1.svc oder Service1.svc.cs im Projektmappen-Explorer aus, und starten Sie das Debuggen.
    public class WunschzettelService2 : IWunschzettelService2
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string Login()
        {
            throw new NotImplementedException();
        }

        public void AddWish(Wish wish)
        {
            throw new NotImplementedException();
        }

        public void AddWishes(IEnumerable<Wish> wishes)
        {
            throw new NotImplementedException();
        }

        public Wish GetWish(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Wish> GetWishes(int personId)
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(int personId)
        {
            throw new NotImplementedException();
        }

        public void SavePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
