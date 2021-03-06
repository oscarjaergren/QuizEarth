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
    public static class DatabaseInitializationHelper
    {
        public static bool DatabaseIsInitialized { get; set; }

        /// <summary> Decides where user will be redirected to, if logged in already skip login. </summary>
        public static void Initialize()
        {
            // Check if we have created database, if we have return;
            string initialized = SecureStorage.GetAsync("IsInitalized").Result;
            if (initialized == "1")
            {
                DatabaseIsInitialized = true;
                return;
            }
            else
            {
                DatabaseIsInitialized = false;
                SecureStorage.SetAsync("IsInitalized", "1").ConfigureAwait(false);

                App.Database.InitializeAsync().SafeFireAndForget();

                PopulateCountriesIntoDatabase().SafeFireAndForget();
                CreateAdminUser().SafeFireAndForget();
                CreateQuestions().SafeFireAndForget();
            }
        }

        private static async Task CreateQuestions()
        {
            var scottishQuestions = RawData.GetScottishQuestions();
            await App.Database.InsertQuestions(scottishQuestions);
            await App.Database.UpdateQuizStatus(true, 168);

            var swedenQuestions = RawData.GetSwedenQuestions();
            await App.Database.InsertQuestions(swedenQuestions);
            await App.Database.UpdateQuizStatus(true, 153);
        }

        private static async Task CreateAdminUser()
        {
            var user = new User("admin", "admin", true);
            await App.Database.InsertUser(user);
        }


        private static async Task PopulateCountriesIntoDatabase()
        {
            var featuresCollection = JsonConvert.DeserializeObject<FeatureCollection>(ReadCountryGeoJson());
            var items2 = featuresCollection.Features
                    .Select(f => new Country(f.Id, f.Properties["name"].ToString()))
                    .OrderBy(c => c.Name)
                    .ToList();

            await App.Database.InsertCountries(items2);
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
