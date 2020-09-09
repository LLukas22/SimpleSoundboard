using SimpleSoundboard.Controller;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Root.Base;
using SimpleSoundboard.Root.Base;
using Unity;
using Unity.Lifetime;

namespace SimpleSoundboard.Root.Registrations
{
	public class ControllerRegistration : AbstractBaseRegistration
	{
		public ControllerRegistration(IUnityContainer container) : base(container)
		{

		}

		public override IRegistration Register()
		{
			container.RegisterType<IMainController, MainController>(new ContainerControlledLifetimeManager());
			container.RegisterType<ISettingsController, SettingsController>();
			return base.Register();
		}
	}
}
