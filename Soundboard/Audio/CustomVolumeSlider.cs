using System;
using System.Drawing;
using System.Windows.Forms;

namespace Soundboard.Audio
{
	public class CustomVolumeSlider : NAudio.Gui.VolumeSlider
	{
		private float MinDb = -48f;
		public Brush RectangleBrush { get; set; }= Brushes.LightGreen;
		public Pen RectangleBorder { get; set; } = Pens.Black;
		public Brush TextBrush { get; set; } = Brushes.Black;

		protected override void OnPaint(PaintEventArgs pe)
		{
			StringFormat format = new StringFormat();
			format.LineAlignment = StringAlignment.Center;
			format.Alignment = StringAlignment.Center;
			pe.Graphics.DrawRectangle(RectangleBorder, 0, 0, this.Width - 1, this.Height - 1);
			float num1 = 20f * (float)Math.Log10((double)this.Volume);
			float num2 = (float)(1.0 - (double)num1 / (double)this.MinDb);
			pe.Graphics.FillRectangle(RectangleBrush, 1, 1, (int)((double)(this.Width - 2) * (double)num2), this.Height - 2);
			string s = string.Format("{0:F2} dB", (object)num1);
			pe.Graphics.DrawString(s, this.Font, TextBrush, (RectangleF)this.ClientRectangle, format);
        }
	}
}
