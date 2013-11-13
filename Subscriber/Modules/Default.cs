using System.Linq;
using Massive;
using Nancy;

namespace Subscriber.Modules
{
	public class Default : NancyModule
	{
		public Default()
		{
			Get["/"] = parameters =>
			{
				var historyRepository = new HistoryRepository();
				var history = historyRepository.GetAll().ToList();

				return View["Publisher"];
			};

			Get["/SignalR/Hubs"] = parameters =>
			{
				return Response.AsFile("/signalr/hubs");
			};

			Get["/jquery/signalr"] = parameters =>
			{
				string path = "Scripts/jquery.signalR-2.0.0.js";

				return Response.AsFile(path);
			};

			Get["/jquery/{version}"] = parameters =>
			{
				string path = string.Format("Scripts/jquery-{0}.js", parameters.version);

				return Response.AsFile(path);
			};
		}
	}
}