using QuizEarth.Data;
using QuizEarth.Services;
using QuizEarth.Views;

using Xamarin.Forms;

namespace QuizEarth
{
    public partial class App : Application
    {
        static QuizEarthDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new MapPage2();
            
            //MainPage = new AppShell();
        }

        public static QuizEarthDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new QuizEarthDatabase();
                }
                return database;
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