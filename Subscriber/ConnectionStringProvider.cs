using System.Configuration;

namespace Subscriber
{
	public class ConnectionStringProvider
	{
		public static string SignalRPubSub()
		{
			var connectionString = ConfigurationManager.ConnectionStrings["SignalRPubSub"].ConnectionString;

			return connectionString;
		}
	}
}