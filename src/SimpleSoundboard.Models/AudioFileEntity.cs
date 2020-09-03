
namespace Soundboard.Entities
{
	public class AudioFileEntity : BaseEntity
	{
		private (Keys FirstKey, Keys SecondKey, Keys ThirdKey) keyBinding;

		private string keyboardName;

		private string pathToFile;

		private float volume = 1;

		public AudioFileEntity()
		{
		}

		public AudioFileEntity(string pathToFile, (Keys FirstKey, Keys SecondKey, Keys ThirdKey) keyBinding,
			float volume = 1, string keyboardName = null)
		{
			this.pathToFile = pathToFile;
			this.keyBinding = keyBinding;
			this.keyboardName = keyboardName ?? Globals.DefaultKeyboard;
			this.volume = 1;
		}

		public float Volume
		{
			get => volume;
			set
			{
				if (value != volume)
				{
					OnPropertyChanged();
					volume = value;
				}
			}
		}

		public string KeyboardName
		{
			get => keyboardName;
			set
			{
				if (value != keyboardName)
				{
					OnPropertyChanged();
					keyboardName = value;
				}
			}
		}

		public string PathToFile
		{
			get => pathToFile;
			set
			{
				if (value != pathToFile)
				{
					OnPropertyChanged();
					pathToFile = value;
				}
			}
		}

		public (Keys FirstKey, Keys SecondKey, Keys ThirdKey) KeyBinding
		{
			get => keyBinding;
			set
			{
				if (value != keyBinding)
				{
					OnPropertyChanged();
					keyBinding = value;
				}
			}
		}
	}
}