using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Interfaces.Views
{
	public interface IKeyboardView : IView
	{
		IKeyboardView WithKeyboardController(IKeyboardController keyboardController);
	}
}