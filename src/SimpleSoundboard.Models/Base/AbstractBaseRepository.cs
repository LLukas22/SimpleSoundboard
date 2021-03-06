﻿using System;
using System.Collections.Generic;
using System.Linq;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.Base;
using SimpleSoundboard.NameService.Models;

namespace SimpleSoundboard.Models.Base
{
	public abstract class AbstractBaseRepository<TModel> : IRepository<TModel> where TModel : class, IBaseModel
	{
		private readonly Dictionary<Guid, TModel> models;
		private readonly IStorageManager<TModel> storageManager;

		protected AbstractBaseRepository(IStorageManager<TModel> storageManager, IRepositoryManager repositoryManager)
		{
			this.storageManager = storageManager;
			models = new Dictionary<Guid, TModel>();
			repositoryManager.Add(typeof(TModel), this);
		}

		public bool IsDirty =>
			models.Values.Any(x => x.EntityState != EntityState.None);

		public void Load()
		{
			foreach (var model in storageManager.Load())
			{
				if (model is null) continue;
				models.Add(model.Id, model);
			}

			SetEntityState(EntityState.None);
		}

		public void Save()
		{
			foreach (var key in models.Keys)
				if (models[key].EntityState == EntityState.Deleted)
					models.Remove(key);
				else
					models[key].SetEntityState(EntityState.None);
			storageManager.Save(GetDictionary().Values);
		}

		public void Add(TModel model)
		{
			if (models.ContainsKey(model.Id))
				throw new ArgumentException(
					$"{model.GetType().Name} with ID {model.Id} is already in Repository {GetType().Name}");
			model.SetEntityState(EntityState.Added);
			models.Add(model.Id, model);
		}

		public void Delete(TModel model)
		{
			Delete(model.Id);
		}

		public void Delete(Guid id)
		{
			SetEntityState(EntityState.Deleted, id);
		}

		public void SetEntityState(EntityState entityState)
		{
			foreach (var id in models.Keys) SetEntityState(entityState, id);
		}

		public void SetEntityState(EntityState entityState, Guid id)
		{
			if (models.ContainsKey(id)) models[id].SetEntityState(entityState);
		}

		public Dictionary<Guid, TModel> GetDictionary()
		{
			var dict = new Dictionary<Guid, TModel>();
			foreach (var (id, model) in models)
				if (model.EntityState != EntityState.Deleted)
					dict.Add(id, model);
			return dict;
		}
	}
}