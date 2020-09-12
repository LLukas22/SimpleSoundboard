using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Components;
using NAudio.Gui;
using SimpleSoundboard.Extensions;

namespace SimpleSoundboard.Views.Controls
{
	public class MetroVolumeSlider : VolumeSlider
	{
		private readonly float MinDb = -48f;
		protected Pen rectangleBorder = Pens.Black;
		protected Brush rectangleBrush = Brushes.Orange;
		protected Brush textBrush = Brushes.Black;

		protected override void OnPaint(PaintEventArgs paintEventArgs)
		{
			var format = new StringFormat {LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center};
			paintEventArgs.Graphics.DrawRectangle(rectangleBorder, 0, 0, Width - 1, Height - 1);
			var num1 = 20f * (float) Math.Log10(Volume);
			var num2 = (float) (1.0 - num1 / (double) MinDb);
			paintEventArgs.Graphics.FillRectangle(rectangleBrush, 1, 1, (int) ((Width - 2) * (double) num2),
				Height - 2);
			var s = string.Format("{0:F2} dB", num1);
			paintEventArgs.Graphics.DrawString(s, Font, textBrush, ClientRectangle, format);
		}

		public void WithStyleManager(ref MetroStyleManager styleManager)
		{
			rectangleBorder = styleManager.Theme.ToPen();
			textBrush = styleManager.Theme.ToBrush();
			rectangleBrush = styleManager.Style.ToBrush();
		}
	}
}