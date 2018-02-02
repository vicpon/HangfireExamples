using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HangfireWebsiteSelfContainedExample.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult SendEmail(int emailId)
		{
			// Queue up job that sends the email
			var parentId = Hangfire.BackgroundJob.Enqueue<BackgroundJobs.EmailJobs>(j => j.SendEmail(emailId));
			Hangfire.BackgroundJob.Enqueue(() => Console.WriteLine("hello hangfire"));

			// Schedule a push notification to clients (subscribers) when SendEmail is complete
			Hangfire.BackgroundJob.ContinueWith<BackgroundJobs.EmailJobs>(parentId, x => x.SendToSubscribers(emailId));

			return View("Index");
		}
	}
}