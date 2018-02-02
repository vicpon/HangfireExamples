using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(HangfireWebsiteSelfContainedExample.Startup))]

namespace HangfireWebsiteSelfContainedExample
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR();
			app.UseHangfireDashboard();
		}
	}
}
