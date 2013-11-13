using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Communicator.Startup))]
namespace Communicator
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