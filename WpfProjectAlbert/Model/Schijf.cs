using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfProjectAlbert.Model
{
    class Schijf:BaseModel
    {
        private int id;
        private string fillColor;
        public Schijf() { }
        public Schijf(int id, string fillColor)
        {
            Id = id;
            FillColor = fillColor;
        }
           public int Id
        {
            get { return id; }
            set {
                id = value;
                NotifyPropertyChanged();
            }
        }
        public string FillColor
        {
            get { return fillColor; }
            set {
                fillColor = value;
                NotifyPropertyChanged();
            }
        }
    }
}
