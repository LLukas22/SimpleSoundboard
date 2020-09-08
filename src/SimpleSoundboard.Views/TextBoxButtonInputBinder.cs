using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSoundboard.Views
{
	public class TextBoxButtonInputBinder
	{
		private readonly TextBox textBox;
		private readonly int comboLength;
		private readonly List<Keys> keyCombo;

		
		public TextBoxButtonInputBinder(TextBox textBox,int comboLength)
		{
			this.textBox = textBox;
			this.comboLength = comboLength;
			this.keyCombo = new List<Keys>(comboLength);
			textBox.Text = string.Empty;
			textBox.ReadOnly = true;
			textBox.KeyDown += OnKeyDown;
			var toolTip = new ToolTip();
			toolTip.SetToolTip(textBox, "Focus this and Start Typing (ESC to Clear Selection)");
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				keyCombo.Clear();
			}
			else if (keyCombo.Count < comboLength)
			{
				keyCombo.Add(e.KeyCode);
			}
			else
			{
				keyCombo.Remove(keyCombo.First());
				keyCombo.Add(e.KeyCode);
			}
			RefreshText();
			return;
		}

		private void RefreshText()
		{
			textBox.Text = string.Empty;
			for (int i = 0; i < keyCombo.Count; i++)
			{
				if (i == keyCombo.Count - 1)
					textBox.Text += $"{keyCombo[i]}";
				else
					textBox.Text += $"{keyCombo[i]} +";
			}
		}

		public IEnumerable<Keys> GetCombo()
		{
			return keyCombo;
		}
	}
}
