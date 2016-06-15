using System;
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

			View.BackgroundColor = UIColor.FromRGBA(0.0346F,0.018F,0.18F,1);

			UIView vwTop = new UIView(new CGRect(0,20,View.Bounds.Width,View.Bounds.Height/2.5-20));
			vwTop.BackgroundColor = UIColor.FromWhiteAlpha(0.0F, 0.0F);

			btnReset = new UIButton(new CGRect(View.Bounds.Width-100, 20, 68, 32));
			btnReset.SetTitle("Reset", UIControlState.Normal);
			btnReset.BackgroundColor = UIColor.FromWhiteAlpha(0.0F, 0.0F);
			btnReset.Font = UIFont.FromName("AvenirNext-Regular", 14f);
			btnReset.TitleEdgeInsets = new UIEdgeInsets(0, 0, 0, 10);
			btnReset.SetTitleColor(UIColor.White, UIControlState.Normal);
			btnReset.Enabled = false;
			btnReset.TouchUpInside += Reset_Clicked;

			lblTime = new UILabel(new CGRect(0, 48.5, vwTop.Bounds.Width, vwTop.Bounds.Height-100));
			lblTime.LineBreakMode = UILineBreakMode.TailTruncation;
			lblTime.Font = UIFont.FromName("AvenirNext-UltraLight", 100f);
			lblTime.TextColor = UIColor.White;
			lblTime.TextAlignment = UITextAlignment.Center;
			UpdateDisplay();

			vwTop.Add(btnReset);
			vwTop.Add(lblTime);

			btnPause = new UIButton(new CGRect(View.Bounds.Width/2, vwTop.Bounds.Height, View.Bounds.Width / 2, View.Bounds.Height - vwTop.Bounds.Height));
			btnPause.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			btnPause.VerticalAlignment = UIControlContentVerticalAlignment.Center;
			btnPause.BackgroundColor = UIColor.FromRGBA(0.46F, 0.77F, 0.01F, 1);
			btnPause.SetTitleColor(UIColor.White, UIControlState.Normal);
			btnPause.SetImage(UIImage.FromBundle("pause"), UIControlState.Normal);
			btnPause.Enabled = false;
			btnPause.TouchUpInside += Pause_Clicked;

			btnPlay = new UIButton(new CGRect(0, vwTop.Bounds.Height, View.Bounds.Width / 2, View.Bounds.Height - vwTop.Bounds.Height));
			btnPlay.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			btnPlay.VerticalAlignment = UIControlContentVerticalAlignment.Center;
			btnPlay.BackgroundColor = UIColor.FromRGBA(0.4F, 0.47F, 1, 1);
			btnPlay.SetTitleColor(UIColor.White, UIControlState.Normal);
			btnPlay.SetImage(UIImage.FromBundle("play"), UIControlState.Normal);
			btnPlay.TouchUpInside += Play_Clicked;

			View.Add(vwTop);
			View.Add(btnPause);
			View.Add(btnPlay);
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


