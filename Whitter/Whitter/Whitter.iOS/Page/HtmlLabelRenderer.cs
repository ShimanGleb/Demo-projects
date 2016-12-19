using Foundation;
using System.ComponentModel;
using Whitter.iOS.Page;
using Whitter.Model;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
namespace Whitter.iOS.Page
{
    class HtmlLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            var attr = new NSAttributedStringDocumentAttributes();
            var nsError = new NSError();
            attr.DocumentType = NSDocumentType.HTML;

            var text = e.NewElement.Text;

            text = "<style>body{font-family: '" + this.Control.Font.Name + "'; font-size:" + this.Control.Font.PointSize + "px;}</style>" + text;

            var myHtmlData = NSData.FromString(text, NSStringEncoding.Unicode);
            Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null)
            {
                return;
            }

            if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                var attr = new NSAttributedStringDocumentAttributes();
                var nsError = new NSError();
                attr.DocumentType = NSDocumentType.HTML;

                var myHtmlData = NSData.FromString(this.Control.Text, NSStringEncoding.Unicode);
                Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);
            }
        }
    }
}
}
