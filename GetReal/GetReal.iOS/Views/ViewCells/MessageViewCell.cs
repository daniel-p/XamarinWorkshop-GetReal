using System;

using Foundation;
using GetReal.Mobile.ViewModels.Chat;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace GetReal.iOS
{
	public partial class MessageViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("MessageViewCell");
		public static readonly UINib Nib;

		static MessageViewCell()
		{
			Nib = UINib.FromName("MessageViewCell", NSBundle.MainBundle);
		}

		protected MessageViewCell(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<MessageViewCell, ChatMessageViewModel>();
				set.Bind(LabelUserName).To(vm => vm.UserName);
				set.Bind(LabelMessage).To(vm => vm.Content);
				set.Bind(ActivityIndicator).For("Visibility").To(vm => vm.IsBusy).WithConversion("Visibility");
				set.Apply();
			});
		}
		public override void PrepareForReuse()
		{
			base.PrepareForReuse();
			ActivityIndicator.StartAnimating();
		}
	}
}
