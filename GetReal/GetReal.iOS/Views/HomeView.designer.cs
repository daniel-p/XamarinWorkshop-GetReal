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
    [Register ("HomeView")]
    partial class HomeView
    {
        [Outlet]
        UIKit.UIButton ButtonRegister { get; set; }


        [Outlet]
        UIKit.UITextField TextUserName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonRegister != null) {
                ButtonRegister.Dispose ();
                ButtonRegister = null;
            }

            if (TextUserName != null) {
                TextUserName.Dispose ();
                TextUserName = null;
            }
        }
    }
}