using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using Soundboard.Interfaces;

namespace Soundboard.Views
{
	public partial class BaseView : MetroForm, IBaseView
	{
		public BaseView()
		{
			InitializeComponent();
		}

		public virtual void ShowForm()
		{
			Show();
		}

		public virtual void Save()
		{
		}

		private void BaseView_FormClosing(object sender, FormClosingEventArgs e)
		{
			Globals.PlaybackEnabled = true;
			if (Globals.entityList.Any(x => x.IsDirty)) Save();
		}
	}
}