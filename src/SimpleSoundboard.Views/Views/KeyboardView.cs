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

		private void KeyboardControllerOnKeyReleased(object sender, IKeyEventArgs e)
		{
			if(e is RawInputEventArgs rawArgs)
			{
                customMetroTextBox_DeviceName.Text = rawArgs.KeyPressEvent.DeviceName;
                customMetroTextBox_DeviceType.Text = rawArgs.KeyPressEvent.DeviceType;
                customMetroTextBox_Key.Text = rawArgs.KeyCode.ToString();
                customMetroTextBox_Name.Text = rawArgs.KeyPressEvent.Name;
            }
		}
	}
}