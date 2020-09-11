
using SimpleSoundboard.Interfaces.Root.Base;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.Root.Base;
using SimpleSoundboard.Views.Views;
using Unity;
using Unity.Lifetime;

namespace SimpleSoundboard.Root.Registrations
{
	public class ViewRegistration : AbstractBaseRegistration
	{
		public ViewRegistration(IUnityContainer container) : base(container)
		{
		}

		public override IRegistration Register()
		{
			container.RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager());
			container.RegisterType<ISettingsView, SettingsView>();
			container.RegisterType<IAudioView, AudioView>();
			return base.Register();
		}
	}
}
