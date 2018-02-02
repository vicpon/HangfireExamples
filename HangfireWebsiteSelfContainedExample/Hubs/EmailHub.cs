using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HangfireWebsiteSelfContainedExample.Hubs
{
	public class EmailHub : Hub
	{
		public async Task Subscribe(int emailId)
		{
			await Groups.Add(Context.ConnectionId, GetGroup(emailId));
			
		}

		public static string GetGroup(int emailId)
		{
			return "email:" + emailId;
		}
	}
}