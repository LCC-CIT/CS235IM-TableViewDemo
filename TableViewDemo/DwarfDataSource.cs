using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace TableViewDemo
{
	public class DwarfDataSource : UITableViewSource
	{


		string[] tableItems;
		const string CELL_IDENTIFIER = "dwarfcell"; // set in the Storyboard

		Dictionary<string, List<string>> indexedTableItems;
		string[] keys;

		public DwarfDataSource (string[] items)
		{
			tableItems = items;

			indexedTableItems = new Dictionary<string, List<string>>();
			foreach (var t in items) {
				if (indexedTableItems.ContainsKey (t[0].ToString ())) {
					indexedTableItems[t[0].ToString ()].Add(t);
				} else {
					indexedTableItems.Add (t[0].ToString (), new List<string>() {t});
				}
			}
			keys = indexedTableItems.Keys.ToArray ();
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// in a Storyboard, Dequeue will ALWAYS return a cell, 
			var cell = tableView.DequeueReusableCell (CELL_IDENTIFIER);
			// now set the properties as normal
			cell.TextLabel.Text = tableItems[indexPath.Row];

			const int NUM_DISNEY_DWARVES = 7;
			if (cell.DetailTextLabel != null) {
				if (indexPath.Row < NUM_DISNEY_DWARVES)
					cell.DetailTextLabel.Text = "Disney dwarves";
				else
					cell.DetailTextLabel.Text = "Tolkein dwarves";
			}

			return cell;
		}

		public override string[] SectionIndexTitles (UITableView tableView)
		{
			return keys;
		}
	}
}

