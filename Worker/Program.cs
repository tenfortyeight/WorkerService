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
		}
	}
}