
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Components;
using SimpleSoundboard.Controller.Base;
using SimpleSoundboard.Extensions;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Root;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.Views.MessageBox;
using Soundboard.Audio;
using Soundboard.Entities;
using Unity;

namespace SimpleSoundboard.Controller
{
	public class MainController : AbstractBaseController<IMainView>, IMainController
	{
		[Dependency] public INAudioController NAudioController { get; set; }
		[Dependency] public IKeyboardController KeyboardController { get; set; }
		[Dependency] public IRepositoryManager RepositoryManager { get; set; }
		[Dependency] public IControllerFactory ControllerFactory { get; set; }
		[Dependency] public MetroStyleManager StyleManager { get; set; }
		private IApplicationSettingsModel activeApplicationSettings;

		public MainController(IMainView view) : base(view)
		{
			
		}

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
				.BindToForm(this.SpecificView as Form)
				.RegisterPriorityAction(activeApplicationSettings.StopKeys, Stop);
			return base.Initialize();
		}


		public void UpdateDataSource()
		{
			//SpecificView.GridBindingSource = new BindingList<IAudioEntryModel>(RepositoryManager
			//	.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).GetDictionary().Values.ToList());
			SpecificView.RefreshGrid(RepositoryManager
				.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).GetDictionary().Values.ToList());

		}

		public void UpdateOutputDevice(int outputDevice, string value)
		{
			activeApplicationSettings.OutputDevices[outputDevice] = value;
			NAudioController.RegisterOutputDevice(outputDevice, activeApplicationSettings.OutputDevices[outputDevice]);
			
		}



		public void Save()
		{
			RepositoryManager.Save();
		}

		public void Play()
		{
			NAudioController.Play(@"C:\Users\Lukas\Downloads\and-his-name-is-john-cena-1.mp3");
		}

		public void Stop()
		{
			NAudioController.Stop();
		}

		public void ChangeVolume(int outputDevice, float value)
		{
			activeApplicationSettings.Volumes[outputDevice] = value;
			NAudioController.ChangeVolume(outputDevice, activeApplicationSettings.Volumes[outputDevice]);
		}

		public void OpenSettings()
		{
			var settingsController = (ISettingsController)ControllerFactory.Create(typeof(ISettingsController));
			settingsController.BindingData(activeApplicationSettings).Initialize().ShowDialogue(this);
			SpecificView.SetStopButtonText(activeApplicationSettings.StopKeys);
			StyleManager.Theme = activeApplicationSettings.Style.ToMetroTheme();
			StyleManager.Style = activeApplicationSettings.AccentColor.ToMetroColor();
			StyleManager.Update();
			this.SpecificView.ApplyStyleManager();
			this.SpecificView.Refresh();
			KeyboardController.RegisterPriorityAction(activeApplicationSettings.StopKeys, Stop);
		}

		public void Add()
		{
			var newAudioEntry = new AudioEntryModel();
			var audioSettingsController = (IAudioController)ControllerFactory.Create(typeof(IAudioController));
			audioSettingsController.BindingData(newAudioEntry).Initialize().ShowDialogue(this);
			RepositoryManager.Get<IAudioEntryModel>(typeof(IAudioEntryModel)).Add(newAudioEntry);
			UpdateDataSource();
		}

		public void Edit()
		{

		}
		public void OnClosing(CancelEventArgs cancelEventArgs)
		{
			if (RepositoryManager.Values.Any(x=>x.IsDirty))
			{
				switch (CustomMetroMessageBox.Show(this.SpecificView as Form, "You Have Unsaved Changes! Save them now?", "Caution", MessageBoxButtons.YesNoCancel))
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
		}
	}
}
