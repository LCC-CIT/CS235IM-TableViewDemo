using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TableViewDemo
{
	partial class TableViewDemoController : UITableViewController
	{

		private string[] dwarves = {
			"Sleepy", "Sneezy", "Bashful", "Happy",
			"Doc", "Grumpy", "Dopey",
			"Thorin", "Dorin", "Nori", "Ori",
			"Balin", "Dwalin", "Fili", "Kili",
			"Oin", "Gloin", "Bifur", "Bofur",
			"Bombur"
		};

		public TableViewDemoController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			TableView.Source = new DwarfDataSource (dwarves);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "DwarfDetailSegue") { // set in Storyboard
				var detailController = segue.DestinationViewController as DetailViewController;
				if (detailController != null) {
					//var source = TableView.Source as DwarfDataSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					//var item = source.GetItem(rowPath.Row);
					const int NUM_DISNEY_DWARVES = 7;
					string detailText = "";
					if (rowPath.Row < NUM_DISNEY_DWARVES)
						detailText = "Disney dwarves";
					else
						detailText = "Tolkein dwarves";
					detailController.SetDetailText(detailText); // to be defined on the DetailViewController
				}
			}
		}

		public override string[] SectionIndexTitles (UITableView tableView)
		{

			return base.SectionIndexTitles (tableView);
		}
	}
}
