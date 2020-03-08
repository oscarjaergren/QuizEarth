using Xamarin.Forms;

namespace QuizEarth.Views.AppShells
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        private void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
        }
    }
}