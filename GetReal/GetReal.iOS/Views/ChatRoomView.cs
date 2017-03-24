using System;
using CoreGraphics;
using GetReal.Mobile.ViewModels.Chat;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace GetReal.iOS
{
	public partial class ChatRoomView : BaseView
	{
		public ChatRoomView() : base("ChatRoomView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var source = new ScrollToBootomTableViewSource(TableViewMessages, "MessageViewCell");

			var set = this.CreateBindingSet<ChatRoomView, ChatRoomViewModel>();
			set.Bind(source).For(s => s.ItemsSource).To(vm => vm.Messages);
			set.Bind(TextNewMessage).To(vm => vm.NewMessage);
			set.Bind(ButtonSend).To(vm => vm.SendMessageCommand);
			set.Apply();
			CGPoint offset = new CGPoint(0, TableViewMessages.ContentSize.Height - TableViewMessages.Frame.Size.Height);
			TableViewMessages.SetContentOffset(offset, false);
			TableViewMessages.Source = source;
			TableViewMessages.ReloadData();


		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}

	internal class ScrollToBootomTableViewSource : MvxSimpleTableViewSource
	{
		public  ScrollToBootomTableViewSource(UITableView tableView, string nibName):base(tableView, nibName)
		{
			
		}
		protected override void CollectionChangedOnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs args)
		{
			base.CollectionChangedOnCollectionChanged(sender, args);
			CGPoint offset = new CGPoint(0, TableView.ContentSize.Height - TableView.Frame.Size.Height);
			if (offset.Y >= TableView.ContentOffset.Y)
			{
				TableView.SetContentOffset(offset, true);
			}
		}
	}
}

