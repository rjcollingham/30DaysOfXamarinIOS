using System;
using System.Collections.Generic;
using System.Timers;
using CoreGraphics;
using UIKit;

namespace Project_01_SimpleStopWatch
{
	public partial class StopWatchViewController : UIViewController
	{
		UIButton btnReset;
		UIButton btnPlay;
		UIButton btnPause;
		UILabel lblTime;
		Timer timer;

		double Counter = 0.0;

		public StopWatchViewController() : base("StopWatchViewController", null)
		{
			timer = new Timer(100);
			timer.Elapsed += Time_Trigger;
		}

		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return UIStatusBarStyle.LightContent;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.Frame = UIScreen.MainScreen.Bounds;

			View.BackgroundColor = UIColor.FromRGBA(0.0346F, 0.018F, 0.18F, 1);

			UIView vwTop = new UIView();
			vwTop.BackgroundColor = UIColor.FromWhiteAlpha(0.0F, 0.0F);

			btnReset = new UIButton();
			btnReset.SetTitle("Reset", UIControlState.Normal);
			btnReset.BackgroundColor = UIColor.FromWhiteAlpha(0.0F, 0.0F);
			btnReset.Font = UIFont.FromName("AvenirNext-Regular", 14f);
			btnReset.TitleEdgeInsets = new UIEdgeInsets(0, 0, 0, 10);
			btnReset.SetTitleColor(UIColor.White, UIControlState.Normal);
			btnReset.Enabled = false;
			btnReset.TouchUpInside += Reset_Clicked;

			lblTime = new UILabel();
			lblTime.LineBreakMode = UILineBreakMode.TailTruncation;
			lblTime.Font = UIFont.FromName("AvenirNext-UltraLight", 100f);
			lblTime.TextColor = UIColor.White;
			lblTime.TextAlignment = UITextAlignment.Center;
			UpdateDisplay();

			vwTop.Add(btnReset);
			vwTop.Add(lblTime);

			btnPause = new UIButton();
			btnPause.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			btnPause.VerticalAlignment = UIControlContentVerticalAlignment.Center;
			btnPause.BackgroundColor = UIColor.FromRGBA(0.46F, 0.77F, 0.01F, 1);
			btnPause.SetTitleColor(UIColor.White, UIControlState.Normal);
			btnPause.SetImage(UIImage.FromBundle("pause"), UIControlState.Normal);
			btnPause.Enabled = false;
			btnPause.TouchUpInside += Pause_Clicked;

			btnPlay = new UIButton();
			btnPlay.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			btnPlay.VerticalAlignment = UIControlContentVerticalAlignment.Center;
			btnPlay.BackgroundColor = UIColor.FromRGBA(0.4F, 0.47F, 1, 1);
			btnPlay.SetTitleColor(UIColor.White, UIControlState.Normal);
			btnPlay.SetImage(UIImage.FromBundle("play"), UIControlState.Normal);
			btnPlay.TouchUpInside += Play_Clicked;

			View.Add(vwTop);
			View.Add(btnPause);
			View.Add(btnPlay);

			vwTop.TranslatesAutoresizingMaskIntoConstraints = false;
			btnReset.TranslatesAutoresizingMaskIntoConstraints = false;
			lblTime.TranslatesAutoresizingMaskIntoConstraints = false;
			btnPlay.TranslatesAutoresizingMaskIntoConstraints = false;
			btnPause.TranslatesAutoresizingMaskIntoConstraints = false;

			var constraints = new[] {
						 vwTop.TopAnchor.ConstraintEqualTo(View.TopAnchor),
						 vwTop.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor),
						 vwTop.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor),
						 vwTop.HeightAnchor.ConstraintEqualTo(View.HeightAnchor,0.33F),
						 vwTop.WidthAnchor.ConstraintEqualTo(View.WidthAnchor),

						 btnReset.WidthAnchor.ConstraintEqualTo(68),
						 btnReset.TopAnchor.ConstraintEqualTo(vwTop.TopAnchor, 20),
						 btnReset.TrailingAnchor.ConstraintEqualTo(vwTop.TrailingAnchor, -20),

						 lblTime.WidthAnchor.ConstraintEqualTo(vwTop.WidthAnchor),
						 lblTime.TopAnchor.ConstraintEqualTo(vwTop.TopAnchor),
						 lblTime.BottomAnchor.ConstraintEqualTo(vwTop.BottomAnchor),
						 lblTime.LeadingAnchor.ConstraintEqualTo(vwTop.LeadingAnchor),
						 lblTime.TrailingAnchor.ConstraintEqualTo(vwTop.TrailingAnchor),

						 btnPlay.TopAnchor.ConstraintEqualTo(vwTop.BottomAnchor),
						 btnPlay.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor),
						 btnPlay.WidthAnchor.ConstraintEqualTo(View.WidthAnchor, 0.5F),
						 btnPlay.BottomAnchor.ConstraintEqualTo(View.BottomAnchor),

						 btnPause.TopAnchor.ConstraintEqualTo(vwTop.BottomAnchor),
						 btnPause.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor),
						 btnPause.WidthAnchor.ConstraintEqualTo(View.WidthAnchor, 0.5F),
						 btnPause.BottomAnchor.ConstraintEqualTo(View.BottomAnchor),

			};
			NSLayoutConstraint.ActivateConstraints(constraints);
		}

		void Pause_Clicked(object sender, EventArgs e)
		{
			btnReset.Enabled = true;
			btnPlay.Enabled = true;
			btnPause.Enabled = false;
			timer.Stop();
		}

		void Play_Clicked(object sender, EventArgs e)
		{
			btnPlay.Enabled = false;
			btnPause.Enabled = true;
			btnReset.Enabled = false;
			timer.Start();
		}

		void Reset_Clicked(object sender, EventArgs e)
		{
			btnReset.Enabled = false;
			btnPlay.Enabled = true;
			btnPause.Enabled = false;
			Counter = 0.0;
			UpdateDisplay();
		}

		void Time_Trigger(object sender, ElapsedEventArgs e)
		{
			UpdateTimer();
		}

		private void UpdateDisplay()
		{
			InvokeOnMainThread(() =>
			{
				lblTime.Text = Counter.ToString("F1");
			});
		}

		private void UpdateTimer()
		{
			Counter += 0.1;
			UpdateDisplay();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


