using MetroFramework.Components;
using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.Keyboard.NameService;
using SimpleSoundboard.Views.Base;

namespace SimpleSoundboard.Views.Views
{
	public partial class KeyboardView : BaseView, IKeyboardView
	{
		private IKeyboardController keyboardController;

		public KeyboardView(MetroStyleManager styleManager) : base(styleManager)
		{
			InitializeComponent();
		}

		public IKeyboardView WithKeyboardController(IKeyboardController keyboardController)
		{
			this.keyboardController = keyboardController;
			return this;
		}

		protected override void Subscribe()
		{
			keyboardController.OnKeyReleased += KeyboardControllerOnKeyReleased;
			base.Subscribe();
		}

		private void KeyboardControllerOnKeyReleased(object sender, RawInputEventArgs e)
		{
			customMetroTextBox_DeviceName.Text = e.KeyPressEvent.DeviceName;
			customMetroTextBox_DeviceType.Text = e.KeyPressEvent.DeviceType;
			customMetroTextBox_Key.Text = e.KeyCode.ToString();
			customMetroTextBox_Name.Text = e.KeyPressEvent.Name;
		}
	}
}