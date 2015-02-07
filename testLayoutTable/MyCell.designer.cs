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
		UIKit.NSLayoutConstraint CollHeightConstraint { get; set; }

		[Outlet]
		UIKit.UIButton DesignerButton { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint HeightUpdatedInCode { get; set; }

		[Outlet]
		UIKit.UICollectionView TheCollection { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CollHeightConstraint != null) {
				CollHeightConstraint.Dispose ();
				CollHeightConstraint = null;
			}

			if (DesignerButton != null) {
				DesignerButton.Dispose ();
				DesignerButton = null;
			}

			if (TheCollection != null) {
				TheCollection.Dispose ();
				TheCollection = null;
			}

			if (HeightUpdatedInCode != null) {
				HeightUpdatedInCode.Dispose ();
				HeightUpdatedInCode = null;
			}
		}
	}
}
