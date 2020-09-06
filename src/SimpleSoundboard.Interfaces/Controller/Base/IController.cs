using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Interfaces.Controller.Base
{
	public interface IController
	{
		
	}

	public interface IController<out TView> : IController where TView : IView
	{
		TView SpecificView { get; }
		IController<TView> Initialize();
	}
}