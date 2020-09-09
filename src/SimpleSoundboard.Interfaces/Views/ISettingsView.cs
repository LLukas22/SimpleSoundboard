using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Interfaces.Views
{
	public interface ISettingsView : IView
	{
		void BindData(IApplicationSettingsModel model);
	}
}