using System;
using System.Windows.Forms;

namespace Soundboard.RawInput
{
	public class RawInputEventArg : EventArgs
	{
		public RawInputEventArg(KeyPressEvent arg)
		{
			KeyPressEvent = arg;
			Id = Guid.NewGuid().ToString("N").Substring(0, 8);
		}

		public KeyPressEvent KeyPressEvent { get; }
		public string Id { get; private set; }
		public Keys KeyCode => (Keys) KeyPressEvent.VKey;
	}
}