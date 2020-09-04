using System;
using System.Drawing;
using System.Windows.Forms;
using NAudio.Gui;

namespace SimpleSoundboard.Views.Controls
{
	public class MetroVolumeSlider : VolumeSlider
	{
		private readonly float MinDb = -48f;
		public Brush RectangleBrush { get; set; } = Brushes.LightGreen;
		public Pen RectangleBorder { get; set; } = Pens.Black;
		public Brush TextBrush { get; set; } = Brushes.Black;

		protected override void OnPaint(PaintEventArgs pe)
		{
			var format = new StringFormat();
			format.LineAlignment = StringAlignment.Center;
			format.Alignment = StringAlignment.Center;
			pe.Graphics.DrawRectangle(RectangleBorder, 0, 0, Width - 1, Height - 1);
			var num1 = 20f * (float)Math.Log10(Volume);
			var num2 = (float)(1.0 - num1 / (double)MinDb);
			pe.Graphics.FillRectangle(RectangleBrush, 1, 1, (int)((Width - 2) * (double)num2), Height - 2);
			var s = string.Format("{0:F2} dB", num1);
			pe.Graphics.DrawString(s, Font, TextBrush, ClientRectangle, format);
		}
	}
}
