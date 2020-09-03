using System;
using System.Windows.Forms;

namespace Soundboard.RawInput
{
	public class RawInputEventArg : EventArgs
	{
		public RawInputEventArg(KeyPressEvent arg)
		{
			KeyPressEvent = arg;
		}

		public KeyPressEvent KeyPressEvent { get; }

		public string Hash => KeyPressEvent.DeviceName.GetHashCode().ToString();
		public Keys KeyCode => (Keys) KeyPressEvent.VKey;
	}
}