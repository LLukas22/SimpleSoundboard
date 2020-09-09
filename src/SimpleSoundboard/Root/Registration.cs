using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Interfaces.Root;
using SimpleSoundboard.Interfaces.Root.Base;
using SimpleSoundboard.Keyboard;
using SimpleSoundboard.NAudio;
using SimpleSoundboard.Root.Base;
using SimpleSoundboard.Root.Factories;
using SimpleSoundboard.Root.Registrations;
using Soundboard.Audio;
using Unity;
using Unity.Lifetime;

namespace SimpleSoundboard.Root
{
	public class Registration : AbstractBaseRegistration
	{
		public Registration(IUnityContainer container) : base(container)
		{
		}

		public override IRegistration Initialize()
		{
			container.RegisterType<INAudioController,NAudioController>(new ContainerControlledLifetimeManager());
			container.RegisterType<IKeyboardController, KeyboardController>(new ContainerControlledLifetimeManager());
			container.RegisterInstance<IControllerFactory>(new ControllerFactory(container));
			new ModelRegistration(container).Register().Initialize();
			new ViewRegistration(container).Register().Initialize();
			new ControllerRegistration(container).Register().Initialize();
			return base.Initialize();
		}
	}
}
