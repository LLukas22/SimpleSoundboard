using SimpleSoundboard.Controller.Base;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Root;
using SimpleSoundboard.Interfaces.Views;
using Unity;

namespace SimpleSoundboard.Controller
{
	public class SettingsController : AbstractModelController<ISettingsView, IApplicationSettingsModel>,
		ISettingsController
	{
		public SettingsController(ISettingsView view) : base(view)
		{
		}

		[Dependency] public IControllerFactory ControllerFactory { get; set; }

		public override IController<ISettingsView> Initialize()
		{
			SpecificView.BindData(ref model, clone);
			return base.Initialize();
		}

		public void ShowKeyboardView()
		{
			((IKeyboardDebugController) ControllerFactory.Create(typeof(IKeyboardDebugController))).Initialize()
				.ShowDialogue(this);
		}
	}
}