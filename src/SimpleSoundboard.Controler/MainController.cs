using SimpleSoundboard.Controller.Base;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Interfaces.Views;

namespace SimpleSoundboard.Controller
{
	public class MainController : AbstractBaseController<IMainView>, IMainController
	{
		public MainController(IRepositoryManager repositoryManager, IMainView view) : base(repositoryManager, view)
		{

		}
	}
}
