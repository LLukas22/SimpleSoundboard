using System;
using System.Drawing;
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
		protected MetroStyleManager styleManager;

		public BaseView(MetroStyleManager styleManager)
		{
			this.styleManager = styleManager;
			
			this.Icon = SimpleSoundboard.Views.Properties.Resources.Note;
			InitializeComponent();
		}

		public virtual void ApplyStyleManager()
		{
			styleManager.Clone(this);
		}

		public IView Show(IWin32Window owner = null)
		{
			if (owner == null)
				base.Show();
			else
				base.Show(owner);
			return this;
		}

		public DialogResult ShowDialog(IWin32Window owner = null)
		{
			var result = owner == null ? base.ShowDialog() : base.ShowDialog(owner);
			return result;
		}

		public virtual IView Refresh()
		{
			base.Refresh();
			return this;
		}

		public virtual IView WithController(IController controller)
		{
			this.controller = controller;
			return this;
		}

		protected override void OnLoad(EventArgs e)
		{
			ApplyStyleManager();
			Subscribe();
			base.OnLoad(e);
		}

		protected virtual void Subscribe()
		{
		}
	}
}