using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Serilog;
using SimpleSoundboard.NameService.Logging;
using ILogger = SimpleSoundboard.Interfaces.Logger.ILogger;

namespace SimpleSoundboard.Logging
{
	public class Logger : ILogger
	{
		public string LoggingDirectory { get; protected set; }
		protected Serilog.Core.Logger logger;
		public Logger(string directory)
		{

			LoggingDirectory = Path.Combine(directory, "logs");
			Directory.CreateDirectory(LoggingDirectory);
			var files = new DirectoryInfo(LoggingDirectory).GetFiles();
			while(files.Length >= 3)
			{
				files.OrderBy(x => x.LastWriteTime).First().Delete();
				files = new DirectoryInfo(LoggingDirectory).GetFiles();
			}
			logger = new LoggerConfiguration().WriteTo.File(Path.Combine(LoggingDirectory, $"{DateTime.Now:yyyy-dd-M--HH-mm-ss}_log.txt"))
				.CreateLogger();
		}

		public void Log(string message, LogLevels logLevel = LogLevels.Information)
		{
			switch (logLevel)
			{
				case LogLevels.Information:
					logger.Information(message);
					break;
				case LogLevels.Error:
					logger.Error(message);
					break;
				case LogLevels.Fatal:
					logger.Fatal(message);
					break;
				case LogLevels.Warning:
					logger.Warning(message);
					break;
				default:
					logger.Information(message);
					break;
			}
		}

		public void Log(string message, Exception exception, LogLevels logLevel = LogLevels.Information)
		{
			switch (logLevel)
			{
				case LogLevels.Information:
					logger.Information(exception, message);
					break;
				case LogLevels.Error:
					logger.Error(exception,message);
					break;
				case LogLevels.Fatal:
					logger.Fatal(exception,message);
					break;
				case LogLevels.Warning:
					logger.Warning(exception,message);
					break;
				default:
					logger.Information(exception,message);
					break;
			}
		}
	}
}
