using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using SimpleSoundboard.Controller.Base;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.Keyboard;
using Unity;

namespace SimpleSoundboard.Controller
{
	public class AudioController : AbstractModelController<IAudioView,IAudioEntryModel>, IAudioController
	{
		[Dependency] public IRepositoryManager RepositoryManager { get; set; }

		public AudioController(IAudioView view) : base(view)
		{

		}

		public override IController<IAudioView> Initialize()
		{
			SpecificView.BindData(ref model, clone);
			return base.Initialize();
		}

		public bool ValidateKeyCombo(List<Keys> keyCombo)
		{
			if (RepositoryManager.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).GetDictionary().Values
				.Any(x => x.KeyBinding.CustomEquals(keyCombo))) return false;
			return true;
		}
	}
}
