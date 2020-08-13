using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NAudio.Gui;
using NAudio.Wave;
using Soundboard.Entities;

namespace Soundboard.Audio
{
	public class NAudioController
	{
		private readonly List<(AudioFileReader, AudioFileReader)> audiofiles =
			new List<(AudioFileReader, AudioFileReader)>();

		private (int OutputDevice1, int OutputDevice2) OutputDevices;
		private readonly List<Thread> Threads = new List<Thread>();
		public List<(Action<float>, Action<float>)> VolumeDelegates = new List<(Action<float>, Action<float>)>();
		private readonly (VolumeSlider slider1, VolumeSlider slider2) volumesliders;
		private readonly List<(WaveOutEvent, WaveOutEvent)> WaveoutEvents = new List<(WaveOutEvent, WaveOutEvent)>();

		public NAudioController(VolumeSlider slider1, VolumeSlider slider2)
		{
			volumesliders.slider1 = slider1;
			volumesliders.slider2 = slider2;
		}

		public void SetOutputDevices(int OutputDevice1, int OutputDevice2)
		{
			OutputDevices.OutputDevice1 = OutputDevice1;
			OutputDevices.OutputDevice2 = OutputDevice2;
			StopPlayback();
		}

		private void CreateStream(AudioFileEntity InputFile)
		{
			if (InputFile != null)
			{
				var newTuppleWaveout = (new WaveOutEvent {DeviceNumber = OutputDevices.OutputDevice1},
					new WaveOutEvent {DeviceNumber = OutputDevices.OutputDevice2});
				newTuppleWaveout.Item1.PlaybackStopped += OnPlaybackStopped;

				var newTuppleAudioReader = (new AudioFileReader(InputFile.PathToFile), new AudioFileReader(InputFile.PathToFile));
				var File1 = newTuppleAudioReader.Item1;
				Action<float> Volume1 = vol => File1.Volume = vol;
				var File2 = newTuppleAudioReader.Item2;
				Action<float> Volume2 = vol => File2.Volume = vol;
				var newTuppleVolumeDelgate = (Volume1, Volume2);
				newTuppleVolumeDelgate.Volume1?.Invoke(volumesliders.slider1.Volume*InputFile.Volume);
				newTuppleVolumeDelgate.Volume2?.Invoke(volumesliders.slider2.Volume*InputFile.Volume);
				newTuppleWaveout.Item1.Init(newTuppleAudioReader.Item1);
				newTuppleWaveout.Item2.Init(newTuppleAudioReader.Item2);
				newTuppleWaveout.Item1.Play();
				newTuppleWaveout.Item2.Play();
				WaveoutEvents.Add(newTuppleWaveout);
				audiofiles.Add(newTuppleAudioReader);
				VolumeDelegates.Add(newTuppleVolumeDelgate);
			}
		}

		private void DestroyStreams()
		{
			try
			{
				foreach (var th in Threads) th.Abort();
				foreach (var tuple in WaveoutEvents)
				{
					tuple.Item1.Dispose();
					tuple.Item2.Dispose();
				}

				foreach (var tuple in audiofiles)
				{
					tuple.Item1.Dispose();
					tuple.Item2.Dispose();
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				Threads.Clear();
				WaveoutEvents.Clear();
				audiofiles.Clear();
				VolumeDelegates.Clear();
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}

		private void OnPlaybackStopped(object sender, StoppedEventArgs args)
		{
			try
			{
				var index = WaveoutEvents.FindIndex(o => o.Item1 == (WaveOutEvent) sender);
				if (index < 0 || index > WaveoutEvents.Count - 1 || index > audiofiles.Count - 1 ||
				    index > Threads.Count - 1) DestroyStreams();
				WaveoutEvents[index].Item1.Dispose();
				WaveoutEvents[index].Item2.Dispose();
				audiofiles[index].Item1.Dispose();
				audiofiles[index].Item1.Dispose();
				Threads[index].Abort();

				Threads.RemoveAt(index);
				WaveoutEvents.RemoveAt(index);
				audiofiles.RemoveAt(index);
				VolumeDelegates.RemoveAt(index);

				if (WaveoutEvents.Count == 0) DestroyStreams();
			}
			catch (Exception)
			{
			}
			finally
			{
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}

		public void StopPlayback()
		{
			foreach (var tuple in WaveoutEvents)
			{
				tuple.Item1.PlaybackStopped -= OnPlaybackStopped;
				tuple.Item1.Stop();
				tuple.Item2.Stop();
			}

			DestroyStreams();
		}

		public void StartPlayback(AudioFileEntity inputFile)
		{
			if (File.Exists(inputFile.PathToFile))
			{
				var TH = new Thread(() => CreateStream(inputFile));
				TH.Start();
				Threads.Add(TH);
			}
		}
	}
}