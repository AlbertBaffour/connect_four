using MoreCoffee.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProjectAlbert.Model;

namespace WpfProjectAlbert.ViewModel
{
    class LoginViewModel:BaseViewModel
    {
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
        private Login loginGegevens;

        public Login LoginGegevens
        {
            get {
                if (loginGegevens == null)
                {
                    loginGegevens = new Login();
                }
                return loginGegevens;

            }
            set {
                loginGegevens = value;
                NotifyPropertyChanged();
            }

        }
        public LoginViewModel()
        {
            KoppelenCommands();
            //luisteren naar updates 
            Messenger.Default.Register<string>(this, OnMessageReceived);
        }
        private void OnMessageReceived(string message)
        {
            //pin leegmaken
            if (message == "pinLeegmaken")
            {
                LoginGegevens.Pin = "";
            }
        }
       

        private void KoppelenCommands()
        {

            InloggenCommand = new BaseCommand(Inloggen);
        }
        public ICommand InloggenCommand { get; set; }

        public void Inloggen()
        {
            
                GebruikerDataService gebruikerDS = new GebruikerDataService();
                Gebruiker gebruikerFromDB = gebruikerDS.GetGebruiker(LoginGegevens.Gebruikersnaam);
                if (gebruikerFromDB.Gebruikersnaam != null)
                {
                    if (gebruikerFromDB.Pin == LoginGegevens.Pin)
                    {
                    Message = "";
                    Messenger.Default.Send<Gebruiker>(gebruikerFromDB);
                    PageNavigationService pageNavigationService = new PageNavigationService();
                        pageNavigationService.Navigate("Welcome");
                    }
                else
                {
                    Message = "Aanmelding mislukt!";
                }
            }
            else
            {
                Message = "Aanmelding mislukt!";
            }

        }

    }
}
