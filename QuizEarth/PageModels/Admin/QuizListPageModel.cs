using GeoJSON.Net.Feature;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using QuizEarth.Helpers;
using QuizEarth.Models;
using QuizEarth.Views.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizEarth.PageModels.Admin
{
    public class QuizListPageModel : BaseViewModel
    {
        private static Country selectedCountry;
        private ObservableCollection<Country> countries;

        public ObservableCollection<Country> Countries
        {
            get => countries;
            private set
            {
                countries = value;
                OnPropertyChanged(nameof(Countries));

            }
        }

        private async Task OnGoToEditQuiz()
        {
            if (SelectedCountry != null)
            {
                Routing.RegisterRoute("adminPage", typeof(EditQuizPage));
                await Shell.Current.GoToAsync($"adminPage?countryId={SelectedCountry.Id}").ConfigureAwait(false);
            }
        }

        /// <summary> Gets or sets the selected video. </summary>
        public Country SelectedCountry
        {
            get => selectedCountry;
            set => SetProperty(ref selectedCountry, value);
        }

        public ICommand GoToEditQuizCommand => new AsyncCommand(OnGoToEditQuiz);


        public QuizListPageModel()
        {
            GetCountries().SafeFireAndForget();
        }

        private async Task GetCountries()
        {
            var countries = await App.Database.GetAllCountries();

            Countries = new ObservableCollection<Country>(countries);

        }
    }
}
