using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using GetReal.Core.Models;
using GetReal.Mobile.Services;
using GetReal.Mobile.ViewModels.Base;
using GetReal.Mobile.ViewModels.Chat;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Core;

namespace GetReal.Mobile.ViewModels
{
    public class HomeViewModel : RealtimeViewModel
    {

        private string _userName = string.Empty;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private IMvxCommand _createUserCommand;
        public IMvxCommand CreateUserCommand
        {
            get
            {
                if (_createUserCommand == null)
                {
                    _createUserCommand = new MvxCommand(() =>
                    {
						ShowViewModel<ChatRoomViewModel>(new { userName = UserName });
                    });
                }
                return _createUserCommand;
            }
        }

        public HomeViewModel(IRealtimeDataService realTimeService) : base(realTimeService)
        {

        }
    }
}
