using System.Collections.Generic;
using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Models.Base;
using SimpleSoundboard.NameService.Models;

namespace SimpleSoundboard.Interfaces.Models.Models
{
	public interface IApplicationSettingsModel : IBaseModel
	{
		ApplicationAccentColor AccentColor { get; set; }
		ApplicationStyle Style { get; set; }
		string InputDevice { get; set; }
		List<string> OutputDevices { get; set; }
		List<Keys> StopKeys { get; set; }
		List<float> Volumes { get; set; }
	}
}