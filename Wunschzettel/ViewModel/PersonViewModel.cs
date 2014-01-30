using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Wunschzettel.Core;

namespace Wunschzettel.ViewModel
{
    public class PersonViewModel : ViewModelBase 
    {
        private string vorname;
        private string nachname;

        public PersonViewModel(Person person)
        {
            this.Vorname = person.Vorname;
            this.Nachname = person.Nachname;
            this.Wishlist = person.Wishlist;
            this.IsAdmin = person.IsAdmin;
        }

        public bool IsAdmin { get; private set; }

        public IList<Wish> Wishlist { get; private set; }

        public string Nachname
        {
            get
            {
                return this.nachname;
            }
            set
            {
                if (this.nachname != value)
                {
                    this.RaisePropertyChanged(() => this.Nachname);
                    this.nachname = value;
                }
            }
        }

        public string Vorname
        {
            get
            {
                return this.vorname;
            }
            set
            {
                if (this.vorname != value)
                {   
                    this.RaisePropertyChanged(() => this.Vorname);
                    this.vorname = value;
                }
            }
        }
    }
}
