using System.Drawing;

namespace Soundboard.Extensions
{
	public static class BitmapExtensions
	{
		public static Bitmap ChangeWhiteToColor(this Bitmap bitmap, Color newColor)
		{
			for (var x = 0; x < bitmap.Width; x++)
			for (var y = 0; y < bitmap.Height; y++)
			{
				var Color = bitmap.GetPixel(x, y);
				if (Color == Color.FromArgb(255, 255, 255, 255)) bitmap.SetPixel(x, y, newColor);
			}

			return bitmap;
		}
	}
}