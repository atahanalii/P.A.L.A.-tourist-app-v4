using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeed
{
    public class RssLink
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public RssLink(string title, Uri link)
        {
            Title = !
                    String.IsNullOrWhiteSpace(title) ? title : link.AbsoluteUri;
            Link = link;
        }
    }
}
