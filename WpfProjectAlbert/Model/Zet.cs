using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectAlbert.Model
{
    class Zet:BaseModel
    {
        private int id;
        private int spelerId;
        private int spelId;
        private int kolom;
        private int rij;
        private int schijfId;
        private string fillColor;


        public Zet()
        {
   
        }       
        public Zet(int id, int spelerId, int spelId,int kolom,int rij, int schijfId,string fillColor)
        {
            Id = id;
           SpelerId =spelerId;
            SpelId = spelId;
            Kolom=kolom;
            Rij = rij;
            SchijfId = schijfId;
            FillColor = fillColor;
        }

        public string FillColor
        {
            get { return fillColor; }
            set {
                fillColor = value;
                NotifyPropertyChanged();
            }
        }
        public int Id
        {
            get { return id; }
            set {
                id = value;
                NotifyPropertyChanged();
            }
        }
        public int SpelId
        {
            get { return spelId; }
            set {
                spelId = value;
                NotifyPropertyChanged();
            }
        }

        public int SpelerId
        {
            get { return spelerId; }
            set {
                spelerId = value;
                NotifyPropertyChanged();
            }
        }

        public int Kolom
        {
            get { return kolom; }
            set {
                kolom = value;
                NotifyPropertyChanged();
            }
        }
        public int Rij
        {
            get { return rij; }
            set {
                rij = value;
                NotifyPropertyChanged();
            }
        } 
        public int SchijfId        {
            get { return schijfId; }
            set {
                schijfId = value;
                NotifyPropertyChanged();
            }
        }
    }
}
