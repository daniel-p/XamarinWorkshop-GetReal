using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using MvvmCross.Binding.Droid.Views;
using Android.Database;
using System.Collections.Specialized;
using MvvmCross.Binding.Droid.BindingContext;

namespace GetReal.Droid.Views.Chat
{
    [Activity(Label = "Chat")]
    public class ChatRoomView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ChatRoomView);
        }
        protected override void OnStart()
        {
            base.OnStart();
            MvxListView listView = FindViewById<MvxListView>(Resource.Id.messagesListView);
            listView.Adapter = new ScroolToBottomAdapter(listView, this, (MvxAndroidBindingContext)BindingContext);
        }
    }
    internal class ScroolToBottomAdapter : MvxAdapter
    {
        private MvxListView _listView;
        public ScroolToBottomAdapter(MvxListView listView, Context context, MvxAndroidBindingContext bindingContext) : base(context, bindingContext)
        {
            _listView = listView;
        }
        protected override void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsSourceCollectionChanged(sender, e);
            _listView.SmoothScrollToPosition(Count - 1);
        }
    }
}