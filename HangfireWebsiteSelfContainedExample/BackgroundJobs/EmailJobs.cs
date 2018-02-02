using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangfireWebsiteSelfContainedExample.BackgroundJobs
{
	using Hubs;

	public class EmailJobs
	{
		private readonly IHubContext _hubContext;

		public EmailJobs()
            : this(GlobalHost.ConnectionManager.GetHubContext<Hubs.EmailHub>())
        {
		}

		internal EmailJobs(IHubContext hubContext)
		{
			if (hubContext == null) throw new ArgumentNullException(nameof(hubContext));

			_hubContext = hubContext;
		}

		public void SendEmail(int emailId)
		{
			// fetch email from db

			// send email
			Console.WriteLine("Sending email {0}....", emailId);
			System.Threading.Thread.Sleep(new Random().Next(500, 25000));

			// flag email as sent
			Console.WriteLine("Email sent");
		}

		public void SendToSubscribers(int emailId)
		{
			_hubContext.Clients.Group(EmailHub.GetGroup(emailId)).emailSent(emailId);
		}
	}
}