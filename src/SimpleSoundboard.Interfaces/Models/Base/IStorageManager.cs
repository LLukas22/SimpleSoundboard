using System.Collections.Generic;

namespace SimpleSoundboard.Interfaces.Models.Base
{
	public interface IStorageManager<TModel> where TModel : class, IBaseModel
	{
		IEnumerable<TModel> Load();
		void Save(IEnumerable<TModel> models);
	}
}