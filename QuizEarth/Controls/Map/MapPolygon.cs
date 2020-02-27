using Xamarin.Forms.GoogleMaps;

namespace QuizEarth.Controls.Map
{
    public class MapPolygon
    {
        public MapPolygon(Position[] positions)
        {
            Positions = positions;
        }

        public Position[] Positions { get; }
    }
}