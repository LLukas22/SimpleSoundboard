using System.Windows.Forms;
using Soundboard.Audio;

namespace Soundboard
{
    partial class MainView
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.VolumeSlider = new Soundboard.Audio.CustomVolumeSlider();
			this.VolumeSlider2 = new Soundboard.Audio.CustomVolumeSlider();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
			this.metroComboBox2 = new MetroFramework.Controls.MetroComboBox();
			this.Stop = new MetroFramework.Controls.MetroButton();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.Add = new MetroFramework.Controls.MetroButton();
			this.SaveButton = new MetroFramework.Controls.MetroButton();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.Settings = new MetroFramework.Controls.MetroButton();
			this.grid = new MetroFramework.Controls.MetroGrid();
			this.btnPlay = new MetroFramework.Controls.MetroButton();
			this.btnDelete = new MetroFramework.Controls.MetroButton();
			this.DebugLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();
			// 
			// VolumeSlider
			// 
			this.VolumeSlider.BackColor = System.Drawing.Color.Transparent;
			this.VolumeSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VolumeSlider.ForeColor = System.Drawing.Color.White;
			this.VolumeSlider.Location = new System.Drawing.Point(496, 485);
			this.VolumeSlider.Name = "VolumeSlider";
			this.VolumeSlider.Size = new System.Drawing.Size(105, 29);
			this.VolumeSlider.TabIndex = 3;
			this.VolumeSlider.VolumeChanged += new System.EventHandler(this.OnVolumeSliderChanged);
			// 
			// VolumeSlider2
			// 
			this.VolumeSlider2.BackColor = System.Drawing.Color.Transparent;
			this.VolumeSlider2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VolumeSlider2.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.VolumeSlider2.Location = new System.Drawing.Point(496, 520);
			this.VolumeSlider2.Name = "VolumeSlider2";
			this.VolumeSlider2.Size = new System.Drawing.Size(105, 29);
			this.VolumeSlider2.TabIndex = 6;
			this.VolumeSlider2.VolumeChanged += new System.EventHandler(this.OnVolumeSlider2Changed);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "mp3";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.InitialDirectory = "C:/";
			this.openFileDialog1.Title = "Browse Audio File";
			// 
			// metroComboBox1
			// 
			this.metroComboBox1.FormattingEnabled = true;
			this.metroComboBox1.ItemHeight = 23;
			this.metroComboBox1.Location = new System.Drawing.Point(154, 485);
			this.metroComboBox1.Name = "metroComboBox1";
			this.metroComboBox1.Size = new System.Drawing.Size(336, 29);
			this.metroComboBox1.TabIndex = 11;
			this.metroComboBox1.UseSelectable = true;
			this.metroComboBox1.UseStyleColors = true;
			this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.MetroComboBox1_SelectedIndexChanged);
			// 
			// metroComboBox2
			// 
			this.metroComboBox2.FormattingEnabled = true;
			this.metroComboBox2.ItemHeight = 23;
			this.metroComboBox2.Location = new System.Drawing.Point(154, 520);
			this.metroComboBox2.Name = "metroComboBox2";
			this.metroComboBox2.Size = new System.Drawing.Size(336, 29);
			this.metroComboBox2.TabIndex = 12;
			this.metroComboBox2.UseSelectable = true;
			this.metroComboBox2.UseStyleColors = true;
			this.metroComboBox2.SelectedIndexChanged += new System.EventHandler(this.MetroComboBox2_SelectedIndexChanged);
			// 
			// Stop
			// 
			this.Stop.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.Stop.Location = new System.Drawing.Point(496, 80);
			this.Stop.Name = "Stop";
			this.Stop.Size = new System.Drawing.Size(105, 45);
			this.Stop.Style = MetroFramework.MetroColorStyle.Orange;
			this.Stop.TabIndex = 13;
			this.Stop.Text = "Stop";
			this.Stop.UseSelectable = true;
			this.Stop.Click += new System.EventHandler(this.Stop_Click_1);
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel1.Location = new System.Drawing.Point(12, 489);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(136, 25);
			this.metroLabel1.TabIndex = 15;
			this.metroLabel1.Text = "Output Device 1:";
			// 
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel2.Location = new System.Drawing.Point(9, 524);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(139, 25);
			this.metroLabel2.TabIndex = 16;
			this.metroLabel2.Text = "Output Device 2:";
			// 
			// Add
			// 
			this.Add.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.Add.Location = new System.Drawing.Point(496, 131);
			this.Add.Name = "Add";
			this.Add.Size = new System.Drawing.Size(105, 45);
			this.Add.TabIndex = 18;
			this.Add.Text = "Add";
			this.Add.UseSelectable = true;
			this.Add.Click += new System.EventHandler(this.Add_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.SaveButton.Location = new System.Drawing.Point(496, 409);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(105, 45);
			this.SaveButton.TabIndex = 19;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseSelectable = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel3.Location = new System.Drawing.Point(496, 457);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(78, 25);
			this.metroLabel3.TabIndex = 20;
			this.metroLabel3.Text = "Volume :";
			// 
			// Settings
			// 
			this.Settings.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.Settings.Location = new System.Drawing.Point(496, 363);
			this.Settings.Name = "Settings";
			this.Settings.Size = new System.Drawing.Size(105, 40);
			this.Settings.TabIndex = 21;
			this.Settings.Text = "Settings";
			this.Settings.UseSelectable = true;
			this.Settings.Click += new System.EventHandler(this.Settings_Click);
			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToDeleteRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grid.DefaultCellStyle = dataGridViewCellStyle2;
			this.grid.EnableHeadersVisualStyles = false;
			this.grid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.grid.Location = new System.Drawing.Point(12, 30);
			this.grid.MultiSelect = false;
			this.grid.Name = "grid";
			this.grid.ReadOnly = true;
			this.grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.grid.RowTemplate.Height = 30;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(478, 424);
			this.grid.TabIndex = 22;
			this.grid.UseStyleColors = true;
			this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
			// 
			// btnPlay
			// 
			this.btnPlay.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.btnPlay.Location = new System.Drawing.Point(496, 29);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(105, 45);
			this.btnPlay.TabIndex = 23;
			this.btnPlay.Text = "Play";
			this.btnPlay.UseSelectable = true;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.btnDelete.Location = new System.Drawing.Point(496, 182);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(104, 45);
			this.btnDelete.TabIndex = 24;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseSelectable = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// DebugLabel
			// 
			this.DebugLabel.AutoSize = true;
			this.DebugLabel.Location = new System.Drawing.Point(607, 536);
			this.DebugLabel.Name = "DebugLabel";
			this.DebugLabel.Size = new System.Drawing.Size(13, 13);
			this.DebugLabel.TabIndex = 25;
			this.DebugLabel.Text = "?";
			this.DebugLabel.Click += new System.EventHandler(this.DebugLabel_Click);
			// 
			// MainView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 562);
			this.Controls.Add(this.DebugLabel);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnPlay);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.Settings);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.metroLabel3);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.Add);
			this.Controls.Add(this.metroLabel2);
			this.Controls.Add(this.Stop);
			this.Controls.Add(this.metroComboBox2);
			this.Controls.Add(this.metroComboBox1);
			this.Controls.Add(this.VolumeSlider2);
			this.Controls.Add(this.VolumeSlider);
			this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "MainView";
			this.Resizable = false;
			this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
			this.Style = MetroFramework.MetroColorStyle.Orange;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private CustomVolumeSlider VolumeSlider;
        private CustomVolumeSlider VolumeSlider2;
        private OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroComboBox metroComboBox2;
        private MetroFramework.Controls.MetroButton Stop;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton Add;
        private MetroFramework.Controls.MetroButton SaveButton;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton Settings;
        private MetroFramework.Controls.MetroGrid grid;
        private MetroFramework.Controls.MetroButton btnPlay;
        private MetroFramework.Controls.MetroButton btnDelete;
		private Label DebugLabel;
	}
}

