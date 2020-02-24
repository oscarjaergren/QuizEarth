using FFImageLoading.Svg.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace QuizEarth.Controls
{
    /// <summary> Changes the color of our map.</summary>
    public class MapTransformer
    {
        private const string MapPath = "QuizEarth.Resources.userWorldMap.svg";

        public static void GetEmbeddedJsonTemplate(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePath = name;

            var options = new JsonSerializerOptions
                              {
                                  PropertyNameCaseInsensitive = true,
                                  AllowTrailingCommas = true,
                                  IgnoreNullValues = true
                              };


            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            {

            }

            var dict = new Dictionary<string, string>();
            dict.Add("fill: rgb(0, 0, 0);", GetRGBFill(Color.Red));

            var icon = new SvgCachedImage
                           {
                               ReplaceStringMap = dict,
                               Source = MapPath,
                           };

            //var tapGestureRecognizer = new TapGestureRecognizer();
            //tapGestureRecognizer.Tapped += (s, e) => {
            //        // handle the tap
            //    };

            //icon.GestureRecognizers.Add(tapGestureRecognizer);
        }

        public static string GetRGBFill(Xamarin.Forms.Color color)
        {
            var red = (int)(color.R * 255);
            var green = (int)(color.G * 255);
            var blue = (int)(color.B * 255);
            var rgbFill = $"fill: rgb({red},{green},{blue});";
            return rgbFill;
        }
    }
}