﻿using GeoJSON.Net.Feature;
using Newtonsoft.Json;
using QuizEarth.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
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

                App.Database.InitializeAsync().SafeFireAndForget();

                PopulateCountriesIntoDatabase();
                CreateAdminUser().SafeFireAndForget();
                CreateQuestions();
            }
        }

        private static void CreateQuestions()
        {
            var questions = new List<Question>();
            var countryid = 1;

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
                    CountryId = countryid,
                };
                questions.Add(question);
            }

            App.Database.InsertQuestions(questions);
            App.Database.UpdateQuizStatus(countryid, true);

        }

        private static async Task CreateAdminUser()
        {
            var user = new User("admin", "admin", true);
            await App.Database.InsertUser(user);
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
