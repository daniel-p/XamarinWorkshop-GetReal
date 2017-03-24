using GetReal.Core.Models;
using GetReal.Mobile.Services;
using GetReal.Mobile.ViewModels.Base;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GetReal.Mobile.ViewModels.Chat
{
    public class ChatRoomViewModel : RealtimeViewModel
	{

		private string _userName;

        private string _newMessage;
        public string NewMessage
        {
            get { return _newMessage; }
            set { SetProperty(ref _newMessage, value); }
        }

        private MvxObservableCollection<ChatMessageViewModel> _messages;
        public MvxObservableCollection<ChatMessageViewModel> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        private IMvxCommand _sendMessageCommand;
        public IMvxCommand SendMessageCommand
        {
            get
            {
                if (_sendMessageCommand == null)
                {
                    _sendMessageCommand = new MvxCommand(() =>
                    {
                        SendMessage();
						SendMessageCommand.RaiseCanExecuteChanged();
					}, () => !IsBusy);
                }
                return _sendMessageCommand;
            }
        }

		private void SendMessage()
        {
            string newMessageId = Guid.NewGuid().ToString();
            ChatMessageViewModel newMessage = new ChatMessageViewModel()
            {
                Id = newMessageId,
                Content = _newMessage,
                IsBusy = true,
				UserName = _userName
					
            };

            Messages.Add(newMessage);

			ChatMessage message = new ChatMessage()
			{
				Id = newMessageId,
				Content = _newMessage,
				UserName = _userName,
				DateCreated = DateTime.UtcNow
            };

            NewMessage = null;
            RealtimeService.SendMessage(message);
        }

        public ChatRoomViewModel(IRealtimeDataService reatimeService) : base(reatimeService)
        {
            Messages = new MvxObservableCollection<ChatMessageViewModel>();
        }

		public void Init(string userName)
		{
			StartObservingMessages();
			_userName = userName;
		}

        private void StartObservingMessages()
        {
            RealtimeService.ObserveMessages(message =>
            {
                ChatMessageViewModel existingMessage = Messages.FirstOrDefault(m => m.Id == message.Id);
                if (existingMessage == null)
                {
					Debug.WriteLine(message.Id);
                    Messages.Add(new ChatMessageViewModel()
                    {
                        Id = message.Id,
                        Content = message.Content,
						UserName = message.UserName
                    });
                }
                else
                {
                    existingMessage.IsBusy = false;
                }
            });
        }
    }
}