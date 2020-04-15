using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExemploSkiasharp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            skcv.PaintSurface += Skcv_PaintSurface;
        }

        private void Skcv_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            SKImageInfo info = e.Info;
            canvas.Clear();

            SKRect rect = SKRect.Create(info.Width / 2, info.Width / (float)1.22);
            float x = (info.Width / 4) * -1;
            float y = (info.Height / 4) * -1; ;
            rect.Offset(x, y);

            // Translate to center
            canvas.Translate(info.Width / 2, info.Height / 2);

            using (SKPath path = new SKPath())
            {
                path.AddOval(rect, SKPathDirection.CounterClockwise);
                canvas.ClipPath(path, SKClipOperation.Difference);
                using (SKPaint paint = new SKPaint())
                {
                    paint.Style = SKPaintStyle.Fill;
                    paint.Color = SKColors.Green.WithAlpha(0x50);
                    canvas.DrawPaint(paint);
                    
                }
            }
        }
    }
}
