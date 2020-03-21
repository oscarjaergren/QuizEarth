using System;
using QuizEarth.Views.Admin;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizEarth.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryPopUpPage : PopupPage
    {
        private readonly string _countryId;

        public CountryPopUpPage(string countryId)
        {
            _countryId = countryId;
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Routing.RegisterRoute("quizPage", typeof(QuizPage));
            Shell.Current.GoToAsync($"quizPage?countryId={_countryId}");
        }
    }
}