using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectAlbert.Model
{
    class Login :BaseModel
    {
        private string gebruikersnaam;
        private string pin;
       

        public Login()
        {
        }

        public Login(string gebruikersnaam, string pin)
        {

            Gebruikersnaam = gebruikersnaam;
            Pin = pin;
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
    }
}
