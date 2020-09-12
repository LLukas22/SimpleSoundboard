using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Components;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Keyboard;
using SimpleSoundboard.Interfaces.Models.Models;
using SimpleSoundboard.Interfaces.Views;
using SimpleSoundboard.Keyboard;
using SimpleSoundboard.Keyboard.NameService;
using SimpleSoundboard.NameService.Models;
using SimpleSoundboard.Views.Base;
using SimpleSoundboard.Views.MessageBox;
using static SimpleSoundboard.NameService.NAudio.SupportedAudioFormats;

namespace SimpleSoundboard.Views.Views
{
	public partial class AudioView : BaseView, IAudioView
	{
		private IAudioEntryModel clone;
		private IKeyboardController keyboardController;
		private IAudioEntryModel original;


		public AudioView(MetroStyleManager styleManager) : base(styleManager)
		{
			InitializeComponent();
		}

		public IAudioView BindData(ref IAudioEntryModel original, IAudioEntryModel clone)
		{
			this.original = original;
			this.clone = clone;
			customMetroTextBox_File.Text = this.clone.FilePath;
			customMetroTextBox_Keyboard.Text = this.clone.KeyboardName;
			keyComboControl.Initialize(this.clone.KeyBinding);
			metroCheckBox_UseKeyboard.Checked = this.clone.UseSpecificKeyboard;
			volumeControl.Initialize(this.clone.Volume);
			customMetroTextBox_Keyboard.Enabled = metroCheckBox_UseKeyboard.Checked;
			keyboardController.OnKeyReleased += KeyboardControllerOnKeyReleased;
			return this;
		}

		public IAudioView WithKeyboardController(IKeyboardController keyboardController)
		{
			this.keyboardController = keyboardController;
			return this;
		}

		private void KeyboardControllerOnKeyReleased(object sender, RawInputEventArgs e)
		{
			//Clean Entity when KeyboardName is not needed
			var oldState = clone.EntityState;
			customMetroTextBox_Keyboard.Text = e.UniqueName;
			clone.KeyboardName = customMetroTextBox_Keyboard.Text;
			if (!clone.UseSpecificKeyboard && oldState == EntityState.None)
				clone.SetEntityState(EntityState.None);
		}

		protected override void Subscribe()
		{
			btn_Ok.Click += Btn_OkOnClick;
			btn_Cancel.Click += Btn_CancelOnClick;
			btn_browse.Click += Btn_browseOnClick;
			volumeControl.OnVolumeChanged += (sender, args) => clone.Volume = volumeControl.Volume;
			keyComboControl.OnComboChanged += (sender, args) => clone.KeyBinding = keyComboControl.GetCombo().ToList();
			metroCheckBox_UseKeyboard.CheckedChanged += MetroCheckBox_UseKeyboardOnCheckedChanged;
		}

		private void MetroCheckBox_UseKeyboardOnCheckedChanged(object? sender, EventArgs e)
		{
			customMetroTextBox_Keyboard.Enabled = metroCheckBox_UseKeyboard.Checked;
			clone.UseSpecificKeyboard = metroCheckBox_UseKeyboard.Checked;
		}

		private void Btn_browseOnClick(object? sender, EventArgs e)
		{
			var openFileDialog = new OpenFileDialog
			{
				Title = "Browse Audio File",
				Filter = $"Audio Files ({CompleteFilter})| {CompleteFilter}"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				customMetroTextBox_File.Text = openFileDialog.FileName;
				clone.FilePath = customMetroTextBox_File.Text;
			}
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
						if (!Save())
							e.Cancel = true;
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
				}

			base.OnClosing(e);
		}

		private void Btn_CancelOnClick(object? sender, EventArgs e)
		{
			Close();
		}

		private void Btn_OkOnClick(object? sender, EventArgs e)
		{
			if (Save())
				Close();
		}

		private bool Save()
		{
			if (!Validate()) return false;
			original.Volume = clone.Volume;
			original.FilePath = clone.FilePath;
			original.KeyBinding = clone.KeyBinding;
			original.UseSpecificKeyboard = clone.UseSpecificKeyboard;
			if (original.UseSpecificKeyboard) original.KeyboardName = clone.KeyboardName;
			clone.SetEntityState(EntityState.None);
			DialogResult = DialogResult.OK;
			return true;
		}

		private new bool Validate()
		{
			if (!File.Exists(clone.FilePath))
			{
				CustomMetroMessageBox.Show(this, $"File {clone.FilePath} does not Exist!", "Error",
					MessageBoxButtons.OK);
				return false;
			}

			if (clone.KeyBinding == null || clone.KeyBinding.Count < 0)
			{
				CustomMetroMessageBox.Show(this, "You must assign a KeyCombo!", "Error",
					MessageBoxButtons.OK);
				return false;
			}

			var match = (controller as IAudioController)?.ValidateKeyCombo(clone);
			if (match != null)
			{
				var message = string.Empty;
				if (clone.UseSpecificKeyboard)
					message =
						$"There already exists an Entry with KeyCombo {clone.KeyBinding.ToStringAdded()} on Keyboard {clone.KeyboardName}";
				else
					message = $"There already exists an Entry with KeyCombo {clone.KeyBinding.ToStringAdded()}";
				CustomMetroMessageBox.Show(this,
					$"There already exists an Entry with KeyCombo {clone.KeyBinding.ToStringAdded()}", "Error",
					MessageBoxButtons.OK);
				return false;
			}

			return true;
		}
	}
}