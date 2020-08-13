using System.Drawing;
using MetroFramework;

namespace Soundboard.Extensions
{
	public static class StyleExtension
	{
		public static Color GetColorFromSkin(this MetroColorStyle style)
		{
			var color = Color.Transparent;

			switch (style)
			{
				case MetroColorStyle.Default:
					color = Color.LightBlue;
					break;

				case MetroColorStyle.Black:
					color = Color.Black;
					break;

				case MetroColorStyle.Blue:
					color = Color.Blue;
					break;

				case MetroColorStyle.Green:
					color = Color.Green;
					break;

				case MetroColorStyle.Brown:
					color = Color.Brown;
					break;

				case MetroColorStyle.Red:
					color = Color.Red;
					break;

				case MetroColorStyle.Lime:
					color = Color.Lime;
					break;

				case MetroColorStyle.Magenta:
					color = Color.Magenta;
					break;

				case MetroColorStyle.Orange:
					color = Color.Orange;
					break;

				case MetroColorStyle.Pink:
					color = Color.Pink;
					break;

				case MetroColorStyle.Purple:
					color = Color.Purple;
					break;

				case MetroColorStyle.Silver:
					color = Color.Silver;
					break;

				case MetroColorStyle.Teal:
					color = Color.Teal;
					break;

				case MetroColorStyle.Yellow:
					color = Color.Yellow;
					break;

				case MetroColorStyle.White:
					color = Color.White;
					break;
			}

			return color;
		}
	}
}