using GeoJSON.Net.Feature;
using Newtonsoft.Json;
using QuizEarth.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace QuizEarth.Data
{
    public static class DatabaseInitalizationHelper
    {
        public static bool DatabaseIsInitialized { get; set; }

        /// <summary> Decides where user will be redirected to, if logged in already skip login. </summary>
        public static void Initialize()
        {
            // Check if we have created database, if we have return;
            string initalized = SecureStorage.GetAsync("IsInitalized").Result;
            if (initalized == "1")
            {
                DatabaseIsInitialized = true;
                return;
            }
            else
            {
                DatabaseIsInitialized = false;
                SecureStorage.SetAsync("IsInitalized", "1").ConfigureAwait(false);
                PopulateCountriesIntoDatabase();
                CreateAdminUser();
                CreateQuestions();
            }
        }

        private static void CreateQuestions()
        {
            var questions = new List<Question>();

            for (int i = 0; i < 10; i++)
            {
                var question = new Question(2)
                {
                    Answer1 = "Uppsala",
                    Answer2 = "Stockholm",
                    Answer3 = "Göteborg",
                    Answer4 = "Malmö",
                    CorrectAnswer = "Stockholm",
                    QuestionText = "What is the capital of Sweden?",
                    CountryId = 1,
                };
                questions.Add(question);
            }

            App.Database.InsertQuestions(questions);
        }

        private static void CreateAdminUser()
        {
            var user = new User("admin", "admin", true);
            App.Database.InsertUser(user);
        }


        private static void PopulateCountriesIntoDatabase()
        {
            var featuresCollection = JsonConvert.DeserializeObject<FeatureCollection>(ReadCountryGeoJson());
            var items2 = featuresCollection.Features
                    .Select(f => new Country(f.Id, f.Properties["name"].ToString()))
                    .OrderBy(c => c.Name)
                    .ToList();

            App.Database.InsertCountries(items2);
        }

        private static string ReadCountryGeoJson()
        {
            var assembly = typeof(App).Assembly;
            var stream = assembly.GetManifestResourceStream("QuizEarth.Resources.countries.geo.json");
            if (stream == null) throw new InvalidOperationException("Countries GeoJSON resource file missing");
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
