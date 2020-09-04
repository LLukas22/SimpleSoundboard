
using MetroFramework.Components;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.Views.Base;

namespace SimpleSoundboard.Views.Views
{
	public partial class MainView : BaseView, IMainView
	{
		public MainView(MetroStyleManager styleManager) : base(styleManager)
		{
			InitializeComponent();
		}
	}
}
