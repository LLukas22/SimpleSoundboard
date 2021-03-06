﻿using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;

namespace SimpleSoundboard.Interfaces.Controller
{
	public interface IAudioController : IModelController<IAudioView, IAudioEntryModel>
	{
		IAudioEntryModel ValidateKeyCombo(IAudioEntryModel model);
	}
}