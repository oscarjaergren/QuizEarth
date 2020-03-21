using QuizEarth.Data;
using QuizEarth.Views.AppShells;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QuizEarth
{
    public partial class App : Application
    {
        private static QuizEarthDatabase _database;

        public App()
        {
            InitializeComponent();

            InitNavigation();

            DatabaseInitializationHelper.Initialize();
        }

        public static QuizEarthDatabase Database => _database ?? (_database = new QuizEarthDatabase());

        /// <summary> Decides where user will be redirected to, if logged in already skip login. </summary>
        private void InitNavigation()
        {
            // Check if we are logged in, if we are go to main page, else go to login.
            var loggedIn = SecureStorage.GetAsync("IsLoggedIn").Result;

            if (loggedIn == "1")
            {
                var lastUserId = SecureStorage.GetAsync("LastUserId").Result;
                int.TryParse(lastUserId, out var userId);

                var user = Database.GetUserByUserId(userId);

                if (user.Result.IsAdmin)
                    MainPage = new AdminAppShell();
                else
                    MainPage = new AppShell();
            }
            else
            {
                MainPage = new AuthenticationAppShell();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}