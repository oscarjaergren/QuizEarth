using MvvmHelpers.Commands;
using QuizEarth.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QuizEarth.PageModels.User
{
    public class SettingsPageModel
    {
        public ICommand LogOutCommand { get; set; }

        public SettingsPageModel()
        {
            LogOutCommand = new MvvmHelpers.Commands.Command(OnLogout);
        }

        private void OnLogout()
        {
            //Set Loggedin to false
            SecureStorage.SetAsync("IsLoggedIn", "0").ConfigureAwait(false);

            Application.Current.MainPage = new AuthenticationAppShell();
        }
    }
}
