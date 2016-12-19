using System;
using System.Text.RegularExpressions;

namespace Whitter.Service
{
    public static class LinkService
    {
        private static readonly Regex _parseUrls = new Regex("\\b(([\\w-]+://?|www[.])[^\\s()<>]+(?:\\([\\w\\d]+\\)|([^\\p{P}\\s]|/)))", RegexOptions.IgnoreCase);
        private static readonly Regex _parseMentions = new Regex("(^|\\W)@([A-Za-z0-9_]+)", RegexOptions.IgnoreCase);
        private static readonly Regex _parseHashtags = new Regex("[#]+[A-Za-z0-9-_]+", RegexOptions.IgnoreCase);

        public static string ParseMessage(string tweetText)
        {            
            if (!string.IsNullOrEmpty(tweetText))
            {                
                foreach (var urlMatch in _parseUrls.Matches(tweetText))
                {
                    Match match = (Match)urlMatch;
                    tweetText = tweetText.Replace(match.Value, String.Format("<a href=\"{0}\" target=\"_blank\">{0}</a>", match.Value));
                }

                foreach (var mentionMatch in _parseMentions.Matches(tweetText))
                {
                    Match match = (Match)mentionMatch;
                    if (match.Groups.Count == 3)
                    {
                        string value = match.Groups[2].Value;
                        string text = "@" + value;
                        tweetText = tweetText.Replace(text, String.Format("<a href=\"http://twitter.com/{0}\" target=\"_blank\">{1}</a>", value, text));
                    }
                }

                foreach (var hashMatch in _parseHashtags.Matches(tweetText))
                {
                    Match match = (Match)hashMatch;
                    string query = Uri.EscapeDataString(match.Value);
                    tweetText = tweetText.Replace(match.Value, String.Format("<a href=\"http://search.twitter.com/search?q={0}\" target=\"_blank\">{1}</a>", query, match.Value));
                }
            }

            return tweetText;
        }
    }
}
