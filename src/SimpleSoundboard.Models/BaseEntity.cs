using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Soundboard.Interfaces;

namespace Soundboard.Entities
{
	public class BaseEntity : INotifyPropertyChanged, IBaseEntity
	{
		[JsonIgnore] public bool IsDirty;

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			IsDirty = true;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public virtual void Refresh()
		{
			IsDirty = false;
		}
	}
}