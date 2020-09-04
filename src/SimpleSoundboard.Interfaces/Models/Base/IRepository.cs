using System;
using System.Collections.Generic;
using SimpleSoundboard.NameService.Models;

namespace SimpleSoundboard.Interfaces.Models.Base
{
	public interface IRepository<TModel> : IRepository where TModel : class, IBaseModel
	{
		void Add(TModel model);
		void Delete(TModel model);
		Dictionary<Guid, TModel> GetDictionary();
	}

	public interface IRepository
	{
		bool IsDirty { get; }
		void Load();
		void Save();
		void Delete(Guid id);
		void SetEntityState(EntityState entityState);
		void SetEntityState(EntityState entityState, Guid id);
	}
}
