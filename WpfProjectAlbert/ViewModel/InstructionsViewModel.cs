using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfProjectAlbert.ViewModel
{
    class InstructionsViewModel:BaseViewModel
    {
      
        public InstructionsViewModel()
        {
            KoppelenCommands();

        }
     
        private void KoppelenCommands()
        {

            ToHomeCommand = new BaseCommand(toHomePage);
        }
        public ICommand ToHomeCommand { get; set; }

        public void toHomePage()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Welcome");


        }
    }
}
