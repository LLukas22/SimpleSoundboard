
using System;
using System.ComponentModel;
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
	public partial class AudioView : BaseView, IAudioView
	{
		private IAudioEntryModel clone;
		private IAudioEntryModel original;

		public AudioView(MetroStyleManager styleManager):base(styleManager)
		{
			InitializeComponent();
		}

		public void BindData(ref IAudioEntryModel original, IAudioEntryModel clone)
		{
			this.original = original;
			this.clone = clone;
			this.customMetroTextBox_File.Text = this.clone.FilePath;
			this.customMetroTextBox_Keyboard.Text = this.clone.KeyboardName;
			this.keyComboControl.Initialize(this.clone.KeyBinding);
			this.metroCheckBox_UseKeyboard.Checked = this.clone.UseSpecificKeyboard;
			this.volumeControl.Initialize(this.clone.Volume);
			this.customMetroTextBox_Keyboard.Enabled = this.metroCheckBox_UseKeyboard.Checked;
		}

		protected override void Subscribe()
		{
			this.btn_Ok.Click += Btn_OkOnClick;
			this.btn_Cancel.Click += Btn_CancelOnClick;
			this.btn_browse.Click += Btn_browseOnClick;
			this.volumeControl.OnVolumeChanged += (sender, args) => clone.Volume = this.volumeControl.Volume;
			this.keyComboControl.OnComboChanged += (sender, args) => clone.KeyBinding = this.keyComboControl.GetCombo().ToList();
			this.metroCheckBox_UseKeyboard.CheckedChanged += MetroCheckBox_UseKeyboardOnCheckedChanged;

		}

		private void MetroCheckBox_UseKeyboardOnCheckedChanged(object? sender, EventArgs e)
		{
			this.customMetroTextBox_Keyboard.Enabled = this.metroCheckBox_UseKeyboard.Checked;
			this.clone.UseSpecificKeyboard = this.metroCheckBox_UseKeyboard.Checked;
		}

		private void Btn_browseOnClick(object? sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog {Title = "Browse Audio File"};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.customMetroTextBox_File.Text = openFileDialog.FileName;
				this.clone.FilePath = this.customMetroTextBox_File.Text;
			}
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
			original.Volume = clone.Volume;
			original.FilePath = clone.FilePath;
			original.KeyBinding = clone.KeyBinding;
			original.UseSpecificKeyboard = clone.UseSpecificKeyboard;
			original.KeyboardName = clone.KeyboardName;
			clone.SetEntityState(EntityState.None);
		}
	}
}
