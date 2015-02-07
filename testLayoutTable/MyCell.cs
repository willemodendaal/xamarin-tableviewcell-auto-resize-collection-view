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

		public void DataBind (CustomCollectionSource data)
		{
			TheCollection.Source = data;
			SetNeedsUpdateConstraints ();
		}

		public void UpdateFonts()
		{

		}

		
		private bool _addedConstraintsAlready = false;
		/// <summary>
		/// Step 1 - ios calculates constraints.
		/// </summary>
		public override void UpdateConstraints ()
		{
			Console.WriteLine ("Table UpdateConstraints. My height is " + this.Bounds.Height);
			base.UpdateConstraints ();
			
			if (!_addedConstraintsAlready) {
				
				TheCollection.RegisterNibForCell (CollectionItemView.Nib, CollectionItemView.Key);
				_addedConstraintsAlready = true; //To ensure constraints only get added once.
			}
			base.UpdateConstraints ();
			
		}

		int previousCollHeight = 0;
		/// <summary>
		/// Step 2 - ios positions the view frames based on constraints.
		/// </summary>
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			Console.WriteLine ("Table LayoutSubViews. Collection contentSize is " + TheCollection.ContentSize);

			this.ContentView.TranslatesAutoresizingMaskIntoConstraints = true; //Keep this default for tableCells, as per https://developer.apple.com/library/ios/documentation/UserExperience/Conceptual/AutolayoutPG/AdoptingAutoLayout/AdoptingAutoLayout.html

			if (TheCollection.ContentSize.Height > 0 && TheCollection.ContentSize.Height != previousCollHeight) {
				TheCollection.TranslatesAutoresizingMaskIntoConstraints = false;
				CollHeightConstraint.Constant = TheCollection.ContentSize.Height;
				this.ContentView.SetNeedsUpdateConstraints ();
			}

		}
	}
}

