using System;
using SimpleSoundboard.Interfaces.Controller.Base;

namespace SimpleSoundboard.Interfaces.Root
{
	public interface IControllerFactory
	{
		IController Create(Type type);
	}
}