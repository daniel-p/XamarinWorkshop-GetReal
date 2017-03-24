using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using GetReal.Mobile;
using MvvmCross.Droid.Views;

namespace GetReal.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {

			System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => 
			{
				var g = errors;
				return true;
			};
            return new App();
        }
    }
}
