using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Typhoon.Core.Drawing
{
    public class Surface : IDisposable
    {
        private bool disposed = false;

        private readonly Bitmap bitmap;
        private readonly Graphics graphics;

        public Surface(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            graphics = Graphics.FromImage(this.bitmap);
        }

        public Surface(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
        }

        public Surface(int width, int height, InterpolationMode interpolation) : this(width, height)
        {
            graphics.InterpolationMode = interpolation;
        }

        public Bitmap GetBitmap() => bitmap;
        public int Height { get => bitmap.Height; }
        public int Width { get => bitmap.Width; }

        public void DrawImage(Surface surface, Rectangle src, Rectangle dest)
        {
            graphics.DrawImage(surface.GetBitmap(), dest, src, GraphicsUnit.Pixel);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                bitmap?.Dispose();
                graphics?.Dispose();
            }

            disposed = true;
        }
    }
}
