using SimpleSoundboard.Controller.Base;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Interfaces.Views;
using Unity;

namespace SimpleSoundboard.Controller
{
	public class KeyboardDebugController : AbstractBaseController<IKeyboardView>, IKeyboardDebugController
	{
		public KeyboardDebugController(IKeyboardView view) : base(view)
		{
		}

		[Dependency] public IKeyboardController KeyboardController { get; set; }

		public override IController<IKeyboardView> Initialize()
		{
			SpecificView.WithKeyboardController(KeyboardController);
			return base.Initialize();
		}
	}
}