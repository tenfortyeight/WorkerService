using System.CodeDom;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Subscriber.Startup))]
namespace Subscriber
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			GlobalHost.DependencyResolver.UseSqlServer(ConnectionStringProvider.SignalRPubSub());

			var cfg = new HubConfiguration()
			{
				EnableDetailedErrors = true
			};
			app.MapSignalR(cfg);
		}
	}
}