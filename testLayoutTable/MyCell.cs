using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace testLayoutTable
{
	[Register("MyCell")]
	public partial class  MyCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("EOAScheduleCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("EOAScheduleCell");
		UILabel ProgramatticLabel;

		NSDictionary _views;

		public MyCell ()
		{
			CreateView ();
		}

		public MyCell(IntPtr handle) : base(handle)
		{
			CreateView ();
		}

		void CreateView ()
		{

		}

		private bool _addedConstraintsAlready = false;
		/// <summary>
		/// Step 1 - ios calculates constraints.
		/// </summary>
		public override void UpdateConstraints ()
		{

			base.UpdateConstraints ();

			DataBind ();

			if (!_addedConstraintsAlready) {

				TheCollection.RegisterNibForCell (CollectionItemView.Nib, CollectionItemView.Key);
				_addedConstraintsAlready = true; //To ensure constraints only get added once.
			}

		
		}

		void DataBind ()
		{
			TheCollection.Source = new CustomCollectionSource ();
			SetNeedsLayout (); //We need to layout again, since the data causes a physical size change.
		}

		public void UpdateFonts()
		{

		}

		/// <summary>
		/// Step 2 - ios positions the view frames based on constraints.
		/// </summary>
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			this.ContentView.TranslatesAutoresizingMaskIntoConstraints = true; //Keep this default for tableCells, as per https://developer.apple.com/library/ios/documentation/UserExperience/Conceptual/AutolayoutPG/AdoptingAutoLayout/AdoptingAutoLayout.html

			TheCollection.TranslatesAutoresizingMaskIntoConstraints = false;
			Console.WriteLine ("LayoutSubViews. Collection contentSize is " + TheCollection.ContentSize);
			CollHeightConstraint.Constant = TheCollection.ContentSize.Height;


		}
	}
}

