// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace testLayoutTable
{
	partial class MyCell
	{
		[Outlet]
		UIKit.UIButton DesignerButton { get; set; }

		[Outlet]
		UIKit.UICollectionView TheCollection { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DesignerButton != null) {
				DesignerButton.Dispose ();
				DesignerButton = null;
			}

			if (TheCollection != null) {
				TheCollection.Dispose ();
				TheCollection = null;
			}
		}
	}
}
