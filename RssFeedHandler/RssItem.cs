﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedHandler
{
    public class RssItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public List<RssLink> Links { get; set; }
    }
}
