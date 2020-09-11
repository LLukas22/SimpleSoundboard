namespace SimpleSoundboard.Views.Views
{
	partial class SettingsView
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
			this.btn_Cancel = new MetroFramework.Controls.MetroButton();
			this.btn_Ok = new MetroFramework.Controls.MetroButton();
			this.keyComboControl = new SimpleSoundboard.Views.Controls.KeyComboControl();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.metroComboBox_Style = new MetroFramework.Controls.MetroComboBox();
			this.metroComboBox_Color = new MetroFramework.Controls.MetroComboBox();
			this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
			this.btn_OpenFolder = new MetroFramework.Controls.MetroButton();
			this.btn_KeyboardInput = new MetroFramework.Controls.MetroButton();
			this.SuspendLayout();
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(327, 256);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 0;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseSelectable = true;
			// 
			// btn_Ok
			// 
			this.btn_Ok.Location = new System.Drawing.Point(246, 256);
			this.btn_Ok.Name = "btn_Ok";
			this.btn_Ok.Size = new System.Drawing.Size(75, 23);
			this.btn_Ok.TabIndex = 1;
			this.btn_Ok.Text = "Ok";
			this.btn_Ok.UseSelectable = true;
			// 
			// keyComboControl
			// 
			this.keyComboControl.ComboLength = 2;
			// 
			// 
			// 
			this.keyComboControl.CustomButton.Image = null;
			this.keyComboControl.CustomButton.Location = new System.Drawing.Point(259, 1);
			this.keyComboControl.CustomButton.Name = "";
			this.keyComboControl.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.keyComboControl.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.keyComboControl.CustomButton.TabIndex = 1;
			this.keyComboControl.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.keyComboControl.CustomButton.UseSelectable = true;
			this.keyComboControl.CustomButton.Visible = false;
			this.keyComboControl.FontSize = MetroFramework.MetroTextBoxSize.Medium;
			this.keyComboControl.Lines = new string[0];
			this.keyComboControl.Location = new System.Drawing.Point(121, 24);
			this.keyComboControl.MaxLength = 32767;
			this.keyComboControl.Name = "keyComboControl";
			this.keyComboControl.PasswordChar = '\0';
			this.keyComboControl.ReadOnly = true;
			this.keyComboControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.keyComboControl.SelectedText = "";
			this.keyComboControl.SelectionLength = 0;
			this.keyComboControl.SelectionStart = 0;
			this.keyComboControl.ShortcutsEnabled = true;
			this.keyComboControl.Size = new System.Drawing.Size(281, 23);
			this.keyComboControl.TabIndex = 4;
			this.keyComboControl.UseSelectable = true;
			this.keyComboControl.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.keyComboControl.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel2.Location = new System.Drawing.Point(7, 22);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(111, 25);
			this.metroLabel2.TabIndex = 17;
			this.metroLabel2.Text = "Stop Combo:";
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel1.Location = new System.Drawing.Point(7, 69);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(108, 25);
			this.metroLabel1.TabIndex = 18;
			this.metroLabel1.Text = "Theme Style:";
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel3.Location = new System.Drawing.Point(7, 117);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(115, 25);
			this.metroLabel3.TabIndex = 19;
			this.metroLabel3.Text = "Theme Color:";
			// 
			// metroComboBox_Style
			// 
			this.metroComboBox_Style.FormattingEnabled = true;
			this.metroComboBox_Style.ItemHeight = 23;
			this.metroComboBox_Style.Location = new System.Drawing.Point(121, 69);
			this.metroComboBox_Style.Name = "metroComboBox_Style";
			this.metroComboBox_Style.Size = new System.Drawing.Size(281, 29);
			this.metroComboBox_Style.TabIndex = 20;
			this.metroComboBox_Style.UseSelectable = true;
			// 
			// metroComboBox_Color
			// 
			this.metroComboBox_Color.FormattingEnabled = true;
			this.metroComboBox_Color.ItemHeight = 23;
			this.metroComboBox_Color.Location = new System.Drawing.Point(121, 117);
			this.metroComboBox_Color.Name = "metroComboBox_Color";
			this.metroComboBox_Color.Size = new System.Drawing.Size(281, 29);
			this.metroComboBox_Color.TabIndex = 21;
			this.metroComboBox_Color.UseSelectable = true;
			// 
			// metroLabel4
			// 
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel4.Location = new System.Drawing.Point(7, 162);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(67, 25);
			this.metroLabel4.TabIndex = 22;
			this.metroLabel4.Text = "Debug:";
			// 
			// btn_OpenFolder
			// 
			this.btn_OpenFolder.Location = new System.Drawing.Point(121, 162);
			this.btn_OpenFolder.Name = "btn_OpenFolder";
			this.btn_OpenFolder.Size = new System.Drawing.Size(281, 36);
			this.btn_OpenFolder.TabIndex = 23;
			this.btn_OpenFolder.Text = "Open Settings Folder";
			this.btn_OpenFolder.UseSelectable = true;
			// 
			// btn_KeyboardInput
			// 
			this.btn_KeyboardInput.Location = new System.Drawing.Point(121, 202);
			this.btn_KeyboardInput.Name = "btn_KeyboardInput";
			this.btn_KeyboardInput.Size = new System.Drawing.Size(281, 36);
			this.btn_KeyboardInput.TabIndex = 24;
			this.btn_KeyboardInput.Text = "Show Raw Keyboard Input";
			this.btn_KeyboardInput.UseSelectable = true;
			// 
			// SettingsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(409, 289);
			this.Controls.Add(this.btn_KeyboardInput);
			this.Controls.Add(this.btn_OpenFolder);
			this.Controls.Add(this.metroLabel4);
			this.Controls.Add(this.metroComboBox_Color);
			this.Controls.Add(this.metroComboBox_Style);
			this.Controls.Add(this.metroLabel3);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.metroLabel2);
			this.Controls.Add(this.keyComboControl);
			this.Controls.Add(this.btn_Ok);
			this.Controls.Add(this.btn_Cancel);
			this.Name = "SettingsView";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroButton btn_Cancel;
		private MetroFramework.Controls.MetroButton btn_Ok;
		private Controls.KeyComboControl keyComboControl;
		private MetroFramework.Controls.MetroLabel metroLabel2;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroLabel metroLabel3;
		private MetroFramework.Controls.MetroComboBox metroComboBox_Style;
		private MetroFramework.Controls.MetroComboBox metroComboBox_Color;
		private MetroFramework.Controls.MetroLabel metroLabel4;
		private MetroFramework.Controls.MetroButton btn_OpenFolder;
		private MetroFramework.Controls.MetroButton btn_KeyboardInput;
	}
}