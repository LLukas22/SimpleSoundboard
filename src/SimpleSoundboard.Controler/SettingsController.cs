using SimpleSoundboard.Controller.Base;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;

namespace SimpleSoundboard.Controller
{
	public class SettingsController : AbstractModelController<ISettingsView,IApplicationSettingsModel>, ISettingsController
	{
		public SettingsController(ISettingsView view) : base(view)
		{

		}

		public override IController<ISettingsView> Initialize()
		{
			SpecificView.BindData(clone);
			return base.Initialize();
		}
	}
}
