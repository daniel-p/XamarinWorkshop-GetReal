using GetReal.Mobile.ViewModels.Base;
using MvvmCross.Core.ViewModels;

namespace GetReal.Mobile.ViewModels.Chat
{
    public class ChatMessageViewModel : RecordViewModel
    {
        private string _content;

        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
    }
}