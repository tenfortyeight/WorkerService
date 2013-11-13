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
			var connectionString = @"Server=.\SqlExpress;Database=SignalRPubSub;User Id=signalRtest;Password=Niss€11;Integrated Security=true";
			GlobalHost.DependencyResolver.UseSqlServer(connectionString);

			var cfg = new HubConfiguration()
			{
				EnableDetailedErrors = true
			};
			app.MapSignalR(cfg);
		}
	}
}