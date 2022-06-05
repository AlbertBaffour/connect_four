using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProjectAlbert.ViewModel;

namespace WpfProjectAlbert
{
    class ViewModelLocator
    {
        private static LoginViewModel loginViewModel = new LoginViewModel();
        private static RegisterViewModel registerViewModel = new RegisterViewModel();
         private static WelcomeViewModel welcomeViewModel = new WelcomeViewModel();
         private static InstructionsViewModel instructionsViewModel = new InstructionsViewModel();
         private static SettingsViewModel settingsViewModel = new SettingsViewModel();
         private static GameViewModel gameViewModel = new GameViewModel();
               
        public static LoginViewModel LoginViewModel
        {
            get {
                return loginViewModel;
            }
        }
        public static RegisterViewModel RegisterViewModel
        {
            get {
                return registerViewModel;
            }
        }
        public static WelcomeViewModel WelcomeViewModel
        {
            get {
                return welcomeViewModel;
            }
        } 
        public static InstructionsViewModel InstructionsViewModel
        {
            get {
                return instructionsViewModel;
            }
        }
        public static SettingsViewModel SettingsViewModel
            {
            get {
                return settingsViewModel;
            }
        }
        public static GameViewModel GameViewModel
            {
            get {
                return gameViewModel;
            }
        }
    }
}
