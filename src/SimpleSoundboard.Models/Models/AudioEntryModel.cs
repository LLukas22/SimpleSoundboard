using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Keyboard;

namespace Soundboard.Entities
{
	public class AudioEntryModel : AbstractBaseModel, IAudioEntryModel
	{
		private string filePath;
		private List<Keys> keyBinding;

		private string keyboardName;

		private bool useSpecificKeyboard;

		private float volume = 1;

		public List<Keys> KeyBinding
		{
			get => keyBinding;
			set => SetProperty(ref keyBinding, value);
		}

		public string KeyboardName
		{
			get => keyboardName;
			set => SetProperty(ref keyboardName, value);
		}

		public bool UseSpecificKeyboard
		{
			get => useSpecificKeyboard;
			set => SetProperty(ref useSpecificKeyboard, value);
		}

		public string FilePath
		{
			get => filePath;
			set => SetProperty(ref filePath, value);
		}

		public float Volume
		{
			get => volume;
			set => SetProperty(ref volume, value);
		}

		public bool Equals(IAudioEntryModel other)
		{
			if (other == null) return false;
			if (KeyBinding.CustomEquals(other.KeyBinding))
			{
				if (UseSpecificKeyboard != other.UseSpecificKeyboard) return false;
				if (UseSpecificKeyboard && other.UseSpecificKeyboard)
					return KeyboardName.Equals(other.KeyboardName, StringComparison.OrdinalIgnoreCase);
				return true;
			}

			return false;
		}
	}
}