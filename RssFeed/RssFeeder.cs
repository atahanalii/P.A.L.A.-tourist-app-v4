using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeed
{
    public class RssFeeder
    {
        private ObservableCollection<RssItem> _items = new ObservableCollection<RssItem>();
        public string Title { get; set; }
        public ObservableCollection<RssItem> Items
        {
            get
            {
                return _items;
            }
        }
    }
}
