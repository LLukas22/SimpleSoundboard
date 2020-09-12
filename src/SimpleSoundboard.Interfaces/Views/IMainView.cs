using System.Collections.Generic;
using System.Windows.Forms;
using NAudio.Gui;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Interfaces.Views
{
	public interface IMainView : IView
	{
		object OutputDevice1DataSource { get; set; }
		object OutputDevice2DataSource { get; set; }
		VolumeSlider VolumeSlider1 { get; }
		VolumeSlider VolumeSlider2 { get; }
		IMainView SetOutputDevice2(string value);
		IMainView SetOutputDevice1(string value);
		IMainView SetVolumeSliderValue(int outputDevice, float value);
		IMainView SetStopButtonText(List<Keys> combo);
		IMainView RefreshGrid(List<IAudioEntryModel> audioEntries);
	}
}