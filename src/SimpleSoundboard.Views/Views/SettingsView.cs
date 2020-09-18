using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Components;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.NameService;
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

		public void BindData(ref IApplicationSettingsModel original, IApplicationSettingsModel clone)
		{
			this.original = original;
			this.clone = clone;
			keyComboControl.Initialize(this.clone.StopKeys);
			metroComboBox_Color.DataSource = Enum.GetValues(typeof(ApplicationAccentColor));
			metroComboBox_Style.DataSource = Enum.GetValues(typeof(ApplicationStyle));
			metroComboBox_Style.SelectedItem = clone.Style;
			metroComboBox_Color.SelectedItem = clone.AccentColor;
		}

		protected override void Subscribe()
		{
			btn_Ok.Click += Btn_OkOnClick;
			btn_Cancel.Click += Btn_CancelOnClick;
			btn_OpenFolder.Click += Btn_OpenFolderOnClick;
			btn_KeyboardInput.Click += (sender, args) => (controller as ISettingsController).ShowKeyboardView();
			keyComboControl.OnComboChanged += (sender, args) =>
				clone.StopKeys = keyComboControl.GetCombo().ToList();
			metroComboBox_Color.SelectedValueChanged += (sender, args) =>
				SetEnum<ApplicationAccentColor>(metroComboBox_Color.SelectedValue.ToString());
			metroComboBox_Style.SelectedValueChanged += (sender, args) =>
				SetEnum<ApplicationStyle>(metroComboBox_Style.SelectedValue.ToString());
		}

		private void Btn_OpenFolderOnClick(object? sender, EventArgs e)
		{
			Process.Start("explorer.exe", ApplicationConstants.SettingsDirectory);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			if (clone.EntityState == EntityState.Modified)
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

		private void Btn_CancelOnClick(object? sender, EventArgs e)
		{
			Close();
		}

		private void Btn_OkOnClick(object? sender, EventArgs e)
		{
			Save();
			Close();
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