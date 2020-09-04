using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Models.StorageManager;
using SimpleSoundboard.Models.Base;

namespace SimpleSoundboard.Models.StorageManager
{
	public class AudioEntryStorageManager : AbstractBaseStorageManager<IAudioEntryModel>, IAudioEntryStorageManager
	{
		public AudioEntryStorageManager(string path) : base(path)
		{
			fileName = "AudioEntries";
		}
	}
}
