using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Massive;

namespace Subscriber.Modules
{
	public class HistoryRepository
	{
		

		public IEnumerable<string> GetAll()
		{
			dynamic tbl = new MessageHistory();
			var dataHistory = tbl.Find();

			var history = Deserialize(dataHistory);
			return history;
		}

		private IEnumerable<string> Deserialize(dynamic dataHistory)
		{
			foreach (dynamic dataMessage in dataHistory)
			{
				using (var stream = new MemoryStream(dataMessage.Payload))
				{
					var reader = new BinaryReader(stream);
					var encoding = new UTF8Encoding();
					var bytes = reader.ReadInt32();
					var readBytes = new ArraySegment<byte>(reader.ReadBytes(bytes));
					
					var message = encoding.GetString(readBytes.Array, readBytes.Offset, readBytes.Count);
					yield return message;
				}
			}
		}
	}
	
	public class MessageHistory : DynamicModel
	{
		public MessageHistory() : base("SignalRPubSub", "[SignalR].[Messages_0]", "PayloadId") { }
	}
}