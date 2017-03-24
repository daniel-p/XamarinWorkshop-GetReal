using System;
using Foundation;
using MvvmCross.iOS.Views;

namespace GetReal.iOS
{
	public class BaseView : MvxViewController
	{
		public BaseView(string nibName, NSBundle bundle) : base(nibName, bundle)
		{

		}

		public override UIKit.UIRectEdge EdgesForExtendedLayout
		{
			get
			{
				return UIKit.UIRectEdge.None;
			}
			set
			{
				base.EdgesForExtendedLayout = value;
			}
		}
	}
}
