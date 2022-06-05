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
    class WelcomeViewModel:BaseViewModel
    {
        private Gebruiker actieveGebruiker;

        public Gebruiker ActieveGebruiker
        {
            get {
                
                return actieveGebruiker;

            }
            set {
                actieveGebruiker =value;
                NotifyPropertyChanged();

            }
        }
        private int gewonnen;
        private int verloren;
        public int Gewonnen
        {
            get {

                return gewonnen;

            }
            set {
                gewonnen = value;
                NotifyPropertyChanged();

            }
        } 
        public int Verloren
        {
            get {

                return verloren;

            }
            set {
                verloren = value;
                NotifyPropertyChanged();

            }
        }
        public WelcomeViewModel()
        {
            KoppelenCommands();
            //luisteren naar updates
            Messenger.Default.Register<Gebruiker>(this, OnMessageReceived);

        }
        private void OnMessageReceived(Gebruiker message)
        {
            //update 
            ActieveGebruiker = message;
            FillHistory();
        }

        private void KoppelenCommands()
        {

            UitloggenCommand = new BaseCommand(Uitloggen);
            InstructionsCommand = new BaseCommand(ToInstructions);
            SettingsCommand = new BaseCommand(ToSettings);
            PlayCommand = new BaseCommand(ToGame);
        }
        public ICommand UitloggenCommand { get; set; }
        public ICommand InstructionsCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand PlayCommand { get; set; }

        public void Uitloggen()
        {
            Messenger.Default.Send<string>("pinLeegmaken");
            PageNavigationService pageNavigationService = new PageNavigationService();
                    pageNavigationService.Navigate("Login");
         
        }  public void ToInstructions()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
                    pageNavigationService.Navigate("Instructions");
         {
            
            }
        }
        public void ToSettings()
        {
            Messenger.Default.Send<Gebruiker>(ActieveGebruiker);
            PageNavigationService pageNavigationService = new PageNavigationService();
                    pageNavigationService.Navigate("Settings");
         
        }
        public void ToGame()
        {
            Messenger.Default.Send<Gebruiker>(ActieveGebruiker);
            PageNavigationService pageNavigationService = new PageNavigationService();
                    pageNavigationService.Navigate("Game");
         
        }
        public void FillHistory() {

            SpelDataService spelDS = new SpelDataService();
            int[] result = spelDS.GetWins(actieveGebruiker.Id);
            Gewonnen = result[0];
            Verloren = result[1];

        }
    }
}
