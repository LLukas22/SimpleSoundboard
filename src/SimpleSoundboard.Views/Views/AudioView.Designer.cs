namespace SimpleSoundboard.Views.Views
{
	partial class AudioView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.customMetroTextBox_File = new SimpleSoundboard.Views.Controls.CustomMetroTextBox();
			this.btn_browse = new MetroFramework.Controls.MetroButton();
			this.keyComboControl = new SimpleSoundboard.Views.Controls.KeyComboControl();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
			this.btn_Ok = new MetroFramework.Controls.MetroButton();
			this.btn_Cancel = new MetroFramework.Controls.MetroButton();
			this.customMetroTextBox_Keyboard = new SimpleSoundboard.Views.Controls.CustomMetroTextBox();
			this.metroCheckBox_UseKeyboard = new MetroFramework.Controls.MetroCheckBox();
			this.volumeControl = new SimpleSoundboard.Views.Controls.VolumeControl();
			this.SuspendLayout();
			// 
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel2.Location = new System.Drawing.Point(23, 71);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(108, 25);
			this.metroLabel2.TabIndex = 18;
			this.metroLabel2.Text = "Play Combo:";
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel1.Location = new System.Drawing.Point(23, 26);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(91, 25);
			this.metroLabel1.TabIndex = 19;
			this.metroLabel1.Text = "Audio File:";
			// 
			// customMetroTextBox_File
			// 
			// 
			// 
			// 
			this.customMetroTextBox_File.CustomButton.Image = null;
			this.customMetroTextBox_File.CustomButton.Location = new System.Drawing.Point(337, 1);
			this.customMetroTextBox_File.CustomButton.Name = "";
			this.customMetroTextBox_File.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.customMetroTextBox_File.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.customMetroTextBox_File.CustomButton.TabIndex = 1;
			this.customMetroTextBox_File.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.customMetroTextBox_File.CustomButton.UseSelectable = true;
			this.customMetroTextBox_File.CustomButton.Visible = false;
			this.customMetroTextBox_File.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.customMetroTextBox_File.Lines = new string[0];
			this.customMetroTextBox_File.Location = new System.Drawing.Point(140, 28);
			this.customMetroTextBox_File.MaxLength = 32767;
			this.customMetroTextBox_File.Name = "customMetroTextBox_File";
			this.customMetroTextBox_File.PasswordChar = '\0';
			this.customMetroTextBox_File.ReadOnly = true;
			this.customMetroTextBox_File.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.customMetroTextBox_File.SelectedText = "";
			this.customMetroTextBox_File.SelectionLength = 0;
			this.customMetroTextBox_File.SelectionStart = 0;
			this.customMetroTextBox_File.ShortcutsEnabled = true;
			this.customMetroTextBox_File.Size = new System.Drawing.Size(359, 23);
			this.customMetroTextBox_File.TabIndex = 20;
			this.customMetroTextBox_File.UseSelectable = true;
			this.customMetroTextBox_File.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.customMetroTextBox_File.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// btn_browse
			// 
			this.btn_browse.Location = new System.Drawing.Point(485, 28);
			this.btn_browse.Name = "btn_browse";
			this.btn_browse.Size = new System.Drawing.Size(30, 23);
			this.btn_browse.TabIndex = 21;
			this.btn_browse.Text = "...";
			this.btn_browse.UseSelectable = true;
			// 
			// keyComboControl
			// 
			this.keyComboControl.ComboLength = 3;
			// 
			// 
			// 
			this.keyComboControl.CustomButton.Image = null;
			this.keyComboControl.CustomButton.Location = new System.Drawing.Point(353, 1);
			this.keyComboControl.CustomButton.Name = "";
			this.keyComboControl.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.keyComboControl.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.keyComboControl.CustomButton.TabIndex = 1;
			this.keyComboControl.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.keyComboControl.CustomButton.UseSelectable = true;
			this.keyComboControl.CustomButton.Visible = false;
			this.keyComboControl.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.keyComboControl.Lines = new string[0];
			this.keyComboControl.Location = new System.Drawing.Point(140, 73);
			this.keyComboControl.MaxLength = 32767;
			this.keyComboControl.Name = "keyComboControl";
			this.keyComboControl.PasswordChar = '\0';
			this.keyComboControl.ReadOnly = true;
			this.keyComboControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.keyComboControl.SelectedText = "";
			this.keyComboControl.SelectionLength = 0;
			this.keyComboControl.SelectionStart = 0;
			this.keyComboControl.ShortcutsEnabled = true;
			this.keyComboControl.Size = new System.Drawing.Size(375, 23);
			this.keyComboControl.TabIndex = 22;
			this.keyComboControl.UseSelectable = true;
			this.keyComboControl.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.keyComboControl.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel3.Location = new System.Drawing.Point(23, 113);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(73, 25);
			this.metroLabel3.TabIndex = 23;
			this.metroLabel3.Text = "Volume:";
			// 
			// metroLabel4
			// 
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel4.Location = new System.Drawing.Point(23, 152);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(87, 25);
			this.metroLabel4.TabIndex = 24;
			this.metroLabel4.Text = "Keyboard:";
			// 
			// btn_Ok
			// 
			this.btn_Ok.Location = new System.Drawing.Point(440, 226);
			this.btn_Ok.Name = "btn_Ok";
			this.btn_Ok.Size = new System.Drawing.Size(75, 23);
			this.btn_Ok.TabIndex = 25;
			this.btn_Ok.Text = "Ok";
			this.btn_Ok.UseSelectable = true;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(359, 226);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 26;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseSelectable = true;
			// 
			// customMetroTextBox_Keyboard
			// 
			// 
			// 
			// 
			this.customMetroTextBox_Keyboard.CustomButton.Image = null;
			this.customMetroTextBox_Keyboard.CustomButton.Location = new System.Drawing.Point(353, 1);
			this.customMetroTextBox_Keyboard.CustomButton.Name = "";
			this.customMetroTextBox_Keyboard.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.customMetroTextBox_Keyboard.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.customMetroTextBox_Keyboard.CustomButton.TabIndex = 1;
			this.customMetroTextBox_Keyboard.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.customMetroTextBox_Keyboard.CustomButton.UseSelectable = true;
			this.customMetroTextBox_Keyboard.CustomButton.Visible = false;
			this.customMetroTextBox_Keyboard.Enabled = false;
			this.customMetroTextBox_Keyboard.Lines = new string[0];
			this.customMetroTextBox_Keyboard.Location = new System.Drawing.Point(140, 177);
			this.customMetroTextBox_Keyboard.MaxLength = 32767;
			this.customMetroTextBox_Keyboard.Name = "customMetroTextBox_Keyboard";
			this.customMetroTextBox_Keyboard.PasswordChar = '\0';
			this.customMetroTextBox_Keyboard.ReadOnly = true;
			this.customMetroTextBox_Keyboard.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.customMetroTextBox_Keyboard.SelectedText = "";
			this.customMetroTextBox_Keyboard.SelectionLength = 0;
			this.customMetroTextBox_Keyboard.SelectionStart = 0;
			this.customMetroTextBox_Keyboard.ShortcutsEnabled = true;
			this.customMetroTextBox_Keyboard.Size = new System.Drawing.Size(375, 23);
			this.customMetroTextBox_Keyboard.TabIndex = 27;
			this.customMetroTextBox_Keyboard.UseSelectable = true;
			this.customMetroTextBox_Keyboard.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.customMetroTextBox_Keyboard.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroCheckBox_UseKeyboard
			// 
			this.metroCheckBox_UseKeyboard.AutoSize = true;
			this.metroCheckBox_UseKeyboard.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
			this.metroCheckBox_UseKeyboard.Location = new System.Drawing.Point(140, 152);
			this.metroCheckBox_UseKeyboard.Name = "metroCheckBox_UseKeyboard";
			this.metroCheckBox_UseKeyboard.Size = new System.Drawing.Size(180, 19);
			this.metroCheckBox_UseKeyboard.TabIndex = 28;
			this.metroCheckBox_UseKeyboard.Text = "Bind To Specific Keyboard";
			this.metroCheckBox_UseKeyboard.UseSelectable = true;
			// 
			// volumeControl
			// 
			// 
			// 
			// 
			this.volumeControl.CustomButton.Image = null;
			this.volumeControl.CustomButton.Location = new System.Drawing.Point(353, 1);
			this.volumeControl.CustomButton.Name = "";
			this.volumeControl.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.volumeControl.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.volumeControl.CustomButton.TabIndex = 1;
			this.volumeControl.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.volumeControl.CustomButton.UseSelectable = true;
			this.volumeControl.CustomButton.Visible = false;
			this.volumeControl.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.volumeControl.Lines = new string[0];
			this.volumeControl.Location = new System.Drawing.Point(140, 113);
			this.volumeControl.MaxLength = 32767;
			this.volumeControl.Name = "volumeControl";
			this.volumeControl.PasswordChar = '\0';
			this.volumeControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.volumeControl.SelectedText = "";
			this.volumeControl.SelectionLength = 0;
			this.volumeControl.SelectionStart = 0;
			this.volumeControl.ShortcutsEnabled = true;
			this.volumeControl.Size = new System.Drawing.Size(375, 23);
			this.volumeControl.TabIndex = 29;
			this.volumeControl.UseSelectable = true;
			this.volumeControl.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.volumeControl.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// AudioView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(531, 261);
			this.Controls.Add(this.volumeControl);
			this.Controls.Add(this.metroCheckBox_UseKeyboard);
			this.Controls.Add(this.customMetroTextBox_Keyboard);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_Ok);
			this.Controls.Add(this.metroLabel4);
			this.Controls.Add(this.metroLabel3);
			this.Controls.Add(this.keyComboControl);
			this.Controls.Add(this.btn_browse);
			this.Controls.Add(this.customMetroTextBox_File);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.metroLabel2);
			this.Name = "AudioView";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroLabel metroLabel2;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private Controls.CustomMetroTextBox customMetroTextBox_File;
		private MetroFramework.Controls.MetroButton btn_browse;
		private Controls.KeyComboControl keyComboControl;
		private MetroFramework.Controls.MetroLabel metroLabel3;
		private MetroFramework.Controls.MetroLabel metroLabel4;
		private MetroFramework.Controls.MetroButton btn_Ok;
		private MetroFramework.Controls.MetroButton btn_Cancel;
		private Controls.CustomMetroTextBox customMetroTextBox_Keyboard;
		private MetroFramework.Controls.MetroCheckBox metroCheckBox_UseKeyboard;
		private Controls.VolumeControl volumeControl;
	}
}