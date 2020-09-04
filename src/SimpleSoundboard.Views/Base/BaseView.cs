using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using SimpleSoundboard.Interfaces.Controller.Base;
using SimpleSoundboard.Interfaces.Views.Base;

namespace SimpleSoundboard.Views.Base
{
	public partial class BaseView : MetroForm, IView
	{
		protected IController controller;

		public BaseView(MetroStyleManager styleManager)
		{
			InitializeComponent();
			styleManager.Clone(this);
		}

		public IView Show(IWin32Window owner = null)
		{
			if (owner == null)
			{
				this.Show();
			}
			else
			{
				this.Show(owner);
			}
			return this;
		}

		public virtual IView Refresh()
		{
			return this;
		}

		public virtual IView WithController(IController controller)
		{
			this.controller = controller;
			return this;
		}
	}
}
