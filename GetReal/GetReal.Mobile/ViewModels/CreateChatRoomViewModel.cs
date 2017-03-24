using GetReal.Core.Models;
using GetReal.Mobile.Services;
using GetReal.Mobile.ViewModels.Base;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReal.Mobile.ViewModels
{
    public class CreateChatRoomViewModel : RealtimeViewModel
    {
        private string _chatRoomName;

        public string ChatRoomName
        {
            get { return _chatRoomName; }
            set { SetProperty(ref _chatRoomName, value); }
        }

        private IMvxCommand _createChatRoomCommand;
        public IMvxCommand CreateChatRoomCommand
        {
            get
            {
                if (_createChatRoomCommand == null)
                {
                    _createChatRoomCommand = new MvxCommand(async () =>
                    {
                        await RealtimeService.CreateChatRoom(new ChatRoom() { Name = (ChatRoomName) });
                        Close(this);
                    });
                }
                return _createChatRoomCommand;
            }
        }

        public CreateChatRoomViewModel(IRealtimeDataService realTimeService) : base(realTimeService)
        {

        }
    }
}
