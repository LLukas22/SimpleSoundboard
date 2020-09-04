using System.Collections.Generic;
using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.NameService.Models;


namespace Soundboard.Entities
{
	public class ApplicationSettingsModel : AbstractBaseModel, IApplicationSettingsModel
	{
		private ApplicationAccentColor accentColor;
		private ApplicationStyle style;

		private string inputDevice;
		private List<string> outputDevices;
		private List<Keys> stopKeys;
		private List<float> volumes;


		public ApplicationAccentColor AccentColor
		{
			get => accentColor;
			set => SetProperty(ref accentColor, value);
		}

		public ApplicationStyle Style
		{
			get => style;
			set => SetProperty(ref style, value);
		}

		public string InputDevice
		{
			get => inputDevice;
			set => SetProperty(ref inputDevice, value);
		}

		public List<string> OutputDevices
		{
			get => outputDevices;
			set => SetProperty(ref outputDevices, value);
		}

		public List<Keys> StopKeys
		{
			get => stopKeys;
			set => SetProperty(ref stopKeys, value);
		}

		public List<float> Volumes
		{
			get => volumes;
			set => SetProperty(ref volumes, value);
		}


	}
}