using System;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Root;
using Unity;

namespace SimpleSoundboard.Root.Factories
{
	public class ControllerFactory : IControllerFactory
	{
		private readonly IUnityContainer container;

		public ControllerFactory(IUnityContainer container)
		{
			this.container = container;
		}

		public IController Create(Type type)
		{
			return (IController)container.Resolve(type);
		}
	}
}
