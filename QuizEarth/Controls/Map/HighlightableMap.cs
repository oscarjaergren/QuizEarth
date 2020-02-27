using Xamarin.Forms;

namespace QuizEarth.Controls.Map
{
    /// <summary>
    ///     Extended map:
    ///     allow user to tap a point on the map to get the relative position.
    /// </summary>
    public class HighlightableMap : Xamarin.Forms.GoogleMaps.Map
    {
        public static readonly BindableProperty HighlightProperty = BindableProperty.Create(
            nameof(Highlight),
            typeof(MapHighlight),
            typeof(HighlightableMap));

        public MapHighlight Highlight
        {
            get => (MapHighlight)GetValue(HighlightProperty);
            set => SetValue(HighlightProperty, value);
        }
    }
}