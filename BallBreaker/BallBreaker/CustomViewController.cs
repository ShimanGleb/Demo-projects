using System;
using CoreGraphics;
using UIKit;
using System.Threading;
namespace BallBreaker
{
	public class CustomViewController : UIViewController
	{
		UIImageView ballImage;
		UIImageView rectangleImage;

		UIPanGestureRecognizer panGesture;

		static int directionX=1;
		static int directionY=1;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = UIColor.White;
			Title = "BALL BREAKER!";

			LoadElements();

			panGesture = new UIPanGestureRecognizer(() =>
			{
				if ((panGesture.State == UIGestureRecognizerState.Began || panGesture.State == UIGestureRecognizerState.Changed))
				{
					var p0 = panGesture.LocationInView(View);

					MoveRect(p0.X);
				}
			});

			View.AddGestureRecognizer(panGesture);

			Thread ballMoverThread = new Thread(() => {
				bool lost = false;
				while (true)
				{
					InvokeOnMainThread(() =>
					{
						if (ballImage.Frame.Y >= (rectangleImage.Frame.Y - rectangleImage.Bounds.Size.Height) 
						    && ballImage.Frame.X >= rectangleImage.Frame.X - ballImage.Frame.Size.Width 
						    && ballImage.Frame.X <= (rectangleImage.Frame.X + rectangleImage.Bounds.Size.Width))
							{
								directionY *= -1;
							}
						if (ballImage.Frame.X >= View.Bounds.Size.Width - ballImage.Bounds.Size.Width || ballImage.Frame.X <= 0)
						{
							directionX *= -1;
						}

						if (ballImage.Frame.Y >= View.Bounds.Size.Height - ballImage.Bounds.Size.Height)
						{
							lost = true;
						}
						if (ballImage.Frame.Y <= 0)
						{
							directionY *= -1;
						}
						ballImage.Center = new CGPoint(ballImage.Center.X + directionX, ballImage.Center.Y + directionY);
					});
					if (lost)
					{
						InvokeOnMainThread(() =>
						{
							UILabel lostLabel = new UILabel();
							lostLabel.Text = "YOU LOST!";
							lostLabel.TextColor = UIColor.Red;
							lostLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);

							lostLabel.Frame = new CGRect(new CGPoint(View.Bounds.Width *0.35, View.Bounds.Height *0.4), new CGSize(View.Bounds.Size.Width, 100));

							View.AddSubview(lostLabel);
						});
						break;
					}
					Thread.Sleep(5);
				}
			});
			ballMoverThread.Start();
		}

		void LoadElements()
		{ 
			ballImage = new UIImageView(UIImage.FromBundle("Round.png"));

			var ballFrame = ballImage.Frame;

			var size = ballFrame.Size;
			size.Height = 40;
			size.Width = 40;
			ballFrame.Size = size;

			ballImage.Frame = ballFrame;
			ballImage.Center = new CGPoint(100, 100);

			View.AddSubview(ballImage);

			rectangleImage = new UIImageView(UIImage.FromBundle("Rectangle.png"));
			var rectangleFrame = rectangleImage.Frame;

			size = rectangleFrame.Size;
			size.Height = 20;
			size.Width = 100;
			rectangleFrame.Size = size;

			rectangleFrame.X = View.Bounds.Size.Width / 2 - 100;
			rectangleFrame.Y = View.Bounds.Size.Height - rectangleFrame.Size.Height - 20;

			rectangleImage.Frame = rectangleFrame;
			rectangleImage.Center = new CGPoint(View.Bounds.Size.Width *0.4, View.Bounds.Size.Height - rectangleImage.Bounds.Size.Height - 20);
			View.AddSubview(rectangleImage);
		}

		void MoveRect(nfloat x)
		{
			rectangleImage.Center = 
				new CGPoint(x, View.Bounds.Size.Height - rectangleImage.Bounds.Size.Height - 20);
		}
	}
}
