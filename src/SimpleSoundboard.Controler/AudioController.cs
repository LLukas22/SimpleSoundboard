using System.Linq;
using SimpleSoundboard.Controller.Base;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;
using Unity;

namespace SimpleSoundboard.Controller
{
	public class AudioController : AbstractModelController<IAudioView, IAudioEntryModel>, IAudioController
	{
		public AudioController(IAudioView view) : base(view)
		{
		}

		[Dependency] public IRepositoryManager RepositoryManager { get; set; }
		[Dependency] public IKeyboardController KeyboardController { get; set; }

		public override IController<IAudioView> Initialize()
		{
			SpecificView.WithKeyboardController(KeyboardController).BindData(ref model, clone);
			return base.Initialize();
		}

		public IAudioEntryModel ValidateKeyCombo(IAudioEntryModel model)
		{
			return RepositoryManager.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).GetDictionary().Values
				.FirstOrDefault(x => x.Equals(model));
		}
	}
}