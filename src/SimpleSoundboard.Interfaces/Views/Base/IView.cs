using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Controller.Base;

namespace SimpleSoundboard.Interfaces.Views.Base
{
	public interface IView
	{
		IView Show(IWin32Window owner = null);
		DialogResult ShowDialog(IWin32Window owner = null);
		IView Refresh();
		void ApplyStyleManager();
		IView WithController(IController controller);
	}
}