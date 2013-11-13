﻿using System;
using Communicator;
using Communicator.Hubs;
using Microsoft.AspNet.SignalR;

namespace Worker
{
	class Program
	{
		static void Main(string[] args)
		{
			const string name = "Console";
			var communicator = MessageCommunicator.Instance;

			while (true)
			{
				Console.Write("Message: ");
				var message = Console.ReadLine();

				communicator.SendMessage(name, message);
			}
		}
	}

	public class MessageCommunicator : IMessageCommunicator
	{
		private readonly IHubContext _hubContext;
		private static IMessageCommunicator _instance;

		private MessageCommunicator(IHubContext hubContext)
		{
			if (hubContext == null) throw new ArgumentNullException("hubContext");
			
			_hubContext = hubContext;
		}

		public static IMessageCommunicator Instance
		{
			get
			{
				return _instance ?? new MessageCommunicator(HubContextProvider.GetHubContext<ChatHub>());
			}
			set { _instance = value; }
		}

		public void SendMessage(string name, string message)
		{
			_hubContext.Clients.All.nisse(name, message);
		}
	}

	public interface IMessageCommunicator
	{
		void SendMessage(string name, string message);
	}
}