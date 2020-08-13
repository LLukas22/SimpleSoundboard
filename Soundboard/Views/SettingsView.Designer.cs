namespace Soundboard
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
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.Key1 = new MetroFramework.Controls.MetroTextBox();
			this.Plus_Lable = new MetroFramework.Controls.MetroLabel();
			this.Key2 = new MetroFramework.Controls.MetroTextBox();
			this.CancleButton = new MetroFramework.Controls.MetroButton();
			this.OKButton = new MetroFramework.Controls.MetroButton();
			this.btnClear = new MetroFramework.Controls.MetroButton();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.ThemeColor = new MetroFramework.Controls.MetroComboBox();
			this.SuspendLayout();
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel1.Location = new System.Drawing.Point(8, 26);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(166, 25);
			this.metroLabel1.TabIndex = 2;
			this.metroLabel1.Text = "Stop Button Combo:";
			// 
			// Key1
			// 
			// 
			// 
			// 
			this.Key1.CustomButton.Image = null;
			this.Key1.CustomButton.Location = new System.Drawing.Point(76, 1);
			this.Key1.CustomButton.Name = "";
			this.Key1.CustomButton.Size = new System.Drawing.Size(23, 23);
			this.Key1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.Key1.CustomButton.TabIndex = 1;
			this.Key1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.Key1.CustomButton.UseSelectable = true;
			this.Key1.CustomButton.Visible = false;
			this.Key1.Lines = new string[0];
			this.Key1.Location = new System.Drawing.Point(180, 26);
			this.Key1.MaxLength = 32767;
			this.Key1.Name = "Key1";
			this.Key1.PasswordChar = '\0';
			this.Key1.ReadOnly = true;
			this.Key1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.Key1.SelectedText = "";
			this.Key1.SelectionLength = 0;
			this.Key1.SelectionStart = 0;
			this.Key1.ShortcutsEnabled = false;
			this.Key1.Size = new System.Drawing.Size(100, 25);
			this.Key1.TabIndex = 3;
			this.Key1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Key1.UseSelectable = true;
			this.Key1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.Key1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.Key1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key1_KeyDown);
			// 
			// Plus_Lable
			// 
			this.Plus_Lable.AutoSize = true;
			this.Plus_Lable.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.Plus_Lable.Location = new System.Drawing.Point(286, 26);
			this.Plus_Lable.Name = "Plus_Lable";
			this.Plus_Lable.Size = new System.Drawing.Size(24, 25);
			this.Plus_Lable.TabIndex = 4;
			this.Plus_Lable.Text = "+";
			// 
			// Key2
			// 
			// 
			// 
			// 
			this.Key2.CustomButton.Image = null;
			this.Key2.CustomButton.Location = new System.Drawing.Point(76, 1);
			this.Key2.CustomButton.Name = "";
			this.Key2.CustomButton.Size = new System.Drawing.Size(23, 23);
			this.Key2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.Key2.CustomButton.TabIndex = 1;
			this.Key2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.Key2.CustomButton.UseSelectable = true;
			this.Key2.CustomButton.Visible = false;
			this.Key2.Lines = new string[0];
			this.Key2.Location = new System.Drawing.Point(316, 26);
			this.Key2.MaxLength = 32767;
			this.Key2.Name = "Key2";
			this.Key2.PasswordChar = '\0';
			this.Key2.ReadOnly = true;
			this.Key2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.Key2.SelectedText = "";
			this.Key2.SelectionLength = 0;
			this.Key2.SelectionStart = 0;
			this.Key2.ShortcutsEnabled = false;
			this.Key2.Size = new System.Drawing.Size(100, 25);
			this.Key2.TabIndex = 5;
			this.Key2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Key2.UseSelectable = true;
			this.Key2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.Key2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.Key2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key2_KeyDown);
			// 
			// CancleButton
			// 
			this.CancleButton.Location = new System.Drawing.Point(381, 111);
			this.CancleButton.Name = "CancleButton";
			this.CancleButton.Size = new System.Drawing.Size(75, 23);
			this.CancleButton.Style = MetroFramework.MetroColorStyle.Orange;
			this.CancleButton.TabIndex = 6;
			this.CancleButton.Text = "Cancle";
			this.CancleButton.UseSelectable = true;
			this.CancleButton.Click += new System.EventHandler(this.CancleButton_Click);
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(299, 111);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 7;
			this.OKButton.Text = "OK";
			this.OKButton.UseSelectable = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(422, 26);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(34, 25);
			this.btnClear.TabIndex = 9;
			this.btnClear.Text = "Clear";
			this.btnClear.UseSelectable = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.Location = new System.Drawing.Point(8, 60);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(86, 19);
			this.metroLabel3.TabIndex = 13;
			this.metroLabel3.Text = "ThemeColor:";
			// 
			// ThemeColor
			// 
			this.ThemeColor.FormattingEnabled = true;
			this.ThemeColor.ItemHeight = 23;
			this.ThemeColor.Location = new System.Drawing.Point(180, 63);
			this.ThemeColor.Name = "ThemeColor";
			this.ThemeColor.Size = new System.Drawing.Size(276, 29);
			this.ThemeColor.TabIndex = 14;
			this.ThemeColor.UseSelectable = true;
			this.ThemeColor.SelectedIndexChanged += new System.EventHandler(this.ThemeColor_SelectedIndexChanged);
			// 
			// SettingsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(470, 147);
			this.Controls.Add(this.ThemeColor);
			this.Controls.Add(this.metroLabel3);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.CancleButton);
			this.Controls.Add(this.Key2);
			this.Controls.Add(this.Plus_Lable);
			this.Controls.Add(this.Key1);
			this.Controls.Add(this.metroLabel1);
			this.Name = "SettingsView";
			this.Resizable = false;
			this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
			this.Style = MetroFramework.MetroColorStyle.Orange;
			this.Load += new System.EventHandler(this.SettingsView_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox Key1;
        private MetroFramework.Controls.MetroLabel Plus_Lable;
        private MetroFramework.Controls.MetroTextBox Key2;
        private MetroFramework.Controls.MetroButton CancleButton;
        private MetroFramework.Controls.MetroButton OKButton;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox ThemeColor;
    }


}
