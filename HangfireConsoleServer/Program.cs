using System;
using Microsoft.Owin.Hosting;
using System.Net.Http;
using Hangfire;
using Hangfire.Console;

namespace HangfireConsoleServer
{
	class Program
	{
		static void Main(string[] args)
		{
			string baseAddress = "http://localhost:9000/";

			GlobalConfiguration.Configuration
				.UseSqlServerStorage("local")
				.UseConsole();

			// Start OWIN host 
			using (WebApp.Start<Startup>(url: baseAddress))
			{
				// Start Hangfire server
				using (var server = new BackgroundJobServer())
				{
					Console.WriteLine("Hangfire Server started. Press any key to exit...");
					Console.ReadLine();
					server.SendStop();
				}
			}
		}
	}
}
