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
			var connectionString = @"Server=.\SqlExpress;Database=SignalRPubSub;User Id=signalRtest;Password=Niss€11;Integrated Security=true";
			GlobalHost.DependencyResolver.UseSqlServer(connectionString);
			app.MapSignalR();
		}
	}
}