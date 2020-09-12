using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using SimpleSoundboard.NameService.Models;

namespace SimpleSoundboard.Interfaces.Models.Base
{
	public interface IBaseModel : INotifyPropertyChanged
	{
		[JsonIgnore] EntityState EntityState { get; }

		[JsonIgnore] Guid Id { get; set; }

		event PropertyChangedEventHandler PropertyChanged;
		void SetEntityState(EntityState entityState);
		public IBaseModel Clone();
	}
}