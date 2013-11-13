using Microsoft.AspNet.SignalR;

namespace Communicator
{
	public class HubContextProvider
	{
		public static IHubContext GetHubContext<T>() where T : Hub
		{
			var ctx = GlobalHost.ConnectionManager.GetHubContext<T>();
			return ctx;
		}
	}
}