using System;
using UIKit;
using Foundation;

namespace testLayoutTable
{
	[Register("CollectionItemView")]
	public partial class  CollectionItemView : UICollectionViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("CollectionItemView", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("CollectionItemView");

		public CollectionItemView (IntPtr handle) : base(handle)
		{
		}
	}
}

