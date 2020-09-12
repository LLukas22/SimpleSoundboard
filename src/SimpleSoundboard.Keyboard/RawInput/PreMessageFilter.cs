using System.Windows.Forms;

//Source https://www.codeproject.com/Articles/17123/Using-Raw-Input-from-C-to-handle-multiple-keyboard
namespace SimpleSoundboard.Keyboard.RawInput
{
	public class PreMessageFilter : IMessageFilter
	{
		// true  to filter the message and stop it from being dispatched 
		// false to allow the message to continue to the next filter or control.
		public bool PreFilterMessage(ref Message m)
		{
			return m.Msg == Win32.WM_KEYDOWN;
		}
	}
}