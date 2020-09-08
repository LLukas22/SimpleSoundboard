
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimpleSoundboard.Views.Controls
{
	public class KeyComboControl : CustomMetroTextBox
	{
		public int ComboLength { get; set; } = 3;
		private readonly List<Keys> keyCombo;

		public KeyComboControl()
		{
			this.keyCombo = new List<Keys>();
			Text = string.Empty;
			ReadOnly = true;
			KeyDown += OnKeyDown;
			var toolTip = new ToolTip();
			toolTip.SetToolTip(this, "Focus this and Start Typing (ESC to Clear Selection)");
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				keyCombo.Clear();
			}
			else if (keyCombo.Count < ComboLength)
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
			Text = string.Empty;
			for (int i = 0; i < keyCombo.Count; i++)
			{
				if (i == keyCombo.Count - 1)
					Text += $"{keyCombo[i]}";
				else
					Text += $"{keyCombo[i]} + ";
			}
		}

		public IEnumerable<Keys> GetCombo()
		{
			return keyCombo;
		}
	}
}
