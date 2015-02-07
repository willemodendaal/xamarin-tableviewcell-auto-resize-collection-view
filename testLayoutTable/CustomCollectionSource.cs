using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace testLayoutTable
{
	public class CustomCollectionSource : UICollectionViewSource
	{
		public override nint NumberOfSections (UICollectionView collectionView)
		{
			return 1;
		}

		public override nint GetItemsCount (UICollectionView collectionView, nint section)
		{
			return 6;
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = (CollectionItemView)collectionView.DequeueReusableCell (CollectionItemView.Key, indexPath);
			cell.SetNeedsUpdateConstraints ();
			cell.UpdateConstraintsIfNeeded ();
			return cell;
		}
	}

}

