using System.Drawing;
using MetroFramework;
using SimpleSoundboard.NameService.Models;

namespace SimpleSoundboard.Extensions
{
	public static class StyleManagerExtensions
	{
		public static MetroThemeStyle ToMetroTheme(this ApplicationStyle applicationStyle)
		{
			switch (applicationStyle)
			{
				case ApplicationStyle.Dark:
					return MetroThemeStyle.Dark;
				case ApplicationStyle.Light:
					return MetroThemeStyle.Light;
			}

			return MetroThemeStyle.Light;
		}


		public static MetroColorStyle ToMetroColor(this ApplicationAccentColor applicationAccentColor)
		{
			return (MetroColorStyle) applicationAccentColor;
		}


		public static Pen ToPen(this MetroThemeStyle themeStyle)
		{
			switch (themeStyle)
			{
				case MetroThemeStyle.Light:
					return Pens.Black;
				case MetroThemeStyle.Dark:
					return Pens.AntiqueWhite;
			}

			return Pens.Black;
		}

		public static Brush ToBrush(this MetroThemeStyle themeStyle)
		{
			switch (themeStyle)
			{
				case MetroThemeStyle.Light:
					return Brushes.Black;
				case MetroThemeStyle.Dark:
					return Brushes.AntiqueWhite;
			}

			return Brushes.Black;
		}


		public static Brush ToBrush(this MetroColorStyle colorStyle)
		{
			switch (colorStyle)
			{
				case MetroColorStyle.Black:
					return Brushes.Black;
				case MetroColorStyle.White:
					return Brushes.White;
				case MetroColorStyle.Silver:
					return Brushes.Silver;
				case MetroColorStyle.Blue:
					return Brushes.Blue;
				case MetroColorStyle.Green:
					return Brushes.Green;
				case MetroColorStyle.Lime:
					return Brushes.Lime;
				case MetroColorStyle.Teal:
					return Brushes.Teal;
				case MetroColorStyle.Orange:
					return Brushes.Orange;
				case MetroColorStyle.Brown:
					return Brushes.Brown;
				case MetroColorStyle.Pink:
					return Brushes.Pink;
				case MetroColorStyle.Magenta:
					return Brushes.Magenta;
				case MetroColorStyle.Purple:
					return Brushes.Purple;
				case MetroColorStyle.Red:
					return Brushes.Red;
				case MetroColorStyle.Yellow:
					return Brushes.Yellow;
				case MetroColorStyle.Default:
					return Brushes.Orange;
			}

			return Brushes.Orange;
		}
	}
}