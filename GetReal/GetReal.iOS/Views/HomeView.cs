using System;
using GetReal.Mobile.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace GetReal.iOS
{
	public partial class HomeView : BaseView
	{
		public HomeView() : base("HomeView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var set = this.CreateBindingSet<HomeView, HomeViewModel>();
			set.Bind(TextUserName).To(vm => vm.UserName);
			set.Bind(ButtonRegister).To(vm => vm.CreateUserCommand);
			set.Apply();

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

