using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Models.Base;

namespace SimpleSoundboard.Interfaces.Models.Models
{
	public interface IAudioEntryModel : IBaseModel, IEquatable<IAudioEntryModel>
	{
		List<Keys> KeyBinding { get; set; }
		string KeyboardName { get; set; }
		bool UseSpecificKeyboard { get; set; }
		string FilePath { get; set; }
		float Volume { get; set; }
	}
}