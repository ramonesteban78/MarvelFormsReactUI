using System;
using System.ComponentModel;
using Splat;

namespace MarvelFormsReactUI.Droid.Services
{
    public class Logger : ILogger
    {
		private const string IbercajaPayTag = "MarvelFormsReactUI";

		public Logger()
		{
		}

		public LogLevel Level
		{
			get; set;
		}

		public void Write([Localizable(false)] string message, LogLevel logLevel)
		{
			switch (logLevel)
			{
				case LogLevel.Debug:
					Android.Util.Log.Debug(IbercajaPayTag, $"Debug: {message}");
					break;
				case LogLevel.Error:
					Android.Util.Log.Error(IbercajaPayTag, $"Error: {message}");
					break;
				case LogLevel.Fatal:
					Android.Util.Log.Error(IbercajaPayTag, $"Fatal: {message}");
					break;
				case LogLevel.Info:
					Android.Util.Log.Info(IbercajaPayTag, $"Info: {message}");
					break;
				case LogLevel.Warn:
					Android.Util.Log.Warn(IbercajaPayTag, $"Warn: {message}");
					break;
			}
		}
    }
}
