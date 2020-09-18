using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using SimpleSoundboard.Controller.Base;
using SimpleSoundboard.Extensions;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Interfaces.Logger;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.NAudio;
using SimpleSoundboard.Interfaces.Root;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.NameService.Logging;
using SimpleSoundboard.NameService.Models;
using SimpleSoundboard.Views.MessageBox;
using Soundboard.Entities;
using Unity;

namespace SimpleSoundboard.Controller
{
	public class MainController : AbstractBaseController<IMainView>, IMainController
	{
		private IApplicationSettingsModel activeApplicationSettings;

		public MainController(IMainView view) : base(view)
		{
		}

		[Dependency] public INAudioController NAudioController { get; set; }
		[Dependency] public IKeyboardController KeyboardController { get; set; }
		[Dependency] public IRepositoryManager RepositoryManager { get; set; }
		[Dependency] public IControllerFactory ControllerFactory { get; set; }
		[Dependency] public ILogger Logger { get; set; }
		[Dependency] public MetroStyleManager StyleManager { get; set; }

		public override IController<IMainView> Initialize()
		{
			activeApplicationSettings = RepositoryManager
				.Get<IApplicationSettingsModel>(typeof(IApplicationSettingsModel)).GetDictionary().Values.First();

			var waveOutCapabilities = NAudioController.GetWaveOutCapabilities();
			SpecificView.OutputDevice1DataSource = new List<string>(waveOutCapabilities.Keys);
			SpecificView.OutputDevice2DataSource = new List<string>(waveOutCapabilities.Keys);
			UpdateDataSource();
			SpecificView
				.SetOutputDevice1(activeApplicationSettings.OutputDevices[0])
				.SetOutputDevice2(activeApplicationSettings.OutputDevices[1])
				.SetVolumeSliderValue(0, activeApplicationSettings.Volumes[0])
				.SetVolumeSliderValue(1, activeApplicationSettings.Volumes[1])
				.SetStopButtonText(activeApplicationSettings.StopKeys);

			NAudioController
				.RegisterOutputDevice(0, activeApplicationSettings.OutputDevices[0])
				.RegisterOutputDevice(1, activeApplicationSettings.OutputDevices[1])
				.ChangeVolume(0, activeApplicationSettings.Volumes[0])
				.ChangeVolume(1, activeApplicationSettings.Volumes[1]);

			KeyboardController
				.BindToForm(SpecificView as Form)
				.RegisterPriorityAction(activeApplicationSettings.StopKeys, Stop);

			UpdateKeyboardController();
			return base.Initialize();
		}

		public void UpdateOutputDevice(int outputDevice, string value)
		{
			NAudioController.Stop();
			activeApplicationSettings.OutputDevices[outputDevice] = value;
			activeApplicationSettings.SetEntityState(EntityState.Modified);
			NAudioController.RegisterOutputDevice(outputDevice, activeApplicationSettings.OutputDevices[outputDevice]);
		}

		public void Save()
		{
			try
			{
				RepositoryManager.Save();
			}
			catch (Exception exception)
			{
				Logger.Log($"[{this.GetType().Name}] Failed Save!", exception,LogLevels.Error); 
			}
			
		}

		public void Play(Guid id)
		{
			if (id == Guid.Empty) return;
			if (RepositoryManager.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).GetDictionary().ContainsKey(id))
				Play(RepositoryManager.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).GetDictionary()[id]);
		}

		public void Stop()
		{
			NAudioController.Stop();
		}

		public void ChangeVolume(int outputDevice, float value)
		{
			activeApplicationSettings.Volumes[outputDevice] = value;
			activeApplicationSettings.SetEntityState(EntityState.Modified);
			NAudioController.ChangeVolume(outputDevice, activeApplicationSettings.Volumes[outputDevice]);

		}

		public void OpenSettings()
		{
			try
			{
				KeyboardController.Pause();
				var settingsController = (ISettingsController)ControllerFactory.Create(typeof(ISettingsController));
				settingsController.BindingData(activeApplicationSettings).Initialize().ShowDialogue(this);
				SpecificView.SetStopButtonText(activeApplicationSettings.StopKeys);
				StyleManager.Theme = activeApplicationSettings.Style.ToMetroTheme();
				StyleManager.Style = activeApplicationSettings.AccentColor.ToMetroColor();
				StyleManager.Update();
				SpecificView.ApplyStyleManager();
				SpecificView.Refresh();
				KeyboardController.RegisterPriorityAction(activeApplicationSettings.StopKeys, Stop).Continue();
			}
			catch (Exception exception)
			{
				Logger.Log($"[{this.GetType().Name}] Failed OpenSettings!", exception, LogLevels.Error);
			}

		}

		public void Add()
		{
			OpenAudioView(new AudioEntryModel());
		}

		public void Edit(Guid id)
		{
			if (id == Guid.Empty) return;
			if (RepositoryManager.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).GetDictionary().ContainsKey(id))
				OpenAudioView(RepositoryManager.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).GetDictionary()[id],false);
		}

		public void OnClosing(CancelEventArgs cancelEventArgs)
		{
			if (RepositoryManager.Values.Any(x => x.IsDirty))
				switch (CustomMetroMessageBox.Show(SpecificView as Form, "You Have Unsaved Changes! Save them now?",
					"Caution", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.No:
						break;
					case DialogResult.Yes:
						Save();
						break;
					case DialogResult.Cancel:
						cancelEventArgs.Cancel = true;
						break;
				}
		}

		public void Delete(Guid id)
		{
			if (id == Guid.Empty) return;
			RepositoryManager.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).Delete(id);
			UpdateDataSource();
			UpdateKeyboardController();

		}

		public void UpdateKeyboardController()
		{
			try
			{
				KeyboardController.ClearKeyActions();
				foreach (var model in RepositoryManager
					.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).GetDictionary().Values)
					KeyboardController.RegisterKeyAction(model.KeyBinding, () => Play(model),
						string.IsNullOrEmpty(model.KeyboardName) ? null : model.KeyboardName);
			}
			catch (Exception exception)
			{
				Logger.Log($"[{this.GetType().Name}] Failed UpdateKeyboardController!", exception, LogLevels.Error);
			}
		}


		public void UpdateDataSource()
		{
			try
			{
				SpecificView.RefreshGrid(RepositoryManager
					.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).GetDictionary().Values.ToList());
			}
			catch (Exception exception)
			{
				Logger.Log($"[{this.GetType().Name}] Failed UpdateDataSource!", exception, LogLevels.Error);
			}

		}

		private void Play(IAudioEntryModel model)
		{
			try
			{
				NAudioController.Play(model.FilePath, model.Volume);
			}
			catch (Exception exception)
			{
				Logger.Log($"[{this.GetType().Name}] Failed Play!", exception, LogLevels.Error);
			}
		}

		private void OpenAudioView(IAudioEntryModel model,bool add=true)
		{
			try
			{
				KeyboardController.Pause();
				var audioSettingsController = (IAudioController) ControllerFactory.Create(typeof(IAudioController));
				if (audioSettingsController.BindingData(model).Initialize().ShowDialogue(this) == DialogResult.OK)
				{
					if (add) RepositoryManager.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).Add(model);
					UpdateDataSource();
					UpdateKeyboardController();
				}

				KeyboardController.Continue();
			}
			catch (Exception exception)
			{
				Logger.Log($"[{this.GetType().Name}] Failed OpenAudioView!", exception, LogLevels.Error);
			}
		}
	}
}