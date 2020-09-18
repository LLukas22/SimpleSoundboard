using System;
using System.Threading;
using System.Windows.Forms;
using SimpleSoundboard.Interfaces.Controller;
using SimpleSoundboard.Interfaces.Logger;
using SimpleSoundboard.Logging;
using SimpleSoundboard.NameService;
using SimpleSoundboard.NameService.Logging;
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
			var logger = new Logger(ApplicationConstants.SettingsDirectory);
			container.RegisterInstance<ILogger>(logger);
			new Registration(container).Register().Initialize();

			logger.Log("Successfully initialized container!");
			Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				Application.Run(container.Resolve<IMainController>().Initialize().SpecificView as Form);
			}
			catch (Exception exception)
			{
				logger.Log("A Fatal Error occurred!",exception,LogLevels.Fatal);
				throw;
			}
		}
	}
}