using System.Collections.Generic;
using NAudio.Gui;

namespace Soundboard.Audio
{
	public interface INAudioController
	{
		Dictionary<string, int> GetWaveOutCapabilities();
		INAudioController RegisterVolumeSlider(int outputChannel, VolumeSlider volumeSlider);
		INAudioController RegisterOutputDevice(int outputChannel, string deviceName);
		INAudioController Play(string audioFile, float volumeModifier = 1);
		INAudioController Stop(bool collectGarbage = true);
	}
}