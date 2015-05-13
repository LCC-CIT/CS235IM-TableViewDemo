using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TableViewDemo
{
	partial class DetailViewController : UIViewController
	{
		string detailText;

		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

		public void SetDetailText(string text)
		{
			detailText = text;
		}

		public override void ViewWillAppear (bool animated)
		{
			DwarfDetailTextView.Text = detailText;

			base.ViewWillAppear (animated);
		}
	}
}
