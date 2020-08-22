using MetroFramework.Forms;
using Soundboard.RawInput;

namespace Soundboard.Views
{
	public partial class DebugForm : MetroForm
	{
		public DebugForm(RawInput.RawInput rawInput)
		{
			rawInput.KeyPressed += RawInputOnKeyPressed;
			Globals.styleManager.Clone(this);
			InitializeComponent();
		}

		private void RawInputOnKeyPressed(object sender, RawInputEventArg e)
		{
			Hash.Text = e.Hash;
			Info.Text = e.KeyPressEvent.DeviceName;
			KeyboardName.Text = e.KeyPressEvent.Name;
			Key.Text = e.KeyCode.ToString();
		}
	}
}