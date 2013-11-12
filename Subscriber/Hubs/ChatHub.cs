using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Subscriber.Hubs
{
	[HubName("chatter")]
	public class ChatHub : Hub
	{
		public void Send(string name, string message)
		{
			Clients.All.nisse(name, message);
		}
	}
}