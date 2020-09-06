using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Gui;
using NAudio.Wave;

namespace SimpleSoundboard.NAudio
{
	public class OutStreamController
	{
		private readonly Dictionary<int, VolumeSlider> mappedVolumeSliders;
		private readonly Dictionary<int, string> mappedOutputDevices;
		private readonly Dictionary<string, int> outputDevices;
		private readonly int outputIndex;
		private CancellationTokenSource tokenSource;
		private CancellationToken token;
		private readonly ConcurrentDictionary<string,AudioFileReader> fileReaders = new ConcurrentDictionary<string, AudioFileReader>();
		private readonly ConcurrentDictionary<string, WaveOutEvent> waveOutEvents = new ConcurrentDictionary<string, WaveOutEvent>();
		private readonly ConcurrentDictionary<string, Action<float>> volumeDelegates = new ConcurrentDictionary<string, Action<float>>();


		public OutStreamController(ref Dictionary<int, VolumeSlider> mappedVolumeSliders,ref  Dictionary<int, string> mappedOutputDevices,ref Dictionary<string, int> outputDevices,int outputIndex)
		{
			this.mappedVolumeSliders = mappedVolumeSliders;
			this.mappedOutputDevices = mappedOutputDevices;
			this.outputDevices = outputDevices;
			this.outputIndex = outputIndex;
			this.tokenSource = new CancellationTokenSource();
			token = tokenSource.Token;
		}
		

		public void Play(string audioFile, float volumeModifier = 1)
		{

			int outputDevice = Int32.MinValue;
			VolumeSlider volumeSlider = null;

			if (mappedOutputDevices.ContainsKey(outputIndex))
			{
				if (outputDevices.ContainsKey(mappedOutputDevices[outputIndex]))
				{
					outputDevice = outputDevices[mappedOutputDevices[outputIndex]];
				}
			}
			//outputDevice is None or wasn't found
			if (outputDevice == Int32.MinValue)
				return;

			if (mappedVolumeSliders.ContainsKey(outputIndex))
				volumeSlider = mappedVolumeSliders[outputIndex];

			var guid = Guid.NewGuid().ToString("N").Substring(0, 8);

			Task.Run(() =>
			{
				var fileReader = new AudioFileReader(audioFile);
				Action<float> volumeDelegate = vol => fileReader.Volume = vol;
				volumeDelegate?.Invoke(volumeSlider?.Volume ?? 0.5f * volumeModifier);
				var waveOutEvent = new WaveOutEvent {DeviceNumber = outputDevice};
				waveOutEvent.PlaybackStopped += (sender, e) => WaveOutEventOnPlaybackStopped(sender, e, guid);
				waveOutEvent.Init(fileReader);
				fileReaders.TryAdd(guid, fileReader);
				waveOutEvents.TryAdd(guid, waveOutEvent);
				volumeDelegates.TryAdd(guid, volumeDelegate);
				waveOutEvent.Play();
			}, token);
		}

		public void Stop()
		{
			tokenSource.Cancel();

			foreach (var id in waveOutEvents.Keys)
			{
				waveOutEvents[id].Stop();
			}
			fileReaders.Clear();
			waveOutEvents.Clear();
			volumeDelegates.Clear();

			tokenSource = new CancellationTokenSource();
			token = tokenSource.Token;
		}
		

		private void WaveOutEventOnPlaybackStopped(object? sender, StoppedEventArgs e, string id)
		{
			RemoveViaId(id);
		}

		private void RemoveViaId(string id)
		{
			DisposeAndRemove(waveOutEvents, id);
			DisposeAndRemove(volumeDelegates, id);
			DisposeAndRemove(fileReaders, id);
		}

		private void DisposeAndRemove<TType>(ConcurrentDictionary<string,TType> dictionary, string id)
		{
			if (!dictionary.ContainsKey(id)) return;
			if(dictionary[id] is IDisposable disposable)
				disposable.Dispose();
			dictionary.TryRemove(id,out _);
		}
	}
}

	
