using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using SimpleSoundboard.Interfaces.Models.Base;
using SimpleSoundboard.NameService.Models;

namespace Soundboard.Entities
{
	public abstract class AbstractBaseModel : IBaseModel
	{
		private Guid id;

		[JsonIgnore] public EntityState EntityState { get; protected set; }

		[JsonIgnore]
		public Guid Id
		{
			get
			{
				if (id == Guid.Empty) id = Guid.NewGuid();
				return id;
			}
			set => id = value;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void SetEntityState(EntityState entityState)
		{
			EntityState = entityState;
		}

		public IBaseModel Clone()
		{
			return (IBaseModel) MemberwiseClone();
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			EntityState = EntityState.Modified;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void SetProperty<TType>(ref TType backingField, TType value)
		{
			OnPropertyChanged();
			backingField = value;
		}
	}
}