using LinqToTwitter;

using System;
using System.Collections.Generic;
using System.Linq;

using Whitter.Model;

namespace Whitter.Service
{
    public class TwitterService
    {
        private static TwitterContext GetTwitterContext()
        {
            var auth = new XAuthAuthorizer()
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = "IPDotz1tp4c07AZywLUbUOBza",
                    ConsumerSecret = "FiGWZSvk1TIlK7XMYTpmacToPBNp8F32j4cT2RYsXRwaMe5q9S",
                    OAuthToken = App.User.Token,
                    OAuthTokenSecret = App.User.TokenSecret,
                    ScreenName = App.User.ScreenName,
                    UserID = ulong.Parse(App.User.TwitterId)
                },
            };
            auth.AuthorizeAsync();

            var ctx = new TwitterContext(auth);
            return ctx;
        }

        public static List<Message> Search(string searchText = "Xamarin")
        {
            try
            {
                var ctx = GetTwitterContext();

                var searchResponses = (from search in ctx.Search
                                       where search.Type == SearchType.Search
                                       && search.Query == searchText
                                       select search).SingleOrDefault();
                
                var tweets = from tweet in searchResponses.Statuses
                             select new Message
                             {
                                 Value = LinkService.ParseMessage(tweet.Text),
                                 Id = tweet.TweetIDs,
                                 ImageUri = tweet.User.ProfileImageUrl,
                                 UserName = tweet.User.ScreenNameResponse,
                                 Name = tweet.User.Name,
                                 CreatedAt = tweet.CreatedAt,
                                 ReTweets = tweet.RetweetCount,
                                 Favorite = tweet.FavoriteCount.Value
                             };

                return tweets.ToList();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return new List<Message>();
        }
    }
}
