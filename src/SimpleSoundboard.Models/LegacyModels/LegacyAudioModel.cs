using System.Windows.Forms;

namespace SimpleSoundboard.Models.LegacyModels
{
	public class LegacyAudioModel
	{
		public (Keys FirstKey, Keys SecondKey, Keys ThirdKey) KeyBinding { get; set; }
		public string PathToFile { get; set; }
		public string KeyboardName { get; set; }
		public float Volume { get; set; }
	}
}