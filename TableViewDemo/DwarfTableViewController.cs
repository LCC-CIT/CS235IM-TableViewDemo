using Foundation;
using System;
using UIKit;

namespace TableViewDemo
{
	partial class DwarfTableViewController : UITableViewController
	{
		DwarfDataSource dwarfDataSource;

		public DwarfTableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			dwarfDataSource = new DwarfDataSource();
			TableView.Source = dwarfDataSource;
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "DwarfDetailSegue") // set in Storyboard
			{ 
				var detailController = segue.DestinationViewController as DetailViewController;
				if (detailController != null) {
					var rowPath = TableView.IndexPathForSelectedRow;
					var dwarfInfo = dwarfDataSource.GetDwarfInfo(rowPath.Section, rowPath.Row);
					detailController.SetDetailText(dwarfInfo.Type.ToString() + " Dwarf");
					detailController.Title = dwarfInfo.Name;
				}
			}
		}
		/*
		public override string[] SectionIndexTitles (UITableView tableView)
		{

			return base.SectionIndexTitles (tableView);
		}
		*/
	}
}
