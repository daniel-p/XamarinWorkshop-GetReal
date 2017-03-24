using GetReal.Mobile.Services;
using GetReal.Mobile.ViewModels.Base;
using GetReal.Mobile.ViewModels.Chat;
using MvvmCross.Core.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GetReal.Mobile.ViewModels
{
    public class ChatRoomsViewModel : RealtimeViewModel
    {
        private IDisposable _roomsObserver;

        private MvxObservableCollection<ChatRoomItemViewModel> _rooms;
        public MvxObservableCollection<ChatRoomItemViewModel> Rooms
        {
            get
            {
                return _rooms;
            }
            set
            {
                SetProperty(ref _rooms, value);
            }
        }

        private IMvxCommand _createChatRoomCommand;
        public IMvxCommand CreateChatRoomCommand
        {
            get
            {
                if (_createChatRoomCommand == null)
                {
                    _createChatRoomCommand = new MvxCommand(() =>
                   {
                       ShowViewModel<CreateChatRoomViewModel>();
                   });
                }
                return _createChatRoomCommand;
            }
        }

        private IMvxCommand _joinChatRoomCommand;
        public IMvxCommand JoinChatRoomCommand
        {
            get
            {
                if (_joinChatRoomCommand == null)
                {
                    _joinChatRoomCommand = new MvxCommand<ChatRoomItemViewModel>(item =>
                   {
                       ShowViewModel<ChatRoomViewModel>(new { chatRoomId = item.Id, roomName = item.Name, participantCount = item.ParticipantCount });
                   });
                }
                return _joinChatRoomCommand;
            }
        }

        public ChatRoomsViewModel(IRealtimeDataService realTimeService) : base(realTimeService)
        {
            Rooms = new MvxObservableCollection<ChatRoomItemViewModel>();
        }

        public void Init()
        {
            IsBusy = true;
            StartObservingRooms();
        }

        private void StartObservingRooms()
        {
            StopObserving();
            RealtimeService.ObserveAllChatRooms( room =>
            {
                if (string.IsNullOrEmpty(room.Id) || string.IsNullOrEmpty(room.Name))
                {
                    return;
                }

                ChatRoomItemViewModel existingRoom = Rooms.FirstOrDefault(r => r.Id == room.Id);
                if (existingRoom == null)
                {
                    Rooms.Add(new ChatRoomItemViewModel()
                    {
                        Name = room.Name,
                        Id = room.Id,
                        ParticipantCount = room.Users == null ? 0 : room.Users.Count
                    });
                }
                else
                {
                    existingRoom.Name = room.Name;
                    existingRoom.ParticipantCount = room.Users == null ? 0 : room.Users.Count;
                }

                IsBusy = false;
            });
        }

        private void StopObserving()
        {
            if (_roomsObserver != null)
            {
                _roomsObserver.Dispose();
                _roomsObserver = null;
            }
        }
    }
}
