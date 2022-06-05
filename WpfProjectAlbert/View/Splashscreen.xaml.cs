using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfProjectAlbert.View
{
    /// <summary>
    /// Interaction logic for Splashscreen.xaml
    /// </summary>
    public partial class Splashscreen : Window
    {
        DispatcherTimer dT = new DispatcherTimer();
        public Splashscreen()
        {
            InitializeComponent();
            dT.Tick += new EventHandler(dt_Tick);
            dT.Interval = new TimeSpan(0, 0, 2);
            dT.Start();
        }
        private void dt_Tick(object sender, EventArgs e)
        {
            View.MainWindow main = new View.MainWindow();
            main.Show();
            dT.Stop();
            this.Close();
        }
    }
}
