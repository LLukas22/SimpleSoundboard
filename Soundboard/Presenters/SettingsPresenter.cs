using System.Windows.Forms;
using MetroFramework;
using Microsoft.Win32;
using Soundboard.Entities;
using Soundboard.Extensions;
using Soundboard.Keyboard;

namespace Soundboard.Presenters
{
	public class SettingsPresenter : BasePresenter
	{
		private readonly SettingsView settingsView;

		public SettingsPresenter(KeyboardController keyboardController, SettingsEntity settingsEntity,
			MainView mainView) : base(keyboardController, settingsEntity, mainView)
		{
			settingsView = new SettingsView(this);
			settingsView.StopKeys = settingsEntity.StopKeys;
			settingsView.metroColorStyle = settingsEntity.MetroColorStyle;
		}

		public override void Show()
		{
			Globals.PlaybackEnabled = false;
			settingsView.Show();
		}

		public void Save()
		{
			if (settingsView.StopKeys.Key1 == Keys.None)
			{
				MetroMessageBox.Show(settingsView, "You have to choose at least one Key", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			else if (settingsView.StopKeys.Key1 == settingsView.StopKeys.Key2)
			{
				MetroMessageBox.Show(settingsView, "The Keys cant have the same value!\nSetting Value of Key2 to None",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				settingsEntity.StopKeys = settingsView.StopKeys;
				settingsEntity.MetroColorStyle = settingsView.metroColorStyle;
				Globals.styleManager.Style = settingsView.metroColorStyle;
				Globals.styleManager.Clone(mainView);
				mainView.ChangeIcon(Globals.styleManager.Style.GetColorFromSkin());
				mainView.Refresh();
				settingsView.Close();
			}
		}

	}
}