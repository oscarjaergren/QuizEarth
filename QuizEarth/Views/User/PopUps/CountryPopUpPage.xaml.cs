using System;
using QuizEarth.PageModels.User.PopUps;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;

namespace QuizEarth.Views.User.PopUps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryPopUpPage : PopupPage
    {
        public CountryPopUpPageModel ViewModel => BindingContext as CountryPopUpPageModel;

        public CountryPopUpPage(int countryId, string countryName)
        {
            BindingContext = new CountryPopUpPageModel(countryId, countryName);

            InitializeComponent();
        }

        private async void OnCloseButtonTapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}