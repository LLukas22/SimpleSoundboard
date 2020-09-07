using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleSoundboard.Keyboard
{
	internal class KeysEqualityComparer : IEqualityComparer<List<Keys>>
	{
		public bool Equals(List<Keys> x, List<Keys> y)
		{
			return x.CustomEquals(y);
		}

		public int GetHashCode(List<Keys> obj)
		{
			
			return obj.ToStringAdded().GetHashCode();
		}
	}
}
