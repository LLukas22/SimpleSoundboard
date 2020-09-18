using System;
using System.IO;
using System.Linq;
using MetroFramework.Components;
using SimpleSoundboard.Extensions;
using SimpleSoundboard.Interfaces.Logger;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Models.Repositories;
using SimpleSoundboard.Interfaces.Models.StorageManager;
using SimpleSoundboard.Interfaces.Root.Base;
using SimpleSoundboard.Models;
using SimpleSoundboard.Models.Repositories;
using SimpleSoundboard.Models.StorageManager;
using SimpleSoundboard.NameService;
using SimpleSoundboard.Root.Base;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace SimpleSoundboard.Root.Registrations
{
	public class ModelRegistration : AbstractBaseRegistration
	{
		public ModelRegistration(IUnityContainer container) : base(container)
		{
		}

		public override IRegistration Register()
		{
			container.RegisterType<IRepositoryManager, RepositoryManager>(new ContainerControlledLifetimeManager());

			//Storage Manager
			container.RegisterType<IApplicationSettingsStorageManager, ApplicationSettingsStorageManager>(
				new ContainerControlledLifetimeManager(), new InjectionConstructor(ApplicationConstants.SettingsDirectory, container.Resolve<ILogger>()));
			container.RegisterType<IAudioEntryStorageManager, AudioEntryStorageManager>(
				new ContainerControlledLifetimeManager(), new InjectionConstructor(ApplicationConstants.SettingsDirectory, container.Resolve<ILogger>()));


			//Repositories 
			container.RegisterType<IAudioEntryRepository, AudioEntryRepository>(
				new ContainerControlledLifetimeManager());
			container.RegisterType<IApplicationSettingsRepository, ApplicationSettingsRepository>(
				new ContainerControlledLifetimeManager());

			return base.Register();
		}


		public override IRegistration Initialize()
		{
			container.Resolve<IAudioEntryRepository>();
			container.Resolve<IApplicationSettingsRepository>();
			var repositoryManager = container.Resolve<IRepositoryManager>();
			repositoryManager.Load();

			var applicationSettings =
				repositoryManager.Get<IApplicationSettingsModel>(typeof(IApplicationSettingsModel)).GetDictionary()
					.Values.First();

			container.RegisterInstance(new MetroStyleManager
			{
				Theme = applicationSettings.Style.ToMetroTheme(),
				Style = applicationSettings.AccentColor.ToMetroColor()
			});

			return base.Initialize();
		}
	}
}