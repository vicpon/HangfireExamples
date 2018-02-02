using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;

namespace HangfireConsoleClient
{
	internal class Client
	{
		public static void Start()
		{
			GlobalConfiguration.Configuration
				.UseSqlServerStorage("local");

			System.Threading.Thread.Sleep(1000);

			QueueFireAndForgetJob();
			QueueRecurringJob();
		}

		private static void QueueFireAndForgetJob()
		{
			BackgroundJob.Enqueue(() => Console.WriteLine($"{DateTime.Now} - My first fire n forget job!"));
		}

		private static void QueueRecurringJob()
		{
			RecurringJob.AddOrUpdate("recurring1", () => Console.WriteLine($"{DateTime.Now} - This happens every 1 minute"), Cron.Minutely);
			RecurringJob.AddOrUpdate<AwesomeJob1>("recurring2", (j) => j.Execute(), Cron.Minutely);
		}
	}

	public class AwesomeJob1
	{
		public void Execute()
		{
			Console.WriteLine($"{DateTime.Now} - AwesomeJob1.Execute");
		}
	}
}
