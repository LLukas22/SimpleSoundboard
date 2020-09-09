using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Controller.Base
{
	public class AbstractBaseController<TView> : IController<TView> where TView : IView
	{
		public IView View { get; protected set; }
		public TView SpecificView => (TView)View;

		public AbstractBaseController(TView view)
		{
			
			this.View = view.WithController(this);
		}

		public virtual IController<TView> Initialize()
		{
			return this;
		}

		public void Show(IController parentController = null)
		{
			if (parentController == null)
			{
				View.Show();
			}
			else
			{
				View.Show((Form)parentController.View);
			}
		}
	}
}
