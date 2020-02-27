using System.ComponentModel;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using QuizEarth.Controls.Map;
using QuizEarth.Droid;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HighlightableMap), typeof(HighlightableMapRenderer))]

namespace QuizEarth.Droid
{
    public class HighlightableMapRenderer : MapRenderer
    {
        public HighlightableMapRenderer(Context context)
            : base(context)
        {
        }

        //protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.GoogleMaps.Map> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.NewElement != null)
        //    {
        //        Control.GetMap
        //    }
        //}

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(HighlightableMap.Highlight)) OnUpdateHighlight();
        }

        protected override void OnMapReady(GoogleMap map, Map formsMap)
        {
            base.OnMapReady(map, formsMap);

            OnUpdateHighlight();
        }

        private void OnUpdateHighlight()
        {
            var highlightableMap = (HighlightableMap) Element;
            if (highlightableMap == null || NativeMap == null) return;

            NativeMap.Clear();

            if (highlightableMap?.Highlight == null) return;

            var fillColor = highlightableMap.Highlight.FillColor.ToAndroid().ToArgb();
            var strokeColor = highlightableMap.Highlight.StrokeColor.ToAndroid().ToArgb();
            var strokeThickness = highlightableMap.Highlight.StrokeThickness;

            foreach (var polygon in highlightableMap.Highlight.Polygons)
            {
                var polygonOptions = new PolygonOptions();

                polygonOptions.InvokeFillColor(fillColor);
                polygonOptions.InvokeStrokeColor(strokeColor);
                polygonOptions.InvokeStrokeWidth(strokeThickness);

                foreach (var position in polygon.Positions)
                    polygonOptions.Add(new LatLng(position.Latitude, position.Longitude));

                NativeMap.AddPolygon(polygonOptions);
            }
        }
    }
}