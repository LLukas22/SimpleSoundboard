
using System;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Components;
using SimpleSoundboard.Controller;
using SimpleSoundboard.Interfaces.Models;
using SimpleSoundboard.Root;
using SimpleSoundboard.Views.Views;
using Unity;

namespace SimpleSoundboard
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var container = new UnityContainer();
			container.RegisterInstance(container);

			new Registration(container).Register().Initialize();

			var repositoryManager = container.Resolve<IRepositoryManager>();
			repositoryManager.Save();
			Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(container.Resolve<IMainController>().SpecificView as Form);
		}
	}
}
