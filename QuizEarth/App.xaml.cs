using QuizEarth.Data;
using QuizEarth.Services;
using QuizEarth.Views;
using QuizEarth.Views.User;
using Xamarin.Forms;

namespace QuizEarth
{
    public partial class App : Application
    {
        private static QuizEarthDatabase _database;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public static QuizEarthDatabase Database => _database ?? (_database = new QuizEarthDatabase());

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