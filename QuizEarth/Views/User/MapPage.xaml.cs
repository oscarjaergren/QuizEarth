using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GeoJSON.Net;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using QuizEarth.Controls.Map;
using QuizEarth.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;
using Polygon = GeoJSON.Net.Geometry.Polygon;
using Position = Xamarin.Forms.GoogleMaps.Position;

namespace QuizEarth.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private const string StyleText = "[\n" +
                                         "  {\n" +
                                         "    \"elementType\": \"labels\",\n" +
                                         "    \"stylers\": [\n" +
                                         "      {\n" +
                                         "        \"visibility\": \"off\"\n" +
                                         "      }\n" +
                                         "    ]\n" +
                                         "  },\n" +
                                         "  {\n" +
                                         "    \"featureType\": \"water\",\n" +
                                         "    \"elementType\": \"geometry.fill\",\n" +
                                         "    \"stylers\": [\n" +
                                         "      {\n" +
                                         "        \"color\": \"#4c4c4c\"\n" +
                                         "      }\n" +
                                         "    ]\n" +
                                         "  }" +
                                         "]";

        private FeatureCollection _countryPolygons;

        private CountryPopUpPage _countryPopUp;
        private Country _selectedCountry;

        public MapPage()
        {
            InitializeComponent();
            BindingContext = this;
            InitData();

            SetMapStyle();
            CenterMapOnEurope();
            HighlightAvailableCountries();
        }

        public List<Country> AvailableCountries { get; private set; }

        private void SetMapStyle()
        {
            Map.MapStyle = MapStyle.FromJson(StyleText);
        }

        private void InitData()
        {
            _countryPolygons = JsonConvert.DeserializeObject<FeatureCollection>(ReadCountryGeoJson());
        }

        private async void HighlightAvailableCountries()
        {
            AvailableCountries = await App.Database.GetQuizCountries();

            HighlightCountry();
        }

        private void HighlightCountry()
        {
            //Create map polygons
            var polygons = new List<MapPolygon>();

            foreach (var availableCountry in AvailableCountries)
            {
                var feature = _countryPolygons.Features.FirstOrDefault(f =>
                    f.Id.Equals(availableCountry.CountryId, StringComparison.CurrentCultureIgnoreCase));

                if (feature == null) return;

                if (feature.Geometry.Type == GeoJSONObjectType.MultiPolygon)
                {
                    //Country area consists of multiple polygons
                    var multiPolygonGeometry = feature.Geometry as MultiPolygon;
                    foreach (var polygonGeometry in multiPolygonGeometry?.Coordinates)
                    {
                        var polygon = GeoJsonPolygonToMapPolygon(polygonGeometry);
                        if (polygon != null) polygons.Add(polygon);
                    }
                }

                else if (feature.Geometry.Type == GeoJSONObjectType.Polygon)
                {
                    //Single polygon
                    var polygonGeometry = feature.Geometry as Polygon;
                    var polygon = GeoJsonPolygonToMapPolygon(polygonGeometry);
                    if (polygon != null) polygons.Add(polygon);
                }
            }

            //Create the map highlight
            var highlight = new MapHighlight(polygons.ToArray())
            {
                FillColor = Color.FromRgba(255, 0, 0, 128),
                StrokeColor = Color.FromRgba(0, 0, 255, 128),
                StrokeThickness = 3
            };

            Map.Highlight = highlight;
        }

        private void CenterMapOnEurope()
        {
            var mapPosition = new Position(50.2649, 28.6767);

            Map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(mapPosition.Latitude, mapPosition.Longitude),
                Distance.FromMiles(2000)));
        }

        private MapPolygon GeoJsonPolygonToMapPolygon(Polygon geoJsonPolygon)
        {
            var outer = geoJsonPolygon?.Coordinates.FirstOrDefault();
            if (outer != null)
            {
                var polygon = new MapPolygon(
                    outer.Coordinates
                        .Select(point => new Position(point.Latitude, point.Longitude)).ToArray());
                return polygon;
            }

            return null;
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

        private void Map_OnMapClicked(object sender, MapClickedEventArgs e)
        {
            var position = new Position(e.Point.Latitude, e.Point.Longitude);
            GetCountryFromTap(position);
        }

        private async void GetCountryFromTap(Position clickPosition)
        {
            var lat = clickPosition.Latitude;
            var lon = clickPosition.Longitude;

            var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

            var placemark = placemarks?.FirstOrDefault();

            var countryName = placemark.CountryCode;

            var country = AvailableCountries.FirstOrDefault(x => x.CountryId == countryName);

            if (country != null)
            {
                _countryPopUp = new CountryPopUpPage(country.CountryId);
                await PopupNavigation.Instance.PushAsync(_countryPopUp);
            }
        }
    }
}