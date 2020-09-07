using System.ComponentModel;
using System.Windows.Forms;
using NAudio.Gui;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Interfaces.Views
{
	public interface IMainView : IView
	{
		BindingList<IAudioEntryModel> GridBindingSource { get; set; }
		object OutputDevice1DataSource { get; set; }
		object OutputDevice2DataSource { get; set; }
		IMainView SetOutputDevice2(string value);
		IMainView SetOutputDevice1(string value);
		VolumeSlider VolumeSlider1 { get; }
		VolumeSlider VolumeSlider2 { get; }
		IMainView SetVolumeSliderValue(int outputDevice, float value);
	}
}