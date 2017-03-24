using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace GetReal.Droid
{
    [Activity(
        Label = "GetReal.Droid"
        , MainLauncher = true
        , Icon = "@drawable/ic_launcher"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
