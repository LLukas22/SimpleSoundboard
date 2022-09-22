using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using SimpleSoundboard.Keyboard.NameService;

//Source https://www.codeproject.com/Articles/17123/Using-Raw-Input-from-C-to-handle-multiple-keyboard
namespace SimpleSoundboard.Keyboard.RawInput
{
	public static class Win32
	{
		public const int KEYBOARD_OVERRUN_MAKE_CODE = 0xFF;
		public const int WM_APPCOMMAND = 0x0319;
		private const int FAPPCOMMANDMASK = 0xF000;
		internal const int FAPPCOMMANDMOUSE = 0x8000;
		internal const int FAPPCOMMANDOEM = 0x1000;

		public const int WM_KEYDOWN = 0x0100;
		public const int WM_KEYUP = 0x0101;
		internal const int WM_SYSKEYDOWN = 0x0104;
		internal const int WM_INPUT = 0x00FF;
		internal const int WM_USB_DEVICECHANGE = 0x0219;

		internal const int VK_SHIFT = 0x10;

		internal const int RI_KEY_MAKE = 0x00; // Key Down
		internal const int RI_KEY_BREAK = 0x01; // Key Up
		internal const int RI_KEY_E0 = 0x02; // Left version of the key
		internal const int RI_KEY_E1 = 0x04; // Right version of the key. Only seems to be set for the Pause/Break key.

		internal const int VK_CONTROL = 0x11;
		internal const int VK_MENU = 0x12;
		internal const int VK_ZOOM = 0xFB;
		internal const int VK_LSHIFT = 0xA0;
		internal const int VK_RSHIFT = 0xA1;
		internal const int VK_LCONTROL = 0xA2;
		internal const int VK_RCONTROL = 0xA3;
		internal const int VK_LMENU = 0xA4;
		internal const int VK_RMENU = 0xA5;

		internal const int SC_SHIFT_R = 0x36;
		internal const int SC_SHIFT_L = 0x2a;

		internal const int RIM_INPUT = 0x00;

		public static int LoWord(int dwValue)
		{
			return dwValue & 0xFFFF;
		}

		public static int HiWord(long dwValue)
		{
			return (int) (dwValue >> 16) & ~FAPPCOMMANDMASK;
		}

		public static ushort LowWord(uint val)
		{
			return (ushort) val;
		}

		public static ushort HighWord(uint val)
		{
			return (ushort) (val >> 16);
		}

		public static uint BuildWParam(ushort low, ushort high)
		{
			return ((uint) high << 16) | low;
		}

		[DllImport("User32.dll", SetLastError = true)]
		internal static extern int GetRawInputData(IntPtr hRawInput, DataCommand command, [Out] out InputData buffer,
			[In] [Out] ref int size, int cbSizeHeader);

		[DllImport("User32.dll", SetLastError = true)]
		internal static extern int GetRawInputData(IntPtr hRawInput, DataCommand command, [Out] IntPtr pData,
			[In] [Out] ref int size, int sizeHeader);

		[DllImport("User32.dll", SetLastError = true)]
		internal static extern uint GetRawInputDeviceInfo(IntPtr hDevice, RawInputDeviceInfo command, IntPtr pData,
			ref uint size);

		[DllImport("user32.dll")]
		private static extern uint GetRawInputDeviceInfo(IntPtr hDevice, uint command, ref DeviceInfo data,
			ref uint dataSize);


		[DllImport("User32.dll", SetLastError = true)]
		internal static extern uint
			GetRawInputDeviceList(IntPtr pRawInputDeviceList, ref uint numberDevices, uint size);

		[DllImport("User32.dll", SetLastError = true)]
		internal static extern bool RegisterRawInputDevices(RawInputDevice[] pRawInputDevice, uint numberDevices,
			uint size);

		[DllImport("user32.dll", SetLastError = true)]
		internal static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr notificationFilter,
			DeviceNotification flags);

		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool UnregisterDeviceNotification(IntPtr handle);

		public static string GetDeviceType(uint device)
		{
			string deviceType;
			switch (device)
			{
				case DeviceType.RimTypemouse:
					deviceType = "MOUSE";
					break;
				case DeviceType.RimTypekeyboard:
					deviceType = "KEYBOARD";
					break;
				case DeviceType.RimTypeHid:
					deviceType = "HID";
					break;
				default:
					deviceType = "UNKNOWN";
					break;
			}

			return deviceType;
		}

		public static string GetDeviceDescription(string device)
		{
			string deviceDesc;
			try
			{
				var deviceKey = RegistryAccess.GetDeviceKey(device);
				deviceDesc = deviceKey.GetValue("DeviceDesc").ToString();
				deviceDesc = deviceDesc.Substring(deviceDesc.IndexOf(';') + 1);
			}
			catch (Exception)
			{
				deviceDesc = "Device is malformed unable to look up in the registry";
			}
			return deviceDesc;
		}
	}
}