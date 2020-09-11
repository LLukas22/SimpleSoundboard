using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimpleSoundboard.Keyboard
{
	public static class KeysExtensions
	{
		public static string ToStringAdded(this List<Keys> keys)
		{
			var result = string.Empty;
			if (keys == null) return result;
			for (int i = 0; i < keys.Count(); i++)
			{
				if (i == keys.Count() - 1)
					result += $"{keys[i]}";
				else
					result += $"{keys[i]} +";
			}
			return result;
		}

		public static bool CustomEquals(this List<Keys> x, List<Keys> y)
		{
			if (x != null && y == null) return false;
			if (x == null && y != null) return false;
			if (x.Count != y.Count) return false;
			for (int i = 0; i < x.Count; i++)
			{
				if (x[i] != y[i])
					return false;
			}
			return true;
		}

		public static bool In(this List<Keys> x, List<Keys> y)
		{
			if (x != null && y == null) return false;
			if (x == null && y != null) return false;
			if (x.Count > y.Count) return false;

			for (int i = 0; i < y.Count; i++)
			{
				if (y[i] == x[0])
				{
					for (int xi = 0; xi <= x.Count; xi++)
					{
						if (xi == x.Count) return true;
						if (y[i + xi] != x[xi]) break;
					}
				}
			}
			return false;
		}

		
	}
}
