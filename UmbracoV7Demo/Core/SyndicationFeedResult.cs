namespace UmbracoV7Demo.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.ServiceModel.Syndication;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml;

    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Umbraco.Web.Models;

    public class SyndicationFeedResult : FileResult
    {
        private readonly SyndicationFeed _feed;

        public SyndicationFeedResult(string title, string descr, IEnumerable<SyndicationItem> feedItems)
            : base("application/rss+xml")
        {
            this._feed = new SyndicationFeed(title, descr, HttpContext.Current.Request.Url, feedItems);
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            using (XmlWriter writer = XmlWriter.Create(response.OutputStream))
            {
                this._feed.GetRss20Formatter().WriteTo(writer);
            }
        }

        public SyndicationFeedResult GenerateFeed(RenderModel model)
        {
            IEnumerable<SyndicationItem> rssFeed = model.Content.Children.Select(x => new SyndicationItem(
                    x.GetPropertyValue<string>("title"),
                    x.GetPropertyValue<string>("description"),
                    new Uri(x.UrlWithDomain()),
                    x.Id.ToString(CultureInfo.InvariantCulture),
                    x.UpdateDate));

            var x = new SyndicationItem
                        {
                            Title = new TextSyndicationContent("title")
                        };

        }
    }
}