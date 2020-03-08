using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MvvmHelpers.Commands;
using QuizEarth.Views.AppShells;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QuizEarth.PageModels
{
    public class LoginPageModel : BaseViewModel
    {
        private bool _areCredentialsInvalid;
        private string _password;
        private string _username;

        public LoginPageModel()
        {
            AreCredentialsInValid = false;
        }

        public ICommand RegisterCommand => new AsyncCommand(OnRegister);

        public ICommand AuthenticateCommand => new AsyncCommand(OnAuthenticate);

        public Models.User CurrentUser { get; set; }

        public string UserName
        {
            get => _username;
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        public bool AreCredentialsInValid
        {
            get => _areCredentialsInvalid;
            set
            {
                if (value == _areCredentialsInvalid) return;
                _areCredentialsInvalid = value;
                OnPropertyChanged(nameof(AreCredentialsInValid));
            }
        }

        private async Task OnRegister()
        {
            var user = new Models.User(UserName, Password, false);

            var doesUserExist = await App.Database.GetUserByUserName(user.UserName);

            if (doesUserExist != null)
            {
                await UserDialogs.Instance.AlertAsync("This user already exists, please use a different userName",
                    "Username taken", "OK");
                return;
            }

            await App.Database.InsertUser(user);

            MainThread.BeginInvokeOnMainThread(
                () => { Shell.Current.GoToAsync("//authentication/registration"); });
        }


        private async Task OnAuthenticate()
        {
            AreCredentialsInValid = await UserAuthenticatedAsync(UserName, Password);

            // Return if credentials are not valid
            if (AreCredentialsInValid) return;

            // Save that we are now logged in
            await SecureStorage.SetAsync("IsLoggedIn", "1").ConfigureAwait(false);

            // Save last userId
            await SecureStorage.SetAsync("LastUserId", "1").ConfigureAwait(false);

            NavigateUser();
        }

        private void NavigateUser()
        {
            if (CurrentUser.IsAdmin)
                Application.Current.MainPage = new AdminAppShell();
            else
                Application.Current.MainPage = new AppShell();

            MainThread.BeginInvokeOnMainThread(() => { Shell.Current.GoToAsync("//map"); });
        }

        private async Task<bool> UserAuthenticatedAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password))
                return true;

            CurrentUser = await App.Database.GetUser(username, password);

            if (CurrentUser == null) return true;

            return false;
        }
    }
}