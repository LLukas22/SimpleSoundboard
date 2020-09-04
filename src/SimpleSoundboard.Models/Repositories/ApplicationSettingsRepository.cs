
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Models.Base;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Models.StorageManager;
using SimpleSoundboard.Models.Base;

namespace SimpleSoundboard.Models.Repositories
{
	public class ApplicationSettingsRepository : AbstractBaseRepository<IApplicationSettingsModel>, IApplicationSettingsRepository
	{
		public ApplicationSettingsRepository(IApplicationSettingsStorageManager storageManager, IRepositoryManager repositoryManager) : base(storageManager, repositoryManager)
		{
		}
	}
}
