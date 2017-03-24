using FirebaseSharp.Portable;
using GetReal.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

		public void SendMessage(ChatMessage message)
        {
            GenerateKey(message);
			_app.Child($"/{KeyMessages}/{message.Id}").Set(message);
        }

		public void ObserveMessages(Action<ChatMessage> messageAddedCallback)
		{
			_app.Child(KeyMessages).On("child_added", (snapshot, callback, error) =>
			{
				messageAddedCallback(snapshot.Value<ChatMessage>());
			});
		}

		private void GenerateKey(Model model)
		{
			model.Id = string.IsNullOrEmpty(model.Id) ? Guid.NewGuid().ToString() : model.Id;
		}

	}
}
