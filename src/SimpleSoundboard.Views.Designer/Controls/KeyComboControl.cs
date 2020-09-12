using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MetroFramework;

namespace SimpleSoundboard.Views.Controls
{
	public class KeyComboControl : CustomMetroTextBox
	{
		public delegate void ComboChangedHandler(object sender, EventArgs e);

		private List<Keys> keyCombo;

		public KeyComboControl()
		{
			keyCombo = new List<Keys>();
			ReadOnly = true;
			FontSize = MetroTextBoxSize.Medium;
			KeyDown += OnKeyDown;
			var toolTip = new ToolTip();
			toolTip.SetToolTip(this, "Focus this and Start Typing (ESC to Clear Selection)");
		}

		public int ComboLength { get; set; } = 3;
		public event ComboChangedHandler OnComboChanged;

		public void Initialize(IEnumerable<Keys> keyCombo)
		{
			Text = string.Empty;
			this.keyCombo = new List<Keys>(keyCombo ?? new List<Keys>());
			RefreshText();
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (keyCombo.Any(x => x == e.KeyCode))
				return;

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
			OnComboChanged?.Invoke(this, null);
		}

		private void RefreshText()
		{
			Text = string.Empty;
			for (var i = 0; i < keyCombo.Count; i++)
				if (i == keyCombo.Count - 1)
					Text += $"{keyCombo[i]}";
				else
					Text += $"{keyCombo[i]} + ";
		}

		public IEnumerable<Keys> GetCombo()
		{
			return keyCombo;
		}
	}
}