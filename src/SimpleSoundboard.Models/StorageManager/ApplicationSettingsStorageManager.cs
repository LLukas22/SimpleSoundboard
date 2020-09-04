
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Models.Base;
using SimpleSoundboard.NameService.Models;
using Soundboard.Entities;

namespace SimpleSoundboard.Interfaces.Models.StorageManager
{
	public class ApplicationSettingsStorageManager : AbstractBaseStorageManager<IApplicationSettingsModel>, IApplicationSettingsStorageManager
	{
		public ApplicationSettingsStorageManager(string path) : base(path)
		{
			fileName = "ApplicationSettings";
		}

		protected override IApplicationSettingsModel ReturnDefault()
		{
			return new ApplicationSettingsModel()
			{
				AccentColor = ApplicationAccentColor.Orange,
				InputDevice = null,
				OutputDevices = new List<string>() {String.Empty,String.Empty},
				StopKeys = new List<Keys>(){Keys.Back},
				Style = ApplicationStyle.Dark,
				Volumes = new List<float>(){0.5f,0.5f}
			};
		}
	}
}
