using SimpleSoundboard.Interfaces.Models.Base;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Interfaces.Controller.Base
{
	public interface IModelController<TView, TModel> : IController<TView> where TView : IView where TModel : IBaseModel
	{
		IModelController<TView, TModel> BindingData(TModel model);
	}
}