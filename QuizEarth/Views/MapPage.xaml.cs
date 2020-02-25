using QuizEarth.Controls.Effects;

using SkiaSharp;
using SkiaSharp.Views.Forms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizEarth.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public double areaStartX { get; set; }

        public double areaEndX { get; set; }


        public MapPage()
        {
            InitializeComponent();
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            bool touchPointMoved = false;
            // Convert Xamarin.Forms point to pixels
            Point pt = args.Location;
            SKPoint point = new SKPoint(
                (float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));

            var items = canvasView.GetChildElements(pt);
            var items2 = canvasView.LogicalChildren;

            // Uncomment the code below based on what you specifically need
            // if (point != The Point you care about) or (pt != The Location you care about
            // return;
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    //if (pt != pt2)
                    //{
                    //    //You touched in the desired position
                    //}

                    break;
            }
        }

    }
}