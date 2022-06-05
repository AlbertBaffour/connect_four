using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectAlbert.Model
{
    class Spel: BaseModel
    {
        private int id;
        private DateTime begintijd;
        private DateTime eindtijd;
        private int gebruikerId;
        private int winnaar;



        public Spel()
        {
        }

        public Spel(int id, DateTime begintijd, DateTime eindtijd, int gebruikerId,int winnaar)
        {
            Id = id;
            Begintijd = begintijd;
            Eindtijd = eindtijd;
            GebruikerId = gebruikerId;
            Winnaar = winnaar;

        }

        public int Id
        {
            get { return id; }
            set {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime Begintijd
        {
            get { return begintijd; }
            set {
                begintijd = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime Eindtijd
        {
            get { return eindtijd; }
            set {
                eindtijd = value;
                NotifyPropertyChanged();
            }
        }

        public int GebruikerId
        {
            get { return gebruikerId; }
            set {
                gebruikerId = value;
                NotifyPropertyChanged();
            }
        }
        public int Winnaar
        {
            get { return winnaar; }
            set {
                winnaar = value;
                NotifyPropertyChanged();
            }
        }
       
    }
}
