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
    class SettingsViewModel:BaseViewModel
    {
        private Gebruiker actieveGebruiker;

        public Gebruiker ActieveGebruiker
        {
            get {

                return actieveGebruiker;

            }
            set {
                actieveGebruiker = value;
                NotifyPropertyChanged();

            }
        }
        public SettingsViewModel()
        {
            KoppelenCommands();
            //luisteren naar updates
            Messenger.Default.Register<Gebruiker>(this, OnMessageReceived);

        }
        private void OnMessageReceived(Gebruiker message)
        {
            //update 
            ActieveGebruiker = message;
        }

        private void KoppelenCommands()
        {

            ToHomeCommand = new BaseCommand(toHomePage);
            DeleteAccountCommand = new BaseCommand(DeleteAccount);
            EditAccountCommand = new BaseCommand(EditAccount);
        }
        public ICommand ToHomeCommand { get; set; }
        public ICommand DeleteAccountCommand { get; set; }
        public ICommand EditAccountCommand { get; set; }

        public void toHomePage()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Welcome");


        }
        public void DeleteAccount()
        {

            GebruikerDataService gebruikerDS = new GebruikerDataService();
            ActieveGebruiker.Gebruikersnaam = null;

            gebruikerDS.VerwijderGebruiker(ActieveGebruiker);
             
            Messenger.Default.Send<string>("pinLeegmaken");
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Login");


        }  public void EditAccount()
        {

            GebruikerDataService gebruikerDS = new GebruikerDataService();
            gebruikerDS.WijzigGebruiker(ActieveGebruiker);
             
            Messenger.Default.Send<Gebruiker>(ActieveGebruiker);
            toHomePage();


        }
    }
}
