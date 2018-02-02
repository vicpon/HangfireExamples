using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using Hangfire.Console;

namespace HangfireConsoleServer
{
	class Host
	{
		public static void Start()
		{
			GlobalConfiguration.Configuration
				.UseSqlServerStorage("local")
				.UseConsole();

			using (var server = new BackgroundJobServer())
			{
				Console.WriteLine("Hangfire Server started. Press any key to exit...");
			}
		}
	}
}
