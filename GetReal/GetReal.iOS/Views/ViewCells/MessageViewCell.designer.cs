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
    [Register ("MessageViewCell")]
    partial class MessageViewCell
    {
        [Outlet]
        UIKit.UIActivityIndicatorView ActivityIndicator { get; set; }


        [Outlet]
        UIKit.UILabel LabelMessage { get; set; }


        [Outlet]
        UIKit.UILabel LabelUserName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ActivityIndicator != null) {
                ActivityIndicator.Dispose ();
                ActivityIndicator = null;
            }

            if (LabelMessage != null) {
                LabelMessage.Dispose ();
                LabelMessage = null;
            }

            if (LabelUserName != null) {
                LabelUserName.Dispose ();
                LabelUserName = null;
            }
        }
    }
}