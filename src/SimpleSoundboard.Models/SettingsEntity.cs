using System.Windows.Forms;
using MetroFramework;

namespace Soundboard.Entities
{
	public class SettingsEntity : BaseEntity
	{
		private int inputdevice;
		private MetroColorStyle metroColorStyle;
		private (int OutputDevice1, int OutputDevice2) outputDevices;
		private (Keys StopKey1, Keys StopKey2) stopKeys;
		private (float Volume1, float Volume2) volumes;

		public MetroColorStyle MetroColorStyle
		{
			get => metroColorStyle;
			set
			{
				if (value != metroColorStyle)
				{
					OnPropertyChanged();
					metroColorStyle = value;
				}
			}
		}

		public int Inputdevice
		{
			get => inputdevice;
			set
			{
				if (value != inputdevice)
				{
					OnPropertyChanged();
					inputdevice = value;
				}
			}
		}

		public (int OutputDevice1, int OutputDevice2) OutputDevices
		{
			get => outputDevices;
			set
			{
				if (value != outputDevices)
				{
					OnPropertyChanged();
					outputDevices = value;
				}
			}
		}

		public (Keys StopKey1, Keys StopKey2) StopKeys
		{
			get => stopKeys;
			set
			{
				if (value != stopKeys)
				{
					OnPropertyChanged();
					stopKeys = value;
				}
			}
		}

		public (float Volume1, float Volume2) Volumes
		{
			get => volumes;
			set
			{
				if (value != volumes)
				{
					OnPropertyChanged();
					volumes = value;
				}
			}
		}
	}
}