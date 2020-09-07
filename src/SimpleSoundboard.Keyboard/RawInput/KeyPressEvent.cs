using System;

namespace Soundboard.RawInput
{
	public class KeyPressEvent
	{
		private string _source; // Keyboard_XX
		public IntPtr DeviceHandle; // Handle to the device that send the input

		public string
			DeviceName; // i.e. \\?\HID#VID_045E&PID_00DD&MI_00#8&1eb402&0&0000#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}

		public string DeviceType; // KEYBOARD or HID
		public KeyState KeyState;
		public uint Message; // WM_KEYDOWN or WM_KEYUP        
		public string Name; // i.e. Microsoft USB Comfort Curve Keyboard 2000 (Mouse and Keyboard Center)
		public int VKey; // Virtual Key. Corrected for L/R keys(i.e. LSHIFT/RSHIFT) and Zoom
		public string VKeyName; // Virtual Key Name. Corrected for L/R keys(i.e. LSHIFT/RSHIFT) and Zoom

		public string Source
		{
			get => _source;
			set => _source = $"Keyboard_{value.PadLeft(2, '0')}";
		}

		public override string ToString()
		{
			return
				$"Device\n DeviceName: {DeviceName}\n DeviceType: {DeviceType}\n DeviceHandle: {DeviceHandle.ToInt64():X}\n Name: {Name}\n";
		}
	}
}