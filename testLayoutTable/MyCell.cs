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
			ProgramatticLabel = new UILabel ();
			ProgramatticLabel.Text = "This is the label that will cause the table cell to auto size. The bounds must be set so that the Label has a >= height, and it must be bound to the container's bottom. All this text must fit in. Right until the end. The end is over... wait for it... wait for it... Here! -> END.";
			ProgramatticLabel.BackgroundColor = UIColor.White;
			ProgramatticLabel.MinimumFontSize = 12;
			ProgramatticLabel.Lines = 0; //To force label to word-wrap and expand.
			ProgramatticLabel.TranslatesAutoresizingMaskIntoConstraints = false;  //Important on the label. But NOT on the parent view.

			_views = new NSDictionary ("label", ProgramatticLabel);

			ContentView.AddSubview (ProgramatticLabel); //NB: Add to the ContentView, not to the cell itself.
		}

		private bool _addedConstraintsAlready = false;
		/// <summary>
		/// Step 1 - ios calculates constraints.
		/// </summary>
		public override void UpdateConstraints ()
		{

			base.UpdateConstraints ();

			if (!_addedConstraintsAlready) {

				//NB: Add constraints to ContentView, not the cell itself.
				var emptyDict = new NSDictionary();
				ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("|-5-[label]-5-|", 0, emptyDict, _views));
				ContentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|-5-[label(>=20)]-10-|", 0, emptyDict, _views));

				_addedConstraintsAlready = true; //To ensure constraints only get added once.
				//base.UpdateConstraints ();
			}

		}

		public void UpdateFonts()
		{
			ProgramatticLabel.Font = UIFont.PreferredHeadline;
		}

		/// <summary>
		/// Step 2 - ios positions the view frames based on constraints.
		/// </summary>
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			this.ContentView.TranslatesAutoresizingMaskIntoConstraints = true; //Keep this default for tableCells, as per https://developer.apple.com/library/ios/documentation/UserExperience/Conceptual/AutolayoutPG/AdoptingAutoLayout/AdoptingAutoLayout.html

			ProgramatticLabel.PreferredMaxLayoutWidth = Frame.Size.Width; //Set preferred width After first call to base.LayoutSubViews, so this has a frame.
		}
	}
}

