using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Models.Base;
using SimpleSoundboard.Interfaces.Views.Base;
using SimpleSoundboard.NameService.Models;

namespace SimpleSoundboard.Controller.Base
{
	public abstract class AbstractModelController<TView, TModel> : AbstractBaseController<TView>,
		IModelController<TView, TModel> where TView : IView where TModel : IBaseModel
	{
		protected TModel clone;
		protected TModel model;

		protected AbstractModelController(TView view) : base(view)
		{
		}

		public IModelController<TView, TModel> BindingData(TModel model)
		{
			this.model = model;
			clone = (TModel) this.model.Clone();
			clone.SetEntityState(EntityState.None);
			return this;
		}
	}
}