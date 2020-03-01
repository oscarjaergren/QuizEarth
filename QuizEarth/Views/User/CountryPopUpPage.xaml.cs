using System;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace QuizEarth.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryPopUpPage : PopupPage
    {
        public CountryPopUpPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}