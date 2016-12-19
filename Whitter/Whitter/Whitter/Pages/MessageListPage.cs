using System;
using Whitter.Model;
using Whitter.Service;
using Xamarin.Forms;

namespace Whitter.Pages
{
    public class MessageListPage : BaseContentPage
    {
        public MessageListPage()
        {
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children =
                    {
                        new Label
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin!!"
                        }
                    }
            };            
        }
        
        public Page GetTimeline()
        {
            var listView = new ListView
            {
                HasUnevenRows = true                
            };
            
            listView.ItemsSource = TwitterService.Search();
            listView.ItemTemplate = new DataTemplate(() =>
            {
                Image userImage = new Image();
                userImage.SetBinding(Image.SourceProperty, "ImageUri");

                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");

                HtmlLabel tweetLabel = new HtmlLabel();
                tweetLabel.SetBinding(Label.TextProperty, "Value");

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Vertical,
                        Children =
                                {
                                    
                                    new StackLayout
                                    {
                                        Padding = new Thickness(0, 5),
                                        Orientation = StackOrientation.Horizontal,
                                        Children =
                                        {
                                            userImage,
                                            nameLabel
                                        }
                                    },                                    
                                    tweetLabel                                    
                                }
                    }
                };
            });
            
            return new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = { listView }
                }
            };
        }
    }
}
