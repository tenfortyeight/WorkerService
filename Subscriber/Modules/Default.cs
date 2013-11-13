using Nancy;

namespace Subscriber.Modules
{
	public class Default : NancyModule
	{
		public Default()
		{
			Get["/"] = parameters =>
			{
				var history = new HistoryRepository();
				history.GetAll();

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

	public class HistoryRepository
	{
		public void GetAll()
		{
			
		}
	}
}