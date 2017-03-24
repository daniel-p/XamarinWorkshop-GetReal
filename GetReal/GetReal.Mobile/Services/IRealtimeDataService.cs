using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetReal.Core.Models;

namespace GetReal.Mobile.Services
{
    public interface IRealtimeDataService
	{
		void SendMessage(ChatMessage message);

        void ObserveMessages(Action<ChatMessage> chatRoomUpdatedCallBack);
    }
}