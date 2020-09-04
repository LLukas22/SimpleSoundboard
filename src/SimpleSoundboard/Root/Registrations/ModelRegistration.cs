
using System;
using System.IO;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.StorageManager;
using SimpleSoundboard.Interfaces.Root.Base;
using SimpleSoundboard.Models;
using SimpleSoundboard.Models.Repositories;
using SimpleSoundboard.Models.StorageManager;
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

			
			var settingsDirectory =
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
					"SimpleSoundboard");
			if (!Directory.Exists(settingsDirectory))
			{
				Directory.CreateDirectory(settingsDirectory);
			}

			//Storage Manager
			container.RegisterType<IApplicationSettingsStorageManager, ApplicationSettingsStorageManager>(
				new ContainerControlledLifetimeManager(), new InjectionConstructor(settingsDirectory));
			container.RegisterType<IAudioEntryStorageManager, AudioEntryStorageManager>(
				new ContainerControlledLifetimeManager(), new InjectionConstructor(settingsDirectory));


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
			container.Resolve<IRepositoryManager>().Load();
			return base.Initialize();
		}
	}
}
