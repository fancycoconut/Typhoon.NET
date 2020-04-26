using System;
using System.Drawing.Imaging;
using System.Drawing;

namespace Typhoon.NET
{
	public class FastPixel
	{
		public byte[] rgbValues = new byte[4];

		private BitmapData bitmapData;
		private IntPtr bitmapPointer;
		private bool locked = false;

		public int Width { get;  }
		public int Height { get; }
		public bool IsAlphaBitmap { get; }
		public Bitmap Bitmap { get; }


		public FastPixel(Bitmap bitmap)
		{
			if (bitmap.PixelFormat == (bitmap.PixelFormat | PixelFormat.Indexed))
			{
				throw new Exception("Cannot lock an Indexed image.");
			}

			Bitmap = bitmap;
			Width = bitmap.Width;
			Height = bitmap.Height;
			IsAlphaBitmap = this.Bitmap.PixelFormat == (this.Bitmap.PixelFormat | PixelFormat.Alpha);
		}

		public void Lock()
		{
			if (locked)	throw new Exception("Bitmap already locked.");

			var rect = new Rectangle(0, 0, this.Width, this.Height);
			bitmapData = Bitmap.LockBits(rect, ImageLockMode.ReadWrite, Bitmap.PixelFormat);
			bitmapPointer = bitmapData.Scan0;

			//if (IsAlphaBitmap)
			//{
			//	//int bytes = (this.Width * this.Height) * 4;
			//	// ERROR: Not supported in C#: ReDimStatement

			//	System.Runtime.InteropServices.Marshal.Copy(this.bitmapPointer, rgbValues, 0, this.rgbValues.Length);
			//}
			//else
			//{
			//	//int bytes = (this.Width * this.Height) * 3;
			//	// ERROR: Not supported in C#: ReDimStatement

			//	System.Runtime.InteropServices.Marshal.Copy(this.bitmapPointer, rgbValues, 0, this.rgbValues.Length);
			//}

			System.Runtime.InteropServices.Marshal.Copy(bitmapPointer, rgbValues, 0, rgbValues.Length);

			locked = true;
		}

		public void Unlock(bool setPixels)
		{
			if (!locked) throw new Exception("Bitmap not locked.");

			// Copy the RGB values back to the bitmap
			if (setPixels) System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, bitmapPointer, rgbValues.Length);
			// Unlock the bits.
			Bitmap.UnlockBits(bitmapData);
			locked = false;
		}

		public void Clear(Color colour)
		{
			if (!locked) throw new Exception("Bitmap not locked.");

			if (IsAlphaBitmap)
			{
				for (var i = 0; i <= rgbValues.Length; i += 4)
				{
					rgbValues[i] = colour.B;
					rgbValues[i + 1] = colour.G;
					rgbValues[i + 2] = colour.R;
					rgbValues[i + 3] = colour.A;
				}
			}
			else
			{
				for (var i = 0; i <= rgbValues.Length; i += 3)
				{
					rgbValues[i] = colour.B;
					rgbValues[i + 1] = colour.G;
					rgbValues[i + 2] = colour.R;
				}
			}
		}

		public void SetPixel(Point location, Color colour)
		{
			SetPixel(location.X, location.Y, colour);
		}

		public void SetPixel(int x, int y, Color colour)
		{
			if (!locked) throw new Exception("Bitmap not locked.");

			if (IsAlphaBitmap)
			{
				var index = (y * Width + x) * 4;
				rgbValues[index] = colour.B;
				rgbValues[index + 1] = colour.G;
				rgbValues[index + 2] = colour.R;
				rgbValues[index + 3] = colour.A;
			}
			else
			{
				var index = (y * Width + x) * 3;
				rgbValues[index] = colour.B;
				rgbValues[index + 1] = colour.G;
				rgbValues[index + 2] = colour.R;
			}
		}

		public Color GetPixel(Point location)
		{
			return GetPixel(location.X, location.Y);
		}

		public Color GetPixel(int x, int y)
		{
			if (!locked) throw new Exception("Bitmap not locked.");

			if (IsAlphaBitmap)
			{
				int index = (y * Width + x) * 4;
				int b = rgbValues[index];
				int g = rgbValues[index + 1];
				int r = rgbValues[index + 2];
				int a = rgbValues[index + 3];

				return Color.FromArgb(a, r, g, b);
			}
			else
			{
				int index = (y * Width + x) * 3;
				int b = rgbValues[index];
				int g = rgbValues[index + 1];
				int r = rgbValues[index + 2];

				return Color.FromArgb(r, g, b);
			}
		}
	}
}