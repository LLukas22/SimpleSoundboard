using System;
using System.Windows.Forms;

namespace SimpleSoundboard.Keyboard.NameService
{
	public interface IKeyEventArgs
	{
        public Keys KeyCode { get; }
        public KeyState KeyState { get; }
		string UniqueName { get; }
	}
	public class RawInputEventArgs : EventArgs, IKeyEventArgs
    {
		public RawInputEventArgs(KeyPressEvent arg)
		{
			KeyPressEvent = arg;
			Id = Guid.NewGuid().ToString("N").Substring(0, 8);
		}

		public KeyPressEvent KeyPressEvent { get; }
		public string Id { get; }
		public Keys KeyCode => (Keys) KeyPressEvent.VKey;
        public KeyState KeyState => KeyPressEvent.KeyState;
        public string UniqueName => $"{KeyPressEvent.Name}[{KeyPressEvent.DeviceName}]";
	}
}