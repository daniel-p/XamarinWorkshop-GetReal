using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace GetReal.Droid.Views
{
    [Activity(Label = "Create User")]
    public class HomeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);
        }
    }
}
