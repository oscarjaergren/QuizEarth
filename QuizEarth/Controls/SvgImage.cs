using System;
using System.Reflection;
using SkiaSharp.Extended.Svg;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace QuizEarth.Controls
{
    public class SvgImage : SKCanvasView
    {
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string),
            typeof(SvgImage), default(string), propertyChanged: OnPropertyChanged);

        public static readonly BindableProperty AssemblyNameProperty = BindableProperty.Create(nameof(AssemblyName),
            typeof(string), typeof(SvgImage), default(string), propertyChanged: OnPropertyChanged);

        public string Source
        {
            get => (string) GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var skCanvasView = bindable as SKCanvasView;
            skCanvasView?.InvalidateSurface();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            InvalidateSurface();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            InvalidateSurface();
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            try
            {
                var surface = e.Surface;
                var canvas = surface.Canvas;

                canvas.Clear();

                if (string.IsNullOrEmpty(Source))
                    return;

                var resourceNames = GetType().Assembly.GetManifestResourceNames();

                using (var stream = GetType().Assembly.GetManifestResourceStream(Source))
                {
                    var skSvg = new SKSvg();
                    skSvg.Load(stream);

                    var skImageInfo = e.Info;
                    canvas.Translate(skImageInfo.Width / 2f, skImageInfo.Height / 2f);

                    var skRect = skSvg.ViewBox;
                    var xRatio = skImageInfo.Width / skRect.Width;
                    var yRatio = skImageInfo.Height / skRect.Height;

                    var ratio = Math.Min(xRatio, yRatio);

                    canvas.Scale(ratio);
                    canvas.Translate(-skRect.MidX, -skRect.MidY);

                    canvas.DrawPicture(skSvg.Picture);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("OnPaintSurface Exception: " + exc);
            }
        }
    }
}