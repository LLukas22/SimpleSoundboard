using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Models.Repositories;
using SimpleSoundboard.Interfaces.Models.StorageManager;
using SimpleSoundboard.Models.Base;

namespace SimpleSoundboard.Models.Repositories
{
	public class AudioEntryRepository : AbstractBaseRepository<IAudioEntryModel>, IAudioEntryRepository
	{
		public AudioEntryRepository(IAudioEntryStorageManager storageManager, IRepositoryManager repositoryManager) : base(storageManager, repositoryManager)
		{
		}
	}
}
