using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Interfaces.Views
{
	public interface IAudioView : IView
	{
		void BindData(ref IAudioEntryModel original, IAudioEntryModel clone);
	}
}