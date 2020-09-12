using System;
using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Root;
using Unity;

namespace SimpleSoundboard
{
	internal static class Program
	{
		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			var container = new UnityContainer();
			container.RegisterInstance(container);

			new Registration(container).Register().Initialize();

			Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(container.Resolve<IMainController>().Initialize().SpecificView as Form);
		}
	}
}