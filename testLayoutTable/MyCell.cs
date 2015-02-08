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
			Console.WriteLine ("Cell instantiated.");
			CreateView ();
		}

		void CreateView ()
		{
		}

		public void DataBind (CustomCollectionSource data)
		{
			Console.WriteLine ("Cell.collection data source set again.");
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
			Console.WriteLine ("Table UpdateConstraints. My height is " + this.ContentView.Bounds.Height 
				+ " and that height constraint is " + HeightUpdatedInCode.Constant);
			base.UpdateConstraints ();
			
			if (!_addedConstraintsAlready) {
				TheCollection.ScrollEnabled = false;

				TheCollection.RegisterNibForCell (CollectionItemView.Nib, CollectionItemView.Key);
				_addedConstraintsAlready = true; //To ensure constraints only get added once.
			}
			base.UpdateConstraints ();
			
		}

		nfloat previousCollHeight = 0;
		/// <summary>
		/// Step 2 - ios positions the view frames based on constraints.
		/// </summary>
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			Console.WriteLine ("Table LayoutSubViews. Collection CONTENTSize is " + TheCollection.ContentSize + " and constraint is " + HeightUpdatedInCode.Constant
				+ " and my size is " + this.Bounds.Height);

			this.ContentView.TranslatesAutoresizingMaskIntoConstraints = true; //Keep this default for tableCells, as per https://developer.apple.com/library/ios/documentation/UserExperience/Conceptual/AutolayoutPG/AdoptingAutoLayout/AdoptingAutoLayout.html

			//Only update height if its different, to prevent inifnite loop with updateConstraints.
			if (TheCollection.ContentSize.Height > 0 && TheCollection.ContentSize.Height != previousCollHeight) {
				Console.WriteLine ("Changing the height constraint to TheCollection.ContentSize.Height (" + previousCollHeight + " to "+ TheCollection.ContentSize.Height +") and requesting another updateConstraints.");
				TheCollection.TranslatesAutoresizingMaskIntoConstraints = false;
				HeightUpdatedInCode.Constant = TheCollection.ContentSize.Height;
				previousCollHeight = TheCollection.ContentSize.Height;

				this.SetNeedsUpdateConstraints ();
				//this.SetNeedsLayout ();
				this.UpdateConstraintsIfNeeded ();
			}

		
		}

	}
}

