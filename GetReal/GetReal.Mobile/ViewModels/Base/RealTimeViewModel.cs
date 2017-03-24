using GetReal.Mobile.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetReal.Mobile.ViewModels.Base
{
    public class RealtimeViewModel : BaseViewModel
    {
        protected readonly IRealtimeDataService RealtimeService;

        public RealtimeViewModel(IRealtimeDataService realTimeService)
        {
            RealtimeService = realTimeService;
        }
    }
}
