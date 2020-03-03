using GeoJSON.Net.Feature;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using QuizEarth.Helpers;
using QuizEarth.Models;
using QuizEarth.Views.Admin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizEarth.PageModels.Admin
{
    public class EditQuizPageModel : BaseViewModel
    {
        private static Country selectedCountry;

        public List<Country> Countries { get; private set; }

        private async Task OnGoToEditQuiz()
        {
            if (SelectedCountry != null)
            {
                Routing.RegisterRoute("adminPage", typeof(AdminPage));
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


        public EditQuizPageModel()
        {
            Countries = GetCountries();
        }

        private string ReadCountryGeoJson()
        {
            var assembly = typeof(App).Assembly;
            var stream = assembly.GetManifestResourceStream("QuizEarth.Resources.countries.geo.json");
            if (stream == null) throw new InvalidOperationException("Countries GeoJSON resource file missing");
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public List<Country> GetCountries()
        {
            var items = JsonConvert.DeserializeObject<FeatureCollection>(ReadCountryGeoJson());
            var items2 = items.Features
                    .Select(f => new Country(f.Id, f.Properties["name"].ToString()))
                    .OrderBy(c => c.Name)
                    .ToList();

            return items2;
        }
    }
}
