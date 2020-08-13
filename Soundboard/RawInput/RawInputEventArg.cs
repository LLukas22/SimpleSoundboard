using System;
using System.Windows.Forms;

namespace Soundboard.RawInput
{
    public class RawInputEventArg : EventArgs
    {
        public RawInputEventArg(KeyPressEvent arg)
        {
            KeyPressEvent = arg;
        }
        
        public KeyPressEvent KeyPressEvent { get; private set; }

        public string Hash => KeyPressEvent.DeviceName.GetHashCode().ToString();
        public Keys KeyCode => (Keys)KeyPressEvent.VKey;
    }
}
