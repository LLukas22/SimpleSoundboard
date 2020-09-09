using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MetroFramework.Components;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.Views.Base;

namespace SimpleSoundboard.Views.Views
{
	public partial class SettingsView : BaseView, ISettingsView
	{
		private IApplicationSettingsModel model;

		public SettingsView(MetroStyleManager styleManager) : base(styleManager)
		{
			InitializeComponent();
		}

		protected override void Subscribe()
		{
			this.btn_Ok.Click += Btn_OkOnClick;
			this.btn_Cancel.Click += Btn_CancelOnClick;
			this.keyComboControl.OnComboChanged += (sender, args) =>
				this.model.StopKeys = this.keyComboControl.GetCombo().ToList();
		}

		public void BindData(IApplicationSettingsModel model)
		{
			this.model = model;
			this.keyComboControl.Initialize(this.model.StopKeys);
		}

		private void Btn_CancelOnClick(object? sender, EventArgs e)
		{
			
		}

		private void Btn_OkOnClick(object? sender, EventArgs e)
		{

		}
	}
}
