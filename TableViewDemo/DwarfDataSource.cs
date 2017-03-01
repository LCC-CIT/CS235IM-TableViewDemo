using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace TableViewDemo
{
	// *********************** DwarfInfo class ***********************

	public enum DwarfType { Disney, Tolkein, Marvel };

	public class DwarfInfo
	{
		public string Name { get; set; }
		public DwarfType Type { get; set; }
	}


	// *********************** DwarfDataSource class ***********************

	public class DwarfDataSource : UITableViewSource
	{
		//      ---------- Fields -----------
		const string CELL_IDENTIFIER = "dwarfcell"; // set in the Storyboard
		string[] keys;

		// I Hard-coded the dwarf data to show the structure of the data in the 
		// dictionary. This is good as a teaching example, but not the 
		// most elegant way to do this.

		private Dictionary<string, List<DwarfInfo>> indexedTableItems = 
			new Dictionary<string, List<DwarfInfo>>
		{
			{"B", new List<DwarfInfo>
				{ new DwarfInfo{Name = "Balin", Type = DwarfType.Tolkein},
				new DwarfInfo{Name = "Bashful", Type = DwarfType.Disney},
				new DwarfInfo{Name = "Bifur", Type = DwarfType.Tolkein},
				new DwarfInfo{Name = "Bofur", Type = DwarfType.Tolkein},
				new DwarfInfo{Name = "Bombur", Type = DwarfType.Tolkein},
				}
			},
			{"D", new List<DwarfInfo>
				{ new DwarfInfo{Name = "Doc", Type = DwarfType.Disney},
				new DwarfInfo{Name = "Dopey", Type = DwarfType.Disney},
				new DwarfInfo{Name = "Dorin", Type = DwarfType.Tolkein},
				new DwarfInfo{Name = "Dwalin", Type = DwarfType.Tolkein}
				}
			},
			{"E", new List<DwarfInfo>
				{new DwarfInfo{Name = "Eitri", Type = DwarfType.Marvel}}
			},
			{"F", new List<DwarfInfo>
				{new DwarfInfo{Name = "Fili", Type = DwarfType.Tolkein}}
			},
			{"G", new List<DwarfInfo>
				{new DwarfInfo{Name = "Gloin", Type = DwarfType.Tolkein},
				new DwarfInfo{Name = "Grumpy", Type = DwarfType.Disney}
				}
			},
			{"H", new List<DwarfInfo>
				{new DwarfInfo{Name = "Happy", Type = DwarfType.Disney}}
			},
			{"K", new List<DwarfInfo>
				{new DwarfInfo{Name = "Kamorr", Type = DwarfType.Marvel},
				new DwarfInfo{Name = "Kili", Type = DwarfType.Tolkein},
				new DwarfInfo{Name = "Kindra", Type = DwarfType.Marvel}
				}
			},
			{"O", new List<DwarfInfo>
				{new DwarfInfo{Name = "Ori", Type = DwarfType.Tolkein},
				new DwarfInfo{Name = "Oin", Type = DwarfType.Tolkein}
				}
			},
			{"S", new List<DwarfInfo>
				{new DwarfInfo{Name = "Screwbeard", Type = DwarfType.Marvel},
				new DwarfInfo{Name = "Sindri", Type = DwarfType.Marvel},
				new DwarfInfo{Name = "Sleepy", Type = DwarfType.Disney},
				new DwarfInfo{Name = "Sneezy", Type = DwarfType.Disney},
				new DwarfInfo{Name = "Splitlip", Type = DwarfType.Marvel}
				}
			},
			{"T", new List<DwarfInfo>
				{
				new DwarfInfo{Name = "Thorin", Type = DwarfType.Tolkein},
				new DwarfInfo{Name = "Throgg", Type = DwarfType.Marvel},
				new DwarfInfo{Name = "Tooth", Type = DwarfType.Marvel}
				}
			}
		};


		//   ---------- Constructor ---------- 
		public DwarfDataSource ()
		{
			keys = indexedTableItems.Keys.ToArray ();
		}


		//          --------- Methods ----------
		public DwarfInfo GetDwarfInfo(int section, int row)
		{
			return indexedTableItems[keys[section]][row];
		}


		//    ---------- base class overrides ----------
		public override nint NumberOfSections(UITableView tableView)
		{
			return keys.Length;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return indexedTableItems[keys[section]].Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// in a Storyboard, Dequeue will ALWAYS return a cell, 
			var cell = tableView.DequeueReusableCell (CELL_IDENTIFIER);
			// now set the properties as normal

			cell.TextLabel.Text = GetDwarfInfo(indexPath.Section, indexPath.Row).Name;

			return cell;
		}

		public override string[] SectionIndexTitles (UITableView tableView)
		{
			return keys;
		}
	}
}

