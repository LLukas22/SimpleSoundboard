using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Controller.Base
{
	public class AbstractBaseController<TView> : IController<TView> where TView : IView
	{
		protected readonly IRepositoryManager repositoryManager;
		protected readonly IView view;
		public TView SpecificView => (TView) view;


		public AbstractBaseController(IRepositoryManager repositoryManager, TView view)
		{
			this.repositoryManager = repositoryManager;
			this.view = view.WithController(this);
		}

		public virtual IController<TView> Initialize()
		{
			return this;
		}
	}
}
