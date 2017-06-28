﻿using System;
using Splat;

namespace MarvelFormsReactUI.iOS.Services
{
	public class Logger : ILogger
	{
		public Logger()
		{
		}

		public LogLevel Level { get; set; }

		public void Write([Localizable(false)] string message, LogLevel logLevel)
		{
			Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}]: {logLevel.ToString()}");
			Console.WriteLine($"{message}");
		}
	}
}
