using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RssFeedHandler
{
    public class RssClient
    {
        public async Task<RssFeed> GetFeeds(string url, int maxItems)
        {
            RssFeed feeds = new RssFeed();
            SyndicationClient client = new SyndicationClient();
            Uri feedUri = new Uri(url);
            try
            {
                SyndicationFeed feed = await client.RetrieveFeedAsync(feedUri);
                var topFeeds = feed.Items.OrderByDescending(x =>
                x.PublishedDate).Take(maxItems).ToList();
                feeds.Title = feed.Title.Text;
                foreach (var item in topFeeds)
                {
                    RssItem feedItem = new RssItem();
                    feedItem.Title = item.Title.Text;
                    feedItem.PublishedOn = item.PublishedDate.DateTime;
                    var authors = from a in item.Authors
                                  select a.Name;
                    feedItem.Author =
                    String.Join(",", authors);
                    feedItem.Content = item.Content !=
                    null ? item.Content.Text : String.Empty;
                    feedItem.Description = item.Summary !=
                    null ? item.Summary.Text : String.Empty;
                    var links = from l in item.Links
                                select new RssLink(l.Title, l.Uri);
                    feedItem.Links = links.ToList();
                    feeds.Items.Add(feedItem);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return feeds;
        }
    }
}
