using System;
using Microsoft.AspNet.SignalR.Client;

namespace Worker
{
	class Program
	{
		static void Main(string[] args)
		{
			const string name = "Console";
			var conn = new HubConnection("http://localhost:55566/"); //TODO: handle fail over scenario
			var proxy = conn.CreateHubProxy("chatter");

			conn.Start().Wait();
			proxy.Invoke("Notify", "Console", conn.ConnectionId);
			string message = null;
			while ((message = Console.ReadLine()) != null)
			{
				proxy.Invoke("Send", name, message).Wait();
			}




			//const string name = "Console";
			//var communicator = MessageCommunicator.Instance;

			//while (true)
			//{
			//	Console.Write("Message: ");
			//	var message = Console.ReadLine();

			//	communicator.SendMessage(name, message);
			//}
		}
	}

	//public class MessageCommunicator : IMessageCommunicator
	//{
	//	private readonly IHubContext _hubContext;
	//	private static IMessageCommunicator _instance;

	//	private MessageCommunicator(IHubContext hubContext)
	//	{
	//		if (hubContext == null) throw new ArgumentNullException("hubContext");
			
	//		_hubContext = hubContext;
	//	}

	//	public static IMessageCommunicator Instance
	//	{
	//		get
	//		{
	//			return _instance ?? new MessageCommunicator(HubContextProvider.GetHubContext<ChatHub>());
	//		}
	//		set { _instance = value; }
	//	}

	//	public void SendMessage(string name, string message)
	//	{
	//		_hubContext.Clients.All.nisse(name, message);
	//	}
	//}

	//public interface IMessageCommunicator
	//{
	//	void SendMessage(string name, string message);
	//}
}