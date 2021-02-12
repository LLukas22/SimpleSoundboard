using NAudio.Wave;
using SimpleSoundboard.Interfaces.Logger;
using SimpleSoundboard.NameService.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSoundboard.NAudio
{
	public class OutStreamController
	{
		private readonly ConcurrentDictionary<string, AudioFileReader> fileReaders =
			new ConcurrentDictionary<string, AudioFileReader>();

		private readonly Dictionary<int, string> mappedOutputDevices;
		private readonly Dictionary<string, int> outputDevices;
		private readonly int outputIndex;
		private readonly ILogger logger;

		private readonly ConcurrentDictionary<string, float>
			volumeModifiers = new ConcurrentDictionary<string, float>();

		private readonly ConcurrentDictionary<string, WaveOutEvent> waveOutEvents =
			new ConcurrentDictionary<string, WaveOutEvent>();

		private float externalVolume;
		private CancellationToken token;
		private CancellationTokenSource tokenSource;


		public OutStreamController(ref Dictionary<int, string> mappedOutputDevices,
			ref Dictionary<string, int> outputDevices, int outputIndex, ILogger logger, float defaultVolume = 0.5f)
		{
			this.mappedOutputDevices = mappedOutputDevices;
			this.outputDevices = outputDevices;
			this.outputIndex = outputIndex;
			this.logger = logger;
			externalVolume = defaultVolume;
			tokenSource = new CancellationTokenSource();
			token = tokenSource.Token;
		}


		public void Play(string audioFile, float volumeModifier = 1)
		{
			try
			{
				var outputDevice = int.MinValue;

				if (mappedOutputDevices.ContainsKey(outputIndex))
					if (outputDevices.ContainsKey(mappedOutputDevices[outputIndex]))
						outputDevice = outputDevices[mappedOutputDevices[outputIndex]];
				//outputDevice is None or wasn't found
				if (outputDevice == int.MinValue)
					return;

				var guid = Guid.NewGuid().ToString("N").Substring(0, 8);

				Task.Run(() =>
				{
					var fileReader = new AudioFileReader(audioFile) { Volume = externalVolume * volumeModifier };
					var waveOutEvent = new WaveOutEvent { DeviceNumber = outputDevice };
					waveOutEvent.PlaybackStopped += (sender, e) => WaveOutEventOnPlaybackStopped(sender, e, guid);
					waveOutEvent.Init(fileReader);
					fileReaders.TryAdd(guid, fileReader);
					waveOutEvents.TryAdd(guid, waveOutEvent);
					volumeModifiers.TryAdd(guid, volumeModifier);
					waveOutEvent.Play();
				}, token).ContinueWith(task =>
				{
					if (task.IsFaulted)
						logger.Log($"[OutStreamController(outputIndex)] PlayTask for '{audioFile}' failed!", task.Exception, LogLevels.Error);

				}, token);
			}
			catch (Exception exception)
			{
				logger.Log($"Encountered error while trying to play {audioFile}!", exception, LogLevels.Error);
			}

		}

		public void ChangeVolume(float volume)
		{
			try
			{
				externalVolume = volume;
				foreach (var id in fileReaders.Keys) fileReaders[id].Volume = externalVolume * volumeModifiers[id];
			}
			catch (Exception exception)
			{
				logger.Log($"Encountered error while changing volume!", exception, LogLevels.Error);
			}

		}

		public void Stop()
		{
			try
			{
				tokenSource.Cancel();

				foreach (var waveOutEvent in waveOutEvents)
					waveOutEvent.Value.Stop();

				fileReaders.Clear();
				waveOutEvents.Clear();
				volumeModifiers.Clear();
			}
			catch (Exception exception)
			{
				logger.Log($"Encountered error while stopping!", exception, LogLevels.Error);
			}
			finally
			{
				//create new CancellationTokenSource
				tokenSource = new CancellationTokenSource();
				token = tokenSource.Token;
			}


		}


		private void WaveOutEventOnPlaybackStopped(object? sender, StoppedEventArgs e, string id)
		{
			try
			{
				RemoveViaId(id);
			}
			catch (Exception exception)
			{
				logger.Log($"Encountered Error while clearing waveoutevent {id}!", exception, LogLevels.Error);
			}
		}

		private readonly object balanceLock = new object();

		private void RemoveViaId(string id)
		{

			DisposeAndRemove(waveOutEvents, id);
			DisposeAndRemove(volumeModifiers, id);
			DisposeAndRemove(fileReaders, id);

			if (waveOutEvents.Count == 0 || volumeModifiers.Count == 0 || fileReaders.Count == 0)
			{
				waveOutEvents.Clear();
				volumeModifiers.Clear();
				fileReaders.Clear();

				GC.Collect();
				GC.WaitForPendingFinalizers();
			}

		}


		private void DisposeAndRemove<TType>(ConcurrentDictionary<string, TType> dictionary, string id)
		{
			lock (balanceLock)
			{
				if (!dictionary.ContainsKey(id)) return;
				if (dictionary[id] is IDisposable disposable)
					disposable.Dispose();
				dictionary.TryRemove(id, out _);
			}
		}
	}
}