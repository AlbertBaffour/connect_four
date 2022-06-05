using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProjectAlbert.View;

namespace WpfProjectAlbert
{
    public class PageNavigationService
    {
        WelcomePage welcomePage = null;
        LoginPage loginPage = null;
        InstructionsPage instructionsPage = null;
        SettingsPage settingsPage = null;
        GamePage gamePage = null;
        public PageNavigationService()
        {

        }

        public void Navigate(string page)
        {
            switch (page)
            {
                case "Welcome":
                    welcomePage = new WelcomePage();
                    ApplicationHelper.NavigationService.Navigate(welcomePage);
                    break;
                case "Login":
                    loginPage = new LoginPage();
                    ApplicationHelper.NavigationService.Navigate(loginPage);
                    break; 
                case "Instructions":
                    instructionsPage = new InstructionsPage();
                    ApplicationHelper.NavigationService.Navigate(instructionsPage);
                    break; 
                case "Settings":
                    settingsPage = new SettingsPage();
                    ApplicationHelper.NavigationService.Navigate(settingsPage);
                    break;
                case "Game":
                    gamePage = new GamePage();
                    ApplicationHelper.NavigationService.Navigate(gamePage);
                    break;
                default:
                    break;
            }
        }
    }
}
