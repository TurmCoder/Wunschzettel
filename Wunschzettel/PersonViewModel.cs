using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Wunschzettel.Annotations;
using Wunschzettel.Core;

namespace Wunschzettel
{
    public class PersonViewModel : INotifyPropertyChanged 
    {
        private string vorname;
        private string nachname;
        public event PropertyChangedEventHandler PropertyChanged;

        public PersonViewModel(Person person)
        {
            this.Vorname = person.Vorname;
            this.Nachname = person.Nachname;
            this.Wishlist = person.Wishlist;
            this.IsAdmin = person.IsAdmin;
        }

        protected bool IsAdmin { get; private set; }

        protected IList<Wish> Wishlist { get; private set; }

        protected string Nachname
        {
            get
            {
                return this.nachname;
            }
            set
            {
                if (this.nachname != value)
                {
                    this.OnPropertyChanged(() => Nachname);
                    this.nachname = value;
                }
            }
        }

        protected string Vorname
        {
            get
            {
                return this.vorname;
            }
            set
            {
                if (this.vorname != value)
                {   
                    this.OnPropertyChanged(() => Vorname);
                    this.vorname = value;
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged(Func<string> func)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(func.Target.ToString()));
            }    
        }
    }
}
