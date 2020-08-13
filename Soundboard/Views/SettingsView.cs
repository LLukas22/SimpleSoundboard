using System;
using System.Windows.Forms;
using MetroFramework;
using Soundboard.Presenters;
using Soundboard.Views;

namespace Soundboard
{
	public partial class SettingsView : BaseView
	{
		
		public MetroColorStyle metroColorStyle;

		private readonly SettingsPresenter settingsPresenter;
		public (Keys Key1, Keys Key2) StopKeys;

		public SettingsView(SettingsPresenter settingsPresenter)
		{
			InitializeComponent();
			this.settingsPresenter = settingsPresenter;
			foreach (var item in Enum.GetValues(typeof(MetroColorStyle))) ThemeColor.Items.Add(item);
			Globals.styleManager.Clone(this);
		}

		private void SettingsView_Load(object sender, EventArgs e)
		{
			Key1.Text = StopKeys.Key1.ToString();
			Key2.Text = StopKeys.Key2.ToString();
			ThemeColor.SelectedItem = metroColorStyle;
		}

		private void CancleButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Key1_KeyDown(object sender, KeyEventArgs e)
		{
			StopKeys.Key1 = e.KeyCode;
			Key1.Clear();
			Key1.Text = e.KeyCode.ToString();
		}

		private void Key2_KeyDown(object sender, KeyEventArgs e)
		{
			StopKeys.Key2 = e.KeyCode;
			Key2.Clear();
			Key2.Text = e.KeyCode.ToString();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			settingsPresenter.Save();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			StopKeys = (Keys.None, Keys.None);
			Key1.Text = StopKeys.Key1.ToString();
			Key2.Text = StopKeys.Key2.ToString();
		}

		private void ThemeColor_SelectedIndexChanged(object sender, EventArgs e)
		{
			metroColorStyle = (MetroColorStyle) ThemeColor.SelectedItem;
		}
	}
}