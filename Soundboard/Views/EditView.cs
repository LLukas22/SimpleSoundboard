using System;
using System.Drawing;
using System.Windows.Forms;
using Soundboard.Keyboard;
using Soundboard.Presenters;
using Soundboard.RawInput;
using Soundboard.Views;

namespace Soundboard
{
	public partial class EditView : BaseView
	{
		private readonly EditPresenter editPresenter;
		public string filepath;
		public string keyboardHash;
		public (Keys Key1, Keys Key2, Keys Key3) KeysTuple = (Keys.None, Keys.None, Keys.None);
		public bool useDefaultKeyboard;
		public float volume;

		public EditView(EditPresenter editPresenter, KeyboardController keyboardController)
		{
			InitializeComponent();
			this.editPresenter = editPresenter;
			keyboardController.RawInput.KeyPressed += delegate(object sender, RawInputEventArg arg)
			{
				keyboardHash = arg.Hash;
				textbox_keyboard.Text = keyboardHash;
			};
			Globals.styleManager.Clone(this);
		}

		private void CancleButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void EditView_Load(object sender, EventArgs e)
		{
			Key1.Text = KeysTuple.Key1.ToString();
			Key2.Text = KeysTuple.Key2.ToString();
			key3.Text = KeysTuple.Key3.ToString();
			SelectedFile.Text = filepath;
			textbox_keyboard.Text = keyboardHash ?? Globals.DefaultKeyboard;
			numeric_Volume.BackColor = BackColor;
			numeric_Volume.ForeColor = Color.AliceBlue;
			numeric_Volume.Refresh();
			numeric_Volume.Value = (decimal) volume;
			useDefaultKeyboard = keyboardHash?.Equals(Globals.DefaultKeyboard, StringComparison.OrdinalIgnoreCase) ??
			                     true;
			cbx_AlwaysDefaultKeyboard.Checked = useDefaultKeyboard;
		}

		private void OpenFileButten_Click(object sender, EventArgs e)
		{
			{
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					filepath = openFileDialog1.FileName;
					SelectedFile.Text = filepath;
				}
			}
		}

		private void Key1_KeyDown(object sender, KeyEventArgs e)
		{
			KeysTuple.Key1 = e.KeyCode;
			Key1.Clear();
			Key1.Text = e.KeyCode.ToString();
		}

		private void Key2_KeyDown(object sender, KeyEventArgs e)
		{
			KeysTuple.Key2 = e.KeyCode;
			Key2.Clear();
			Key2.Text = e.KeyCode.ToString();
		}

		private void key3_KeyDown(object sender, KeyEventArgs e)
		{
			KeysTuple.Key3 = e.KeyCode;
			key3.Clear();
			key3.Text = e.KeyCode.ToString();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			editPresenter.Save();
		}

		private void numeric_Volume_ValueChanged(object sender, EventArgs e)
		{
			if (numeric_Volume.Value >= 0) volume = (float) numeric_Volume.Value;
		}

		private void cbx_AlwaysDefaultKeyboard_CheckedChanged(object sender, EventArgs e)
		{
			if (cbx_AlwaysDefaultKeyboard.Checked)
				textbox_keyboard.Text = Globals.DefaultKeyboard;
			else
				textbox_keyboard.Clear();
			useDefaultKeyboard = cbx_AlwaysDefaultKeyboard.Checked;
		}
	}
}