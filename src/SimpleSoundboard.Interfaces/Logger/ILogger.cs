using System;
using SimpleSoundboard.NameService.Logging;

namespace SimpleSoundboard.Interfaces.Logger
{
	public interface ILogger
	{
		void Log(string message, LogLevels logLevel = LogLevels.Information);
		void Log(string message, Exception exception, LogLevels logLevel = LogLevels.Information);
	}
}