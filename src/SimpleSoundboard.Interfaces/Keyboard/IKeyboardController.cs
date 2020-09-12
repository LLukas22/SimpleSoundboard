using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleSoundboard.Keyboard.NameService;

namespace SimpleSoundboard.Interfaces.Keyboard
{
	public interface IKeyboardController
	{
		delegate void KeyReleasedHandler(object sender, RawInputEventArgs e);

		void RegisterKeyAction(IEnumerable<Keys> keys, Action action, string keyboard = null);
		IKeyboardController BindToForm(Form form, bool captureOnlyInForeground = false);
		IKeyboardController RegisterPriorityAction(IEnumerable<Keys> keys, Action action);
		void ClearKeyActions();
		void Continue();
		void Pause();
		event KeyReleasedHandler OnKeyReleased;
	}
}