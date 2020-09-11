using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Interfaces.Controller.Base
{
	public interface IController
	{
		IView View { get; }
		void Show(IController parentController = null);
		DialogResult ShowDialogue(IController parentController = null);
	}

	public interface IController<out TView> : IController where TView : IView
	{
		TView SpecificView { get; }
		IController<TView> Initialize();
	}
}