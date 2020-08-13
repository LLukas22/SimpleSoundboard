using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework;
using Soundboard.Entities;
using Soundboard.Keyboard;

namespace Soundboard.Presenters
{
	public class EditPresenter : BasePresenter
	{
		private AudioFileEntity audioFileEntity;
		private readonly EditView editView;

		public EditPresenter(KeyboardController keyboardController, SettingsEntity settingsEntity, MainView mainView) :
			base(keyboardController, settingsEntity, mainView)
		{
			editView = new EditView(this,keyboardController);
		}

		public override void BindData(object entity)
		{
			audioFileEntity = (AudioFileEntity) entity;
			editView.filepath = audioFileEntity.PathToFile;
			editView.KeysTuple = audioFileEntity.KeyBinding;
			editView.keyboardHash = audioFileEntity.KeyboardName;
			editView.volume = audioFileEntity.Volume;
		}

		public override void Show()
		{
			Globals.PlaybackEnabled = false;
			editView.Show();
		}

		public void Save()
		{
			var key1 = editView.KeysTuple.Key1;
			var key2 = editView.KeysTuple.Key2;
			var key3 = editView.KeysTuple.Key3;

			if (File.Exists(editView.filepath) == false)
			{
				MetroMessageBox.Show(editView, "File doesnt exist", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			else if (key1 == Keys.None)
			{
				MetroMessageBox.Show(editView, "You have to choose at least one Key", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			else if (key2 == key1 || key2 == key3 && key2 != Keys.None || key1 == key3)
			{
				MetroMessageBox.Show(editView, "The Keys cant have the same value!", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			else
			{
				AddEntry();
				editView.Close();
			}
		}

		private void AddEntry()
		{
			if (Globals.entityList.Any(x => x == audioFileEntity))
			{
				var index = Globals.entityList.IndexOf(audioFileEntity);
				Globals.entityList[index].KeyBinding = editView.KeysTuple;
				Globals.entityList[index].PathToFile = editView.filepath;
				Globals.entityList[index].KeyboardName = editView.useDefaultKeyboard ? Globals.DefaultKeyboard : editView.keyboardHash ?? Globals.DefaultKeyboard;
				Globals.entityList[index].Volume = editView.volume;
			}
			else
			{
				audioFileEntity.PathToFile = editView.filepath;
				audioFileEntity.KeyBinding = editView.KeysTuple;
				audioFileEntity.KeyboardName = editView.useDefaultKeyboard ? Globals.DefaultKeyboard : editView.keyboardHash ?? Globals.DefaultKeyboard;
				audioFileEntity.Volume = editView.volume;
				Globals.entityList.Add(audioFileEntity);
			}

			keyboardController.Refresh(settingsEntity);
			mainView.RefreshGrid();
		}
	}
}