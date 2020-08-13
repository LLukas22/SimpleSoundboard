using System.Windows.Forms;

namespace Soundboard
{
    partial class EditView
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
			this.OpenFileButten = new MetroFramework.Controls.MetroButton();
			this.SelectedFile = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.Key1 = new MetroFramework.Controls.MetroTextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.Plus_Lable = new MetroFramework.Controls.MetroLabel();
			this.Key2 = new MetroFramework.Controls.MetroTextBox();
			this.CancleButton = new MetroFramework.Controls.MetroButton();
			this.AddButton = new MetroFramework.Controls.MetroButton();
			this.key3 = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.label_Keyboard = new MetroFramework.Controls.MetroLabel();
			this.label_Volume = new MetroFramework.Controls.MetroLabel();
			this.numeric_Volume = new System.Windows.Forms.NumericUpDown();
			this.cbx_AlwaysDefaultKeyboard = new MetroFramework.Controls.MetroCheckBox();
			this.textbox_keyboard = new MetroFramework.Controls.MetroTextBox();
			((System.ComponentModel.ISupportInitialize)(this.numeric_Volume)).BeginInit();
			this.SuspendLayout();
			// 
			// OpenFileButten
			// 
			this.OpenFileButten.Location = new System.Drawing.Point(403, 35);
			this.OpenFileButten.Name = "OpenFileButten";
			this.OpenFileButten.Size = new System.Drawing.Size(93, 23);
			this.OpenFileButten.TabIndex = 0;
			this.OpenFileButten.Text = "Open File";
			this.OpenFileButten.UseSelectable = true;
			this.OpenFileButten.Click += new System.EventHandler(this.OpenFileButten_Click);
			// 
			// SelectedFile
			// 
			// 
			// 
			// 
			this.SelectedFile.CustomButton.Image = null;
			this.SelectedFile.CustomButton.Location = new System.Drawing.Point(365, 1);
			this.SelectedFile.CustomButton.Name = "";
			this.SelectedFile.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.SelectedFile.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.SelectedFile.CustomButton.TabIndex = 1;
			this.SelectedFile.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.SelectedFile.CustomButton.UseSelectable = true;
			this.SelectedFile.CustomButton.Visible = false;
			this.SelectedFile.Lines = new string[0];
			this.SelectedFile.Location = new System.Drawing.Point(10, 35);
			this.SelectedFile.MaxLength = 32767;
			this.SelectedFile.Name = "SelectedFile";
			this.SelectedFile.PasswordChar = '\0';
			this.SelectedFile.ReadOnly = true;
			this.SelectedFile.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.SelectedFile.SelectedText = "";
			this.SelectedFile.SelectionLength = 0;
			this.SelectedFile.SelectionStart = 0;
			this.SelectedFile.ShortcutsEnabled = true;
			this.SelectedFile.Size = new System.Drawing.Size(387, 23);
			this.SelectedFile.TabIndex = 1;
			this.SelectedFile.UseSelectable = true;
			this.SelectedFile.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.SelectedFile.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(7, 77);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(99, 19);
			this.metroLabel1.TabIndex = 2;
			this.metroLabel1.Text = "Button Combo:";
			// 
			// Key1
			// 
			// 
			// 
			// 
			this.Key1.CustomButton.Image = null;
			this.Key1.CustomButton.Location = new System.Drawing.Point(53, 1);
			this.Key1.CustomButton.Name = "";
			this.Key1.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.Key1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.Key1.CustomButton.TabIndex = 1;
			this.Key1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.Key1.CustomButton.UseSelectable = true;
			this.Key1.CustomButton.Visible = false;
			this.Key1.Lines = new string[0];
			this.Key1.Location = new System.Drawing.Point(112, 77);
			this.Key1.MaxLength = 32767;
			this.Key1.Name = "Key1";
			this.Key1.PasswordChar = '\0';
			this.Key1.ReadOnly = true;
			this.Key1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.Key1.SelectedText = "";
			this.Key1.SelectionLength = 0;
			this.Key1.SelectionStart = 0;
			this.Key1.ShortcutsEnabled = true;
			this.Key1.Size = new System.Drawing.Size(75, 23);
			this.Key1.TabIndex = 3;
			this.Key1.UseSelectable = true;
			this.Key1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.Key1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.Key1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key1_KeyDown);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "mp3";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.InitialDirectory = "C:/";
			this.openFileDialog1.Title = "Browse Audio File";
			// 
			// Plus_Lable
			// 
			this.Plus_Lable.AutoSize = true;
			this.Plus_Lable.Location = new System.Drawing.Point(193, 77);
			this.Plus_Lable.Name = "Plus_Lable";
			this.Plus_Lable.Size = new System.Drawing.Size(18, 19);
			this.Plus_Lable.TabIndex = 4;
			this.Plus_Lable.Text = "+";
			// 
			// Key2
			// 
			// 
			// 
			// 
			this.Key2.CustomButton.Image = null;
			this.Key2.CustomButton.Location = new System.Drawing.Point(53, 1);
			this.Key2.CustomButton.Name = "";
			this.Key2.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.Key2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.Key2.CustomButton.TabIndex = 1;
			this.Key2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.Key2.CustomButton.UseSelectable = true;
			this.Key2.CustomButton.Visible = false;
			this.Key2.Lines = new string[0];
			this.Key2.Location = new System.Drawing.Point(217, 77);
			this.Key2.MaxLength = 32767;
			this.Key2.Name = "Key2";
			this.Key2.PasswordChar = '\0';
			this.Key2.ReadOnly = true;
			this.Key2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.Key2.SelectedText = "";
			this.Key2.SelectionLength = 0;
			this.Key2.SelectionStart = 0;
			this.Key2.ShortcutsEnabled = true;
			this.Key2.Size = new System.Drawing.Size(75, 23);
			this.Key2.TabIndex = 5;
			this.Key2.UseSelectable = true;
			this.Key2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.Key2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.Key2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key2_KeyDown);
			// 
			// CancleButton
			// 
			this.CancleButton.Location = new System.Drawing.Point(408, 189);
			this.CancleButton.Name = "CancleButton";
			this.CancleButton.Size = new System.Drawing.Size(75, 23);
			this.CancleButton.Style = MetroFramework.MetroColorStyle.Orange;
			this.CancleButton.TabIndex = 6;
			this.CancleButton.Text = "Cancle";
			this.CancleButton.UseSelectable = true;
			this.CancleButton.Click += new System.EventHandler(this.CancleButton_Click);
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(322, 189);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(75, 23);
			this.AddButton.TabIndex = 7;
			this.AddButton.Text = "Add";
			this.AddButton.UseSelectable = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// key3
			// 
			// 
			// 
			// 
			this.key3.CustomButton.Image = null;
			this.key3.CustomButton.Location = new System.Drawing.Point(53, 1);
			this.key3.CustomButton.Name = "";
			this.key3.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.key3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.key3.CustomButton.TabIndex = 1;
			this.key3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.key3.CustomButton.UseSelectable = true;
			this.key3.CustomButton.Visible = false;
			this.key3.Lines = new string[0];
			this.key3.Location = new System.Drawing.Point(322, 77);
			this.key3.MaxLength = 32767;
			this.key3.Name = "key3";
			this.key3.PasswordChar = '\0';
			this.key3.ReadOnly = true;
			this.key3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.key3.SelectedText = "";
			this.key3.SelectionLength = 0;
			this.key3.SelectionStart = 0;
			this.key3.ShortcutsEnabled = true;
			this.key3.Size = new System.Drawing.Size(75, 23);
			this.key3.TabIndex = 9;
			this.key3.UseSelectable = true;
			this.key3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.key3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.key3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key3_KeyDown);
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.Location = new System.Drawing.Point(298, 81);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(18, 19);
			this.metroLabel3.TabIndex = 10;
			this.metroLabel3.Text = "+";
			// 
			// label_Keyboard
			// 
			this.label_Keyboard.AutoSize = true;
			this.label_Keyboard.Location = new System.Drawing.Point(38, 144);
			this.label_Keyboard.Name = "label_Keyboard";
			this.label_Keyboard.Size = new System.Drawing.Size(68, 19);
			this.label_Keyboard.TabIndex = 12;
			this.label_Keyboard.Text = "Keyboard:";
			// 
			// label_Volume
			// 
			this.label_Volume.AutoSize = true;
			this.label_Volume.Location = new System.Drawing.Point(53, 113);
			this.label_Volume.Name = "label_Volume";
			this.label_Volume.Size = new System.Drawing.Size(53, 19);
			this.label_Volume.TabIndex = 13;
			this.label_Volume.Text = "Volume";
			// 
			// numeric_Volume
			// 
			this.numeric_Volume.DecimalPlaces = 2;
			this.numeric_Volume.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numeric_Volume.Location = new System.Drawing.Point(112, 113);
			this.numeric_Volume.Name = "numeric_Volume";
			this.numeric_Volume.Size = new System.Drawing.Size(285, 20);
			this.numeric_Volume.TabIndex = 14;
			this.numeric_Volume.ValueChanged += new System.EventHandler(this.numeric_Volume_ValueChanged);
			// 
			// cbx_AlwaysDefaultKeyboard
			// 
			this.cbx_AlwaysDefaultKeyboard.AutoSize = true;
			this.cbx_AlwaysDefaultKeyboard.Location = new System.Drawing.Point(403, 148);
			this.cbx_AlwaysDefaultKeyboard.Name = "cbx_AlwaysDefaultKeyboard";
			this.cbx_AlwaysDefaultKeyboard.Size = new System.Drawing.Size(60, 15);
			this.cbx_AlwaysDefaultKeyboard.TabIndex = 15;
			this.cbx_AlwaysDefaultKeyboard.Text = "Always";
			this.cbx_AlwaysDefaultKeyboard.UseSelectable = true;
			this.cbx_AlwaysDefaultKeyboard.CheckedChanged += new System.EventHandler(this.cbx_AlwaysDefaultKeyboard_CheckedChanged);
			// 
			// textbox_keyboard
			// 
			// 
			// 
			// 
			this.textbox_keyboard.CustomButton.Image = null;
			this.textbox_keyboard.CustomButton.Location = new System.Drawing.Point(263, 1);
			this.textbox_keyboard.CustomButton.Name = "";
			this.textbox_keyboard.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.textbox_keyboard.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textbox_keyboard.CustomButton.TabIndex = 1;
			this.textbox_keyboard.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textbox_keyboard.CustomButton.UseSelectable = true;
			this.textbox_keyboard.CustomButton.Visible = false;
			this.textbox_keyboard.Lines = new string[] {
        "Default"};
			this.textbox_keyboard.Location = new System.Drawing.Point(112, 144);
			this.textbox_keyboard.MaxLength = 32767;
			this.textbox_keyboard.Name = "textbox_keyboard";
			this.textbox_keyboard.PasswordChar = '\0';
			this.textbox_keyboard.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textbox_keyboard.SelectedText = "";
			this.textbox_keyboard.SelectionLength = 0;
			this.textbox_keyboard.SelectionStart = 0;
			this.textbox_keyboard.ShortcutsEnabled = true;
			this.textbox_keyboard.Size = new System.Drawing.Size(285, 23);
			this.textbox_keyboard.TabIndex = 16;
			this.textbox_keyboard.Text = "Default";
			this.textbox_keyboard.UseSelectable = true;
			this.textbox_keyboard.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textbox_keyboard.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// EditView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(506, 222);
			this.Controls.Add(this.textbox_keyboard);
			this.Controls.Add(this.cbx_AlwaysDefaultKeyboard);
			this.Controls.Add(this.numeric_Volume);
			this.Controls.Add(this.label_Volume);
			this.Controls.Add(this.label_Keyboard);
			this.Controls.Add(this.metroLabel3);
			this.Controls.Add(this.key3);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.CancleButton);
			this.Controls.Add(this.Key2);
			this.Controls.Add(this.Plus_Lable);
			this.Controls.Add(this.Key1);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.SelectedFile);
			this.Controls.Add(this.OpenFileButten);
			this.Name = "EditView";
			this.Resizable = false;
			this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
			this.Style = MetroFramework.MetroColorStyle.Orange;
			this.Load += new System.EventHandler(this.EditView_Load);
			((System.ComponentModel.ISupportInitialize)(this.numeric_Volume)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton OpenFileButten;
        private MetroFramework.Controls.MetroTextBox SelectedFile;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroTextBox Key1;
        private MetroFramework.Controls.MetroLabel Plus_Lable;
        private MetroFramework.Controls.MetroTextBox Key2;
        private MetroFramework.Controls.MetroButton CancleButton;
        private MetroFramework.Controls.MetroButton AddButton;
        private MetroFramework.Controls.MetroTextBox key3;
        private MetroFramework.Controls.MetroLabel metroLabel3;
		private MetroFramework.Controls.MetroLabel label_Keyboard;
		private MetroFramework.Controls.MetroLabel label_Volume;
		private NumericUpDown numeric_Volume;
		private MetroFramework.Controls.MetroCheckBox cbx_AlwaysDefaultKeyboard;
		private MetroFramework.Controls.MetroTextBox textbox_keyboard;
	}
}