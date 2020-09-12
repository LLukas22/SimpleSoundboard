using System;
using System.Collections.Generic;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.Base;
using SimpleSoundboard.NameService.Models;

namespace SimpleSoundboard.Models
{
	//Contains Multiple Repositories for easy access
	public class RepositoryManager : Dictionary<Type, IRepository>, IRepositoryManager
	{
		public void Load()
		{
			foreach (var repository in Values) repository.Load();
		}

		public void Save()
		{
			foreach (var repository in Values) repository.Save();
		}

		public IRepository<TType> Get<TType>(Type modelType) where TType : class, IBaseModel
		{
			return this[modelType] as IRepository<TType>;
		}


		public void SetEntityState(EntityState entityState)
		{
			foreach (var repository in Values) repository.SetEntityState(entityState);
		}
	}
}