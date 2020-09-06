using System.Collections.Generic;
using System.Linq;
using SimpleSoundboard.Controller.Base;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;
using Soundboard.Audio;
using Unity;

namespace SimpleSoundboard.Controller
{
	public class MainController : AbstractBaseController<IMainView>, IMainController
	{
		
		[Dependency] public INAudioController NAudioController { get; set; }
		private readonly IApplicationSettingsModel activeApplicationSettings;

		public MainController(IRepositoryManager repositoryManager, IMainView view) : base(repositoryManager, view)
		{
			activeApplicationSettings = repositoryManager
				.Get<IApplicationSettingsModel>(typeof(IApplicationSettingsModel)).GetDictionary().Values.First();
		}

		public override IController<IMainView> Initialize()
		{
			var waveOutCapabilities = NAudioController.GetWaveOutCapabilities();
			SpecificView.OutputDevice1DataSource = new List<string>(waveOutCapabilities.Keys);
			SpecificView.OutputDevice2DataSource = new List<string>(waveOutCapabilities.Keys);

			SpecificView.SetOutputDevice1(activeApplicationSettings.OutputDevices[0])
				.SetOutputDevice2(activeApplicationSettings.OutputDevices[1]);

			NAudioController.RegisterOutputDevice(0, activeApplicationSettings.OutputDevices[0])
				.RegisterOutputDevice(1, activeApplicationSettings.OutputDevices[1]);

			NAudioController.RegisterVolumeSlider(0, SpecificView.VolumeSlider1)
				.RegisterVolumeSlider(1, SpecificView.VolumeSlider2);

			return base.Initialize();
		}


		public void UpdateOutputDevice(int outputDevice, string value)
		{
			activeApplicationSettings.OutputDevices[outputDevice] = value;
			NAudioController.RegisterOutputDevice(outputDevice, activeApplicationSettings.OutputDevices[outputDevice]);
		}

		public void Save()
		{
			repositoryManager.Save();
		}

		public void Play()
		{
			NAudioController.Play(@"C:\Users\Lukas\Downloads\and-his-name-is-john-cena-1.mp3");
		}

		public void Stop()
		{
			NAudioController.Stop();
		}
	}
}
