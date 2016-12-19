using Android.App;

using System;

using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Whitter.Droid.Pages;
using Whitter.Pages;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]

namespace Whitter.Droid.Pages
{
    public class LoginPageRenderer : PageRenderer
    {
        bool showLogin = true;
        
        protected override void OnElementPropertyChanged(object s, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(s, e);

            var activity = Context as Activity;

            if (showLogin && App.User == null)
            {
                showLogin = false;
                
                var auth = new OAuth1Authenticator(
                    consumerKey: "IPDotz1tp4c07AZywLUbUOBza",
                    consumerSecret: "FiGWZSvk1TIlK7XMYTpmacToPBNp8F32j4cT2RYsXRwaMe5q9S",
                    requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
                    authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
                    accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
                    callbackUrl: new Uri("https://www.facebook.com/connect/login_success.html")
                );
                
                auth.Completed += (sender, eventArgs) =>
                {
                    if (eventArgs.IsAuthenticated)
                    {
                        App.User = new Model.UserDetails();
                        
                        App.User.Token = eventArgs.Account.Properties["oauth_token"];
                        App.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
                        App.User.TwitterId = eventArgs.Account.Properties["user_id"];
                        App.User.ScreenName = eventArgs.Account.Properties["screen_name"];
                        
                        App.SuccessfulLoginAction.Invoke();                                         
                    }
                    else
                    {
                        
                    }                               
                };
                
                activity.StartActivity(auth.GetUI(activity));
            }
        }
    }
}