using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleSoundboard.NameService
{
	public static class ApplicationConstants
	{
		public static string SettingsDirectory =>Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "SimpleSoundboard");
	}
}
