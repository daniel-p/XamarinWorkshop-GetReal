using GetReal.Core.Models;
using GetReal.Mobile.Services;
using GetReal.Mobile.ViewModels.Base;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Core;
using System;
using System.Diagnostics;
using System.Linq;

namespace GetReal.Mobile.ViewModels.Chat
{
    public class ChatRoomViewModel : RealtimeViewModel
	{

        private readonly IMvxMainThreadDispatcher _dispatcher;

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
            ChatMessageViewModel newMessage = new ChatMessageViewModel()
            {
                Content = _newMessage,
                IsBusy = true,
				UserName = _userName		
            };

            Messages.Add(newMessage);

            ChatMessage message = new ChatMessage()
            {
                Content = _newMessage,
                UserName = _userName,
            };

            NewMessage = null;
            
            newMessage.Key = RealtimeService.SendMessage(message);
        }

        public ChatRoomViewModel(IRealtimeDataService reatimeService, IMvxMainThreadDispatcher dispatcher) : base(reatimeService)
        {
            Messages = new MvxObservableCollection<ChatMessageViewModel>();
            _dispatcher = dispatcher;
        }

		public void Init(string userName)
		{
			StartObservingMessages();
			_userName = userName;
		}

        private void StartObservingMessages()
        {
            RealtimeService.ObserveMessages((message, key) =>
            {
                _dispatcher.RequestMainThreadAction(() =>
                {
                    ChatMessageViewModel existingMessage = Messages.FirstOrDefault(m => m.Key == key);
                    if (existingMessage == null)
                    {
                        Debug.WriteLine(key);
                        Messages.Add(new ChatMessageViewModel()
                        {
                            Key = key,
                            Content = message.Content,
                            UserName = message.UserName
                        });
                    }
                    else
                    {
                        existingMessage.IsBusy = false;
                    }
                });
            });
        }
    }
}