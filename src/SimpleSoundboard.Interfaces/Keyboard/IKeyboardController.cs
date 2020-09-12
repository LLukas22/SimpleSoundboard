using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleSoundboard.Interfaces.Keyboard
{
	public interface IKeyboardController
	{
		void RegisterKeyAction(IEnumerable<Keys> keys, Action action, string keyboard = null);
		IKeyboardController BindToForm(Form form, bool captureOnlyInForeground = false);
		IKeyboardController RegisterPriorityAction(IEnumerable<Keys> keys, Action action);
		void ClearKeyActions();
		void Continue();
		void Pause();
	}
}