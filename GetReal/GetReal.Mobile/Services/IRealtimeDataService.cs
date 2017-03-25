using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetReal.Core.Models;

namespace GetReal.Mobile.Services
{
    public interface IRealtimeDataService
	{
		string SendMessage(ChatMessage message);

        void ObserveMessages(Action<ChatMessage, string> chatRoomUpdatedCallBack);
    }
}