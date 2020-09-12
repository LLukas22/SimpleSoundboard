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
		private readonly Dictionary<int, string> mappedOutputDevices;
		private readonly Dictionary<string, int> outputDevices;
		private readonly int outputIndex;
		private float externalVolume;
		private CancellationTokenSource tokenSource;
		private CancellationToken token;
		private readonly ConcurrentDictionary<string,AudioFileReader> fileReaders = new ConcurrentDictionary<string, AudioFileReader>();
		private readonly ConcurrentDictionary<string, WaveOutEvent> waveOutEvents = new ConcurrentDictionary<string, WaveOutEvent>();
		private readonly ConcurrentDictionary<string, float> volumeModifiers = new ConcurrentDictionary<string, float>();


		public OutStreamController(ref  Dictionary<int, string> mappedOutputDevices,ref Dictionary<string, int> outputDevices,int outputIndex, float defaultVolume = 0.5f)
		{
		
			this.mappedOutputDevices = mappedOutputDevices;
			this.outputDevices = outputDevices;
			this.outputIndex = outputIndex;
			this.externalVolume = defaultVolume;
			this.tokenSource = new CancellationTokenSource();
			token = tokenSource.Token;
		}
		

		public void Play(string audioFile, float volumeModifier = 1)
		{

			int outputDevice = Int32.MinValue;
			

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

			var guid = Guid.NewGuid().ToString("N").Substring(0, 8);

			Task.Run(() =>
			{
				var fileReader = new AudioFileReader(audioFile);
				fileReader.Volume = externalVolume * volumeModifier;
				var waveOutEvent = new WaveOutEvent {DeviceNumber = outputDevice};
				waveOutEvent.PlaybackStopped += (sender, e) => WaveOutEventOnPlaybackStopped(sender, e, guid);
				waveOutEvent.Init(fileReader);
				fileReaders.TryAdd(guid, fileReader);
				waveOutEvents.TryAdd(guid, waveOutEvent);
				volumeModifiers.TryAdd(guid, volumeModifier);
				waveOutEvent.Play();
			}, token).ContinueWith((task) =>
			{
				if (task.IsFaulted)
					ThrowException(task.Exception);
			},token);
		}

		private void ThrowException(Exception exception)
		{
			throw exception;
		}

		public void ChangeVolume(float volume)
		{
			externalVolume = volume;
			foreach (var id in fileReaders.Keys)
			{
				fileReaders[id].Volume = externalVolume * volumeModifiers[id];
			}
		}

		public void Stop()
		{
			tokenSource.Cancel();

			foreach (var waveOutEvent in waveOutEvents)
			{
				waveOutEvent.Value.Stop();
			}
			fileReaders.Clear();
			waveOutEvents.Clear();
			volumeModifiers.Clear();

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
			DisposeAndRemove(volumeModifiers, id);
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

	
