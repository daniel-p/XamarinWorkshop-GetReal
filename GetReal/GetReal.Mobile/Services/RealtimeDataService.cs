using FirebaseSharp.Portable;
using GetReal.Core.Models;
using System;

namespace GetReal.Mobile.Services
{
    public class RealtimeDataService : IRealtimeDataService
    {
        private const string DataBaseUrl = "https://getreal-36c13.firebaseio.com";

        private const string KeyMessages = "messages";

        private readonly FirebaseApp _app;

		public RealtimeDataService()
		{
			_app = new FirebaseApp(new Uri(DataBaseUrl));
		}

		public string SendMessage(ChatMessage message)
        {
			return _app.Child($"/{KeyMessages}").Push(message).Key;
        }

		public void ObserveMessages(Action<ChatMessage, string> messageAddedCallback)
		{
			_app.Child(KeyMessages).OrderByChild("Timestamp").On("child_added", (snapshot, callback, error) =>
			{
				messageAddedCallback(snapshot.Value<ChatMessage>(), snapshot.Key);
			});
		}

	}
}
