using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProjectAlbert.Model;

namespace WpfProjectAlbert.ViewModel
{
    class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            KoppelenCommands();
        }
        private String message;
        public String Message
        {
            get {
                return message;
            }

            set {
                message = value;
                NotifyPropertyChanged();
            }
        }

        private Gebruiker nieuweGebruiker;

        public Gebruiker NieuweGebruiker
        {
            get {
                if (nieuweGebruiker == null)
                {
                    nieuweGebruiker = new Gebruiker();
                    nieuweGebruiker.Geboortedatum = DateTime.Now.Date;
                }
                return nieuweGebruiker;

            }
            set {
                nieuweGebruiker = value;
                NotifyPropertyChanged();
              
            }
        }

        private void KoppelenCommands()
        {

            InschrijvenCommand = new BaseCommand(Inschrijven);
        }
        public ICommand InschrijvenCommand { get; set; }

        public void Inschrijven()
        {

            GebruikerDataService gebruikerDS = new GebruikerDataService();
            if (NieuweGebruiker.Gebruikersnaam != null)
            {
                if (gebruikerDS.GetGebruiker(NieuweGebruiker.Gebruikersnaam).Gebruikersnaam == null)
                {
                    gebruikerDS.Inschrijven(NieuweGebruiker);
                    PageNavigationService pageNavigationService = new PageNavigationService();
                    pageNavigationService.Navigate("Login");
                }
                else
                {
                    Message= "Gebruikersnaam is al in gebruik!";
                }
               
            }

        }
    }

}
