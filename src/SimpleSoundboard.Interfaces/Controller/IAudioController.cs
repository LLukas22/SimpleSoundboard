using System.Collections.Generic;
using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;

namespace SimpleSoundboard.Interfaces.Controller
{
	public interface IAudioController : IModelController<IAudioView, IAudioEntryModel>
	{
		bool ValidateKeyCombo(List<Keys> keyCombo);
	}
}