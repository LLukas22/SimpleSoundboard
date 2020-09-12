using System;
using System.Windows.Forms;

namespace SimpleSoundboard.Keyboard.NameService
{
	public class RawInputEventArgs : EventArgs
	{
		public RawInputEventArgs(KeyPressEvent arg)
		{
			KeyPressEvent = arg;
			Id = Guid.NewGuid().ToString("N").Substring(0, 8);
		}

		public KeyPressEvent KeyPressEvent { get; }
		public string Id { get; }
		public Keys KeyCode => (Keys) KeyPressEvent.VKey;
		public string UniqueName => $"{KeyPressEvent.Name}[{KeyPressEvent.DeviceName}]";
	}
}