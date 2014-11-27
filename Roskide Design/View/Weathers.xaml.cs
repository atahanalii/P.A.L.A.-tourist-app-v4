using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RssFeed;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using RssFeed;
using RssFeed = RssFeed.RssFeeder;

namespace Roskide_Design.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Weather : Page
    {
        private int _maxFeeds = 20;

        RssClient _client = new RssClient();
        public Weather()
        {
            this.InitializeComponent();
            InitializeComponent();

            Loaded += new RoutedEventHandler(Weather_Loaded);

            FeedListView.SelectionChanged += new
            SelectionChangedEventHandler(FeedListView_SelectionChanged);

            FetchButton.Click += new RoutedEventHandler(FetchButton_Click);

        }

        private async Task GetFeeds(string url)
        {
            RssFeeder feeds = await _client.GetFeeds(url, _maxFeeds);
            this.DataContext = feeds;
        }

        async void Weather_Loaded(object sender, RoutedEventArgs e)
        {
            await GetFeeds("http://www.worldweatheronline.com/v2/rss.ashx?locid=640004&root_id=633954");
        }

        private async void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(FeedUrl.Text))
            {
                await GetFeeds(FeedUrl.Text);
            }
        }

        void FeedListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView rssFeeds = (sender as ListView);
            RssItem selectedItem = rssFeeds.SelectedItem as RssItem;


            if (selectedItem != null && selectedItem.Links.Count > 0)
            {
                RSSItemWebView.Navigate(selectedItem.Links[0].Link);
            }
        }

        private void Hotel_DoubleTapped_1(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Hotels));
        }

        private void Weather_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Weather));
        }

   /*  private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));
        }*/
    }
}
