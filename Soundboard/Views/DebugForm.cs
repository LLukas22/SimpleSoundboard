using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Soundboard.RawInput;

namespace Soundboard.Views
{
	public partial class DebugForm : MetroForm
	{
		public DebugForm(RawInput.RawInput rawInput)
		{
			rawInput.KeyPressed += RawInputOnKeyPressed;
			Globals.styleManager.Clone(this);
			InitializeComponent();
		}

		private void RawInputOnKeyPressed(object sender, RawInputEventArg e)
		{
			Hash.Text = e.Hash;
			Info.Text = e.KeyPressEvent.DeviceName;
			KeyboardName.Text = e.KeyPressEvent.Name;
			Key.Text = e.KeyCode.ToString();
		}
	}
}
