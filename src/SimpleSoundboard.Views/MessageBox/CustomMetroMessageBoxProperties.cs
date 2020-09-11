

using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework;

namespace SimpleSoundboard.Views.MessageBox
{
	public class CustomMetroMessageBoxProperties
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CustomMetroMessageBoxControl _owner;

		public CustomMetroMessageBoxProperties(CustomMetroMessageBoxControl owner) => this._owner = owner;

		public MessageBoxButtons Buttons { get; set; }

		public MessageBoxDefaultButton DefaultButton { get; set; }

		public MessageBoxIcon Icon { get; set; }

		public string Message { get; set; }

		public CustomMetroMessageBoxControl Owner => this._owner;

		public string Title { get; set; }

	}
}
