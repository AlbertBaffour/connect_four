using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectAlbert.Model
{
    class Gebruiker : BaseModel
    {

        private int id;
        private string roepnaam;
        private string gebruikersnaam;
        private string pin;
        private DateTime geboortedatum;


        public Gebruiker()
        {
        }

        public Gebruiker(int id, string roepnaam, string gebruikersnaam, string pin, DateTime geboortedatum)
        {
            Id = id;
            Roepnaam = roepnaam;
            Gebruikersnaam = gebruikersnaam;
            Pin = pin;
            Geboortedatum = geboortedatum;
        }

        public int Id
        {
            get { return id; }
            set {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public string Roepnaam
        {
            get { return roepnaam; }
            set {
                roepnaam = value;
                NotifyPropertyChanged();
            }
        }

        public string Gebruikersnaam
        {
            get { return gebruikersnaam; }
            set {
                gebruikersnaam = value;
                NotifyPropertyChanged();
            }
        }

        public string Pin
        {
            get { return pin; }
            set {
                pin = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime Geboortedatum
        {
            get { return geboortedatum; }
            set {
                geboortedatum = value;
                NotifyPropertyChanged();
            }
        }
    }
}
