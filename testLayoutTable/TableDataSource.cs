using System;
using UIKit;

namespace testLayoutTable
{
	public class TableDataSource : UITableViewDataSource
	{
		public TableDataSource ()
		{
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return 1;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = (MyCell)tableView.DequeueReusableCell (MyCell.Key);

			cell.UpdateFonts ();
			cell.SetNeedsUpdateConstraints ();
			cell.UpdateConstraintsIfNeeded ();

			return cell;
		}
	}
}

