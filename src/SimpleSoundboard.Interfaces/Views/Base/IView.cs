using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Controller.Base;

namespace SimpleSoundboard.Interfaces.Views.Base
{
	public interface IView
	{
		IView Show(IWin32Window owner = null);
		IView Refresh();
		IView WithController(IController controller);
	}
}