using System;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework;

namespace SimpleSoundboard.Views.Controls
{
	public class VolumeControl : CustomMetroTextBox
	{
		public float Volume = 1.0f;
		public bool IsValid { get; protected set; }
		public delegate void VolumeChangedHandler(object sender, EventArgs e);
		public event VolumeChangedHandler OnVolumeChanged;
		private ToolTip toolTip = new ToolTip();
		private ErrorProvider errorProvider = new ErrorProvider();
		private readonly string defaultToolTip = "Enter a custom Volume here.(Default=1.0)";

		public VolumeControl()
		{
			FontSize = MetroTextBoxSize.Medium;
			this.Validating += OnValidating;
			toolTip.SetToolTip(this, defaultToolTip);
		}

		private void OnValidating(object sender, CancelEventArgs e)
		{
			if (float.TryParse(Text, out var value))
			{
				errorProvider.SetError(this,null);
				IsValid = true;
				
				Volume = value < 0 ? value*-1f : value;
				RefreshText();
				OnVolumeChanged?.Invoke(this, null);
			}
			else
			{
				IsValid = false;
				errorProvider.SetError(this,$"{Text} is not a valid Value!");
			}
		}

		public void Initialize(float volume)
		{
			Volume = volume;
			RefreshText();
		}

		private void RefreshText()
		{
			Text = string.Empty;
			Text = Volume.ToString();
		}
	}
}
