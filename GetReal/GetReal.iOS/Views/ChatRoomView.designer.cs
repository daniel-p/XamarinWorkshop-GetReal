// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace GetReal.iOS
{
    [Register ("ChatRoomView")]
    partial class ChatRoomView
    {
        [Outlet]
        UIKit.UIButton ButtonSend { get; set; }


        [Outlet]
        UIKit.UILabel LabelParticipantCount { get; set; }


        [Outlet]
        UIKit.UILabel LabelTitle { get; set; }


        [Outlet]
        UIKit.UITableView TableViewMessages { get; set; }


        [Outlet]
        UIKit.UITextField TextNewMessage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonSend != null) {
                ButtonSend.Dispose ();
                ButtonSend = null;
            }

            if (LabelParticipantCount != null) {
                LabelParticipantCount.Dispose ();
                LabelParticipantCount = null;
            }

            if (LabelTitle != null) {
                LabelTitle.Dispose ();
                LabelTitle = null;
            }

            if (TableViewMessages != null) {
                TableViewMessages.Dispose ();
                TableViewMessages = null;
            }

            if (TextNewMessage != null) {
                TextNewMessage.Dispose ();
                TextNewMessage = null;
            }
        }
    }
}