using GeoJSON.Net.Feature;
using Newtonsoft.Json;
using QuizEarth.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuizEarth.Helpers
{
    public  class CountryJsonReader
    {
        private  string ReadCountryGeoJson()
        {
            var assembly = typeof(App).Assembly;
            var stream = assembly.GetManifestResourceStream("QuizEarth.Resources.countries.geo.json");
            if (stream == null) throw new InvalidOperationException("Countries GeoJSON resource file missing");
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public  List<Country> GetCountries()
        {
            var items = JsonConvert.DeserializeObject<List<Country>>(ReadCountryGeoJson());
            return items;
        }

        public  Country[] GetPolygons()
        {
            var polygons = JsonConvert.DeserializeObject<FeatureCollection>(ReadCountryGeoJson());

            var modifiedPolygons =
                polygons.Features
                    .Select(f => new Country(f.Id, f.Properties["name"].ToString()))
                    .OrderBy(c => c.Name)
                    .ToArray();

            return modifiedPolygons;
        }

        //public static async List<Country> GetCountries()
        //{
        //    var assembly = typeof(App).Assembly;
        //    var stream = assembly.GetManifestResourceStream("QuizEarth.Resources.countries.geo.json");
        //    if (stream == null) throw new InvalidOperationException("Countries GeoJSON resource file missing");

        //    using (FileStream fs = File.OpenRead("QuizEarth.Resources.countries.geo.json"))
        //    {
        //        var list = await JsonSerializer.DeserializeAsync<List<Country>>(fs);
        //        return list;
        //    }
        //}
    }
}
