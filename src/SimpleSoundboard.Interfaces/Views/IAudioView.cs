using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Interfaces.Views
{
	public interface IAudioView : IView
	{
		IAudioView BindData(ref IAudioEntryModel original, IAudioEntryModel clone);
		IAudioView WithKeyboardController(IKeyboardController keyboardController);
	}
}