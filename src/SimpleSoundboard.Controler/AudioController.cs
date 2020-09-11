using SimpleSoundboard.Controller.Base;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;

namespace SimpleSoundboard.Controller
{
	public class AudioController : AbstractModelController<IAudioView,IAudioEntryModel>, IAudioController
	{
		public AudioController(IAudioView view) : base(view)
		{

		}

		public override IController<IAudioView> Initialize()
		{
			SpecificView.BindData(ref model, clone);
			return base.Initialize();
		}
	}
}
