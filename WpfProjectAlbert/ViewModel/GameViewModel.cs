using MoreCoffee.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProjectAlbert.Model;

namespace WpfProjectAlbert.ViewModel
{
    class GameViewModel :BaseViewModel
    {
        private Gebruiker actieveGebruiker;
        public Gebruiker ActieveGebruiker
        {
            get {
                if (actieveGebruiker == null)
                {
                    actieveGebruiker= new Gebruiker();
                }
                return actieveGebruiker;

            }
            set {

                actieveGebruiker = value;
                NotifyPropertyChanged();

            }
        }
        private Speler player1;
        private Speler player2;
        public Speler Player1
        {
            get {
                return player1;
            }
            set {
                player1 = value;
                NotifyPropertyChanged();
            }
        } public Speler Player2
        {
            get {
                return player2;
            }
            set {
                player2 = value;
                NotifyPropertyChanged();
            }
        }

        private Board board;
        public Board Board
        {
            get {
                return board;
            }
            set {
                board = value;
                NotifyPropertyChanged();
            }
        }
        private Spel spel;
        public Spel Spel
        {
            get {
                return spel;
            }
            set {
                spel = value;
                NotifyPropertyChanged();
            }
        }
        private List<Schijf> schijfjes;
        public List<Schijf> Schijfjes
        {
            get {
                return schijfjes;
            }

            set {
                schijfjes = value;
                NotifyPropertyChanged();
            }
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
        }     private double progress;
        public double Progress
        {
            get {
                return progress;
            }

            set {
                progress= value;
                NotifyPropertyChanged();
            }
        }
        public GameViewModel()
        {
         
            //bord definieren
            SchijfDataService schijfDS = new SchijfDataService();
            Board = new Board(schijfDS.GetSchijf(1), schijfDS.GetSchijfjes(),rowCol);
            KoppelenCommands();
            

            //luisteren naar updates
            Messenger.Default.Register<Gebruiker>(this, OnMessageReceived);
        }
        private void OnMessageReceived(Gebruiker message)
        {
            //update 
            ActieveGebruiker = message;
        }
        public ICommand RestartCommand { get; set; }
        public ICommand MouseDownCommand { get; set; }
        public ICommand PauseCommand { get; set; }
        private void KoppelenCommands()
        {
            // a different BaseCommand with parameter, we need to know what column was clicked
            MouseDownCommand = new BaseParCommand(Move);
            RestartCommand = new BaseCommand(Restart);
            PauseCommand = new BaseCommand(Pause);
        }

        public void Restart()
        {
            //bord definieren
            Message = "";
            Progress = 0;
            started = false;
           SchijfDataService schijfDS = new SchijfDataService();
            Board = new Board(schijfDS.GetSchijf(1), schijfDS.GetSchijfjes(), rowCol);
        }
        public void Pause()
        {
            GebruikerDataService gebruikerDS = new GebruikerDataService();
            Gebruiker gebruikerFromDB = gebruikerDS.GetGebruiker(ActieveGebruiker.Gebruikersnaam);       
            Messenger.Default.Send<Gebruiker>(gebruikerFromDB);
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Welcome");
    
        }

        private int beurt=1;
        private bool started=false;
        private int rowCol=8;
        private void Move(object id)
        {

            if (!started)
            {
                
                ObjectenDefinieren();
                started = true;
            }
            if ((int)id >= 0)
            {
                if (beurt==1)
                {
                    //
                    Zet zet = Board.Move((int)id, Player1.Id, Spel.Id, 3, "Red");
                    if (zet.SpelerId > 0)
                    {
                        ZetDataService zetDS = new ZetDataService();
                        zetDS.RegisterMove(zet);

                    }
                    //check if move is confirmed
                    if (Board.confirm())
                    {
                        //change player
                        Board.PickPlayer2();
                        beurt = 2;
                        //increase progressbar
                        Progress =Progress+1.5625;
                        //check for win player1
                        if (Board.Checkwin((int)id, rowCol, Player1.Id))
                        {
                            Message = ActieveGebruiker.Roepnaam + " heeft gewonnen!";
                            Spel.Eindtijd = DateTime.Now;
                            Spel.Winnaar = 1;
                            //update database
                            SpelDataService spelDS = new SpelDataService();
                            spelDS.UpdateSpel(Spel);
                            //end game
                            Board.End();
                        }
                        else
                        {
                            //check if board is full
                            if (Board.IsFull())
                            {
                                //call full function
                                Full_board();
                            }
                           
                        }
                    }
                   
                }
                else
                {
                    if (beurt == 2)
                    {
                        Zet zet = Board.Move((int)id, Player2.Id, Spel.Id, 4, "Yellow");
                        if (zet.SpelerId > 0)
                        {
                            ZetDataService zetDS = new ZetDataService();
                            zetDS.RegisterMove(zet);

                        }
                        if (Board.confirm())
                        {

                            beurt = 1;
                            Board.PickPlayer1();
                            Progress = Progress + 1.5625;
                            if (Board.Checkwin((int)id, rowCol, Player2.Id))
                            {
                                Message = "Guest heeft gewonnen!";
                                Spel.Eindtijd = DateTime.Now;
                                Spel.Winnaar = 0;
                                SpelDataService spelDS = new SpelDataService();
                                spelDS.UpdateSpel(Spel);
                                Board.End();
                            }
                            else
                            {
                                //check if board is full
                                if (Board.IsFull())
                                {
                                    Full_board();
                                }
                            }
                        }
                    }
                 
                    
                }

            }
        }
        public void Full_board()
        {
            //functie voor wanneer het bord vol is
            Message = "Bord is vol!";
            Spel.Eindtijd = DateTime.Now;
            Spel.Winnaar = -1;
            SpelDataService spelDS = new SpelDataService();
            spelDS.UpdateSpel(Spel);
        }
        private void ObjectenDefinieren()
        {
            //spel aanmaken
            if (ActieveGebruiker.Id != 0)
            {
                Spel = new Spel();
                spel.Begintijd = DateTime.Now;
                spel.GebruikerId = ActieveGebruiker.Id;
                SpelDataService spelDS = new SpelDataService();
                spel.Id = spelDS.RegisterGame(Spel);

                //spelers
                SpelerDataService spelerDS = new SpelerDataService();
                //player1 aanmaken
                player1 = new Speler();
                Player1.GebruikerId = actieveGebruiker.Id;
                Player1.SchijfId = 3;
                Player1.SpelId = spel.Id;
                Player1.Id = spelerDS.RegisterPlayer1(Player1);
                //player2 aanmaken
                player2 = new Speler();
                Player2.SchijfId = 4;
                Player2.SpelId = spel.Id;
                Player2.Id = spelerDS.RegisterPlayer2(Player2);

           
            }
        }
    
    }
}
