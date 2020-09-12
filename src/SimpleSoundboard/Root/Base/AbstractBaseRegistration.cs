using SimpleSoundboard.Interfaces.Root.Base;
using Unity;

namespace SimpleSoundboard.Root.Base
{
	public abstract class AbstractBaseRegistration : IRegistration
	{
		protected readonly IUnityContainer container;

		protected AbstractBaseRegistration(IUnityContainer container)
		{
			this.container = container;
		}

		public virtual IRegistration Register()
		{
			return this;
		}

		public virtual IRegistration Initialize()
		{
			return this;
		}
	}
}