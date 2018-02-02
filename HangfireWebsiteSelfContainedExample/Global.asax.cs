using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HangfireWebsiteSelfContainedExample
{
	public class MvcApplication : System.Web.HttpApplication
	{
		private BackgroundJobServer _backgroundJobServer;

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);


			GlobalConfiguration.Configuration
				.UseSqlServerStorage("HangfireConnection");

			_backgroundJobServer = new BackgroundJobServer();
		}

		protected void Application_End()
		{
			_backgroundJobServer.Dispose();
		}
	}
}
