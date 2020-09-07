﻿

using System.Collections.Generic;
using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Models.Models;

namespace Soundboard.Entities
{
	public class AudioEntryModel : AbstractBaseModel, IAudioEntryModel
	{
		private List<Keys> keyBinding;

		private string keyboardName;

		private bool useDefaultKeyboard;

		private string filePath;

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

		public bool UseDefaultKeyboard
		{
			get => useDefaultKeyboard;
			set => SetProperty(ref useDefaultKeyboard, value);
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

	}
}