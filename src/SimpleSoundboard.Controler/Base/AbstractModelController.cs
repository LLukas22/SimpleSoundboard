
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Models.Base;
using SimpleSoundboard.Interfaces.Views.Base;
using SimpleSoundboard.NameService.Models;

namespace SimpleSoundboard.Controller.Base
{
	public abstract class AbstractModelController<TView,TModel> : AbstractBaseController<TView>, IModelController<TView, TModel> where TView : IView where TModel : IBaseModel
	{
		protected TModel model;
		protected TModel clone;

		protected AbstractModelController(TView view) : base(view)
		{

		}

		public IModelController<TView, TModel> BindingData(TModel model)
		{
			this.model = model;
			this.clone = (TModel)this.model.Clone();
			this.clone.SetEntityState(EntityState.None);
			return this;
		}
	}
}
