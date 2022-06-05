using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectAlbert.Model
{
    class Speler:BaseModel
    {
        private int id;
        private int gebruikerId;
        private int spelId;
        private int schijfId;


        public Speler()
        {
        }

        public Speler(int id, int gebruikerId, int spelId, int schijfId)
        {
            Id = id;
            GebruikerId = gebruikerId;
            SpelId = spelId;
            SchijfId = schijfId;
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

        public int GebruikerId
        {
            get { return gebruikerId; }
            set {
                gebruikerId = value;
                NotifyPropertyChanged();
            }
        }

        public int SchijfId
        {
            get { return schijfId; }
            set {
                schijfId = value;
                NotifyPropertyChanged();
            }
        }
     
    }
}
