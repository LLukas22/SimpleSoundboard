using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Controller.Base
{
	public class AbstractBaseController<TView> : IController<TView> where TView : IView
	{
		public AbstractBaseController(TView view)
		{
			View = view.WithController(this);
		}

		public IView View { get; protected set; }
		public TView SpecificView => (TView) View;

		public virtual IController<TView> Initialize()
		{
			return this;
		}

		public void Show(IController parentController = null)
		{
			if (parentController == null)
				View.Show();
			else
				View.Show((Form) parentController.View);
		}

		public DialogResult ShowDialogue(IController parentController = null)
		{
			return parentController == null ? View.ShowDialog() : View.ShowDialog((Form) parentController.View);
		}
	}
}