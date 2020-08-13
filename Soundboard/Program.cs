using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Components;
using Soundboard.Entities;

namespace Soundboard
{
	public static class Program
	{
		/// <summary>
		///     Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainView());
		}
	}

	public static class Globals
	{
		public static IList<AudioFileEntity> entityList = new List<AudioFileEntity>();
		public static MetroStyleManager styleManager = new MetroStyleManager();
		public static bool PlaybackEnabled = true;
		public static string DefaultKeyboard = "Default";
	}
}