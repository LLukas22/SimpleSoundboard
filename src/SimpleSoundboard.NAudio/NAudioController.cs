using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NAudio.Gui;
using NAudio.Wave;
using SimpleSoundboard.NameService.NAudio;
using Soundboard.Audio;

namespace SimpleSoundboard.NAudio
{
	public class NAudioController : INAudioController
	{
		private readonly int outputChannelCount;
		private readonly Dictionary<int, string> mappedOutputDevices;
		private Dictionary<string, int> outputDevices;
		private readonly List<OutStreamController> outStreamController;

		public NAudioController(int outputChannels = 2)
		{
			outputChannelCount = outputChannels;
			GetWaveOutCapabilities();
			mappedOutputDevices = new Dictionary<int, string>(outputChannelCount);
			outStreamController = new List<OutStreamController>(outputChannelCount);
			for (int i = 0; i < outputChannelCount; i++)
			{
				outStreamController.Add(new OutStreamController(ref mappedOutputDevices,ref outputDevices,i));
			}
			outputDevices = new Dictionary<string, int>();
		}

		public Dictionary<string, int> GetWaveOutCapabilities()
		{
			Stop(false);
			outputDevices = new Dictionary<string, int>();
			outputDevices.Add(NAudioControllerConstants.NoneDevice, NAudioControllerConstants.NoneDeviceId);
			outputDevices.Add(NAudioControllerConstants.SoundMapper, -1);
			for (var n = 0; n < WaveOut.DeviceCount; n++)
			{
				var capability = WaveOut.GetCapabilities(n);
				outputDevices.Add(WaveOut.GetCapabilities(n).ProductName,n);
			}
			return outputDevices;
		}

		public INAudioController RegisterOutputDevice(int outputChannel, string deviceName)
		{
			Stop(false);
			if (mappedOutputDevices.ContainsKey(outputChannel))
			{
				mappedOutputDevices[outputChannel] = deviceName;
			}
			else
			{
				mappedOutputDevices.Add(outputChannel, deviceName);
			}
			return this;
		}

		public INAudioController ChangeVolume(int outputChannel, float volume)
		{
			outStreamController[outputChannel].ChangeVolume(volume);
			return this;
		}

		public INAudioController Play(string audioFile, float volumeModifier = 1)
		{
			if (string.IsNullOrEmpty(audioFile))
			{
				throw new ArgumentException($"[{this.GetType().Name}] AudioFile can't be empty!");
			}

			if (!File.Exists(audioFile))
			{
				throw new ArgumentException($"[{this.GetType().Name}] Cant find AudioFile {audioFile}!");
			}

			foreach (var controller in outStreamController)
				controller.Play(audioFile, volumeModifier);
			
			return this;
		}

		public INAudioController Stop(bool collectGarbage = true)
		{
			foreach (var controller in outStreamController ?? new List<OutStreamController>())
				controller.Stop();
			if (collectGarbage)
			{
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
			return this;
		}
	}
}