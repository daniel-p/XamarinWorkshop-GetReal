using GetReal.Core.Models;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReal.Mobile.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        public static string CurrentUserName;

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
    }
}
