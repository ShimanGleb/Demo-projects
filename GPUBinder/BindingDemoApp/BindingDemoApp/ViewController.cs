using System;

using UIKit;
using BindingSolution;
using CoreGraphics;

namespace BindingDemoApp
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			UIImage inputImage = UIImage.FromBundle("2.png");

			var beforeFilterLabel = new UILabel();
			beforeFilterLabel.Text = "Before filter";
			beforeFilterLabel.Frame = new CGRect(200, 100, 200, 100);
			beforeFilterLabel.Center = new CGPoint(View.Bounds.Size.Width / 2, View.Bounds.Size.Height / 8);
			beforeFilterLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);

			beforeFilterLabel.TextColor = UIColor.Black;

			View.AddSubview(beforeFilterLabel);

			var beforeFilterView = new UIImageView(inputImage);

			beforeFilterView.Center = new CGPoint(View.Bounds.Size.Width / 2, View.Bounds.Size.Height /4);

			View.AddSubview(beforeFilterView);

			GPUImageGrayscaleFilter filter = new GPUImageGrayscaleFilter();

			var image = filter.ImageByFilteringImage(inputImage);

			var imageView = new UIImageView(image);

			imageView.Center = new CGPoint(View.Bounds.Size.Width/2, View.Bounds.Size.Height/1.6);

			View.AddSubview(imageView);

			var afterFilterLabel = new UILabel();
			afterFilterLabel.Text = "After filter";
			afterFilterLabel.Frame = new CGRect(200, 100, 200, 100);
			afterFilterLabel.Center = new CGPoint(View.Bounds.Size.Width / 2, View.Bounds.Size.Height / 2);
			afterFilterLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);

			afterFilterLabel.TextColor = UIColor.Black;

			View.AddSubview(afterFilterLabel);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

