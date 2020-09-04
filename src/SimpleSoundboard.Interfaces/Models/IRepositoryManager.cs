using System;
using System.Collections.Generic;
using SimpleSoundboard.Interfaces.Models.Base;
using SimpleSoundboard.NameService.Models;

namespace SimpleSoundboard.Interfaces.Models
{
	public interface IRepositoryManager : IDictionary<Type, IRepository>
	{
		void Load();
		void Save();
		void SetEntityState(EntityState entityState);
	}
}