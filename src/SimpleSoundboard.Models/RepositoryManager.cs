using System;
using System.Collections.Generic;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.Base;
using SimpleSoundboard.Models.Base;
using SimpleSoundboard.NameService.Models;

namespace SimpleSoundboard.Models
{
	public class RepositoryManager : Dictionary<Type,IRepository>, IRepositoryManager
	{
		public void Load()
		{
			foreach (var repository in Values)
			{
				repository.Load();
			}
		}

		public void Save()
		{
			foreach (var repository in Values)
			{
				repository.Save();
			}
		}

		public void SetEntityState(EntityState entityState)
		{
			foreach (var repository in Values)
			{
				repository.SetEntityState(entityState);
			}
		}
	}
}
