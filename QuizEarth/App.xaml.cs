using QuizEarth.Services;
using QuizEarth.Views;

using Xamarin.Forms;

namespace QuizEarth
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MapPage2();
            
            //MainPage = new AppShell();
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