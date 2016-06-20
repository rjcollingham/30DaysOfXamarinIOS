using System;
using System.Collections.Generic;
using CoreGraphics;
using UIKit;

namespace Project_02_CustomFont
{
	public class CustomFontViewController : UIViewController
	{
		List<string> _sentences = new List<string>
		{
			"I wandered lonely as a cloud",
			"That floats on high o'er vales and hills,",
			"When all at once I saw a crowd,",
			"A host, of golden daffodils;",
			"Beside the lake, beneath the trees,",
			"Fluttering and dancing in the breeze."
		};

		List<string> _fonts = new List<string>
		{
			"PT Sans",
			"Raleway",
			"Ubuntu",
			"BebasNeueRegular",
			"Cabin",
			"Lato",
			"Montserrat",
			"Open Sans",
		};

		LabelTableViewSource _tableSource;
		UITableView _table;
		UILabel _lblFont;


		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return UIStatusBarStyle.LightContent;
		}

		public CustomFontViewController() : base(null, null)
		{
			_tableSource = new LabelTableViewSource(_sentences.ToArray(), _fonts.ToArray());
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.Frame = UIScreen.MainScreen.Bounds;

			View.BackgroundColor = UIColor.Black;

			_table = new UITableView();
			_table.BackgroundColor = UIColor.Black;
			_table.SeparatorColor = UIColor.Clear;
			_table.Source = _tableSource;

			_lblFont = new UILabel();
			_lblFont.LineBreakMode = UILineBreakMode.TailTruncation;
			_lblFont.Font = UIFont.FromName("Helvetica", 20f);
			_lblFont.TextColor = UIColor.White;
			_lblFont.Text = _fonts[0];
			_lblFont.TextAlignment = UITextAlignment.Center;

			UIButton btnChange = new UIButton();
			btnChange.BackgroundColor = new UIColor(red: 0.87f, green: 0.89f, blue: 0.04f, alpha: 1.0f);
			btnChange.SetTitleColor(UIColor.Black, UIControlState.Normal);
			btnChange.SetTitle("Change Font", UIControlState.Normal);
			btnChange.Font = UIFont.FromName("Helvetica", 12);
			btnChange.Layer.CornerRadius = 50;
			btnChange.TouchUpInside += Change_Clicked;

			_table.TranslatesAutoresizingMaskIntoConstraints = false;
			btnChange.TranslatesAutoresizingMaskIntoConstraints = false;
			_lblFont.TranslatesAutoresizingMaskIntoConstraints = false;

			View.Add(_lblFont);
			View.Add(btnChange);
			View.Add(_table);

			var constraints = new[] {
					_lblFont.TopAnchor.ConstraintEqualTo(View.TopAnchor, 30),
				 	_lblFont.WidthAnchor.ConstraintEqualTo(View.WidthAnchor),
				    _lblFont.HeightAnchor.ConstraintEqualTo(50),
					btnChange.BottomAnchor.ConstraintEqualTo(View.BottomAnchor, -50),
					btnChange.HeightAnchor.ConstraintEqualTo(100),
				    btnChange.WidthAnchor.ConstraintEqualTo(100),
				    btnChange.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor),
				    _table.TopAnchor.ConstraintEqualTo(_lblFont.BottomAnchor, 10),
				    _table.WidthAnchor.ConstraintEqualTo(View.WidthAnchor),
			        _table.BottomAnchor.ConstraintEqualTo(btnChange.TopAnchor, -30)

			};
			NSLayoutConstraint.ActivateConstraints(constraints);
		}

		void Change_Clicked(object sender, EventArgs e)
		{
			int ix = _tableSource.ChangeFont();
			_lblFont.Text = _fonts[ix];
			_table.ReloadData();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


