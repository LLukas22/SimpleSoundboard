using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Components;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.NameService.Models;
using SimpleSoundboard.Views.Base;
using SimpleSoundboard.Views.MessageBox;

namespace SimpleSoundboard.Views.Views
{
	public partial class SettingsView : BaseView, ISettingsView
	{
		private IApplicationSettingsModel clone;
		private IApplicationSettingsModel original;

		public SettingsView(MetroStyleManager styleManager) : base(styleManager)
		{
			InitializeComponent();
		}

		protected override void Subscribe()
		{
			this.btn_Ok.Click += Btn_OkOnClick;
			this.btn_Cancel.Click += Btn_CancelOnClick;
			this.btn_OpenFolder.Click += Btn_OpenFolderOnClick; 
			this.keyComboControl.OnComboChanged += (sender, args) =>
				this.clone.StopKeys = this.keyComboControl.GetCombo().ToList();
			this.metroComboBox_Color.SelectedValueChanged += (sender, args) =>
				SetEnum<ApplicationAccentColor>(metroComboBox_Color.SelectedValue.ToString());
			this.metroComboBox_Style.SelectedValueChanged += (sender, args) =>
				SetEnum<ApplicationStyle>(metroComboBox_Style.SelectedValue.ToString());
		}

		private void Btn_OpenFolderOnClick(object? sender, EventArgs e)
		{
			Process.Start("explorer.exe", @Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
				"SimpleSoundboard"));
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			if (clone.EntityState == EntityState.Modified)
			{
				switch (CustomMetroMessageBox.Show(this, "You Have Unsaved Changes! Save them now?", "Caution",
					MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.No:
						break;
					case DialogResult.Yes:
						Save();
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
			}
			base.OnClosing(e);
		}

		private void SetEnum<TEnum>(string source) where TEnum : struct
		{
			TEnum value;
			Enum.TryParse(source, out value);
			switch (value)
			{
				case ApplicationAccentColor applicationAccentColor:
					clone.AccentColor = applicationAccentColor;
					break;
				case ApplicationStyle applicationStyle:
					clone.Style = applicationStyle;
					break;
			}
		}

		public void BindData(ref IApplicationSettingsModel original, IApplicationSettingsModel clone)
		{
			this.original = original;
			this.clone = clone;
			this.keyComboControl.Initialize(this.clone.StopKeys);
			this.metroComboBox_Color.DataSource = Enum.GetValues(typeof(ApplicationAccentColor));
			this.metroComboBox_Style.DataSource = Enum.GetValues(typeof(ApplicationStyle));
			this.metroComboBox_Style.SelectedItem = clone.Style;
			this.metroComboBox_Color.SelectedItem = clone.AccentColor;
		}

		private void Btn_CancelOnClick(object? sender, EventArgs e)
		{
			this.Close();
		}

		private void Btn_OkOnClick(object? sender, EventArgs e)
		{
			Save();
			this.Close();
		}

		private void Save()
		{
			original.Style = clone.Style;
			original.StopKeys = clone.StopKeys;
			original.AccentColor = clone.AccentColor;
			clone.SetEntityState(EntityState.None);
		}
	}
}
