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
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(327, 334);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 0;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseSelectable = true;
			// 
			// btn_Ok
			// 
			this.btn_Ok.Location = new System.Drawing.Point(246, 334);
			this.btn_Ok.Name = "btn_Ok";
			this.btn_Ok.Size = new System.Drawing.Size(75, 23);
			this.btn_Ok.TabIndex = 1;
			this.btn_Ok.Text = "Ok";
			this.btn_Ok.UseSelectable = true;
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.metroLabel1.Location = new System.Drawing.Point(11, 22);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(145, 19);
			this.metroLabel1.TabIndex = 3;
			this.metroLabel1.Text = "Stop Button Combo:";
			// 
			// SettingsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(409, 367);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.btn_Ok);
			this.Controls.Add(this.btn_Cancel);
			this.Name = "SettingsView";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroButton btn_Cancel;
		private MetroFramework.Controls.MetroButton btn_Ok;
		private MetroFramework.Controls.MetroLabel metroLabel1;
	}
}