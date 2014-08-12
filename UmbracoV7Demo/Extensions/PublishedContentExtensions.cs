// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PublishedContentExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The published content extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UmbracoV7Demo.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Newtonsoft.Json.Linq;

    using RJP.MultiUrlPicker.Models;

    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    ///     The published content extensions.
    /// </summary>
    public static class PublishedContentExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get multi url links list.
        /// </summary>
        /// <param name="publishedContent">
        /// The published content.
        /// </param>
        /// <param name="mupPropertyAlias">
        /// The mup property alias.
        /// </param>
        /// <param name="htmlAttributes">
        /// The html attributes.
        /// </param>
        /// <param name="listType">
        /// The list type.
        /// </param>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        public static MvcHtmlString GetMultiUrlLinksList(
            this IPublishedContent publishedContent, 
            string mupPropertyAlias, 
            object htmlAttributes = null, 
            string listType = "ul")
        {
            if (!publishedContent.HasValue(mupPropertyAlias))
            {
                return MvcHtmlString.Empty;
            }

            var multiUrlPicker = publishedContent.GetPropertyValue<MultiUrls>(mupPropertyAlias);
            if (!multiUrlPicker.Any())
            {
                return MvcHtmlString.Empty;
            }

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;

            listType = (listType.ToLower() != "ol" || listType.ToLower() != "ul") ? "ul" : listType;

            var htmlList = new TagBuilder(listType);
            htmlList.CustomMergeAttributes(attributes);

            foreach (Link item in multiUrlPicker)
            {
                var li = new TagBuilder("li");
                var a = new TagBuilder("a");

                a.Attributes.Add("href", item.Url);
                a.Attributes.Add("target", item.Target);

                if (item.Id == null)
                {
                    a.Attributes.Add("rel", "nofollow");
                }

                a.SetInnerText(item.Name);

                li.InnerHtml += a.ToString();
                htmlList.InnerHtml += li.ToString();
            }

            return MvcHtmlString.Create(htmlList.ToString());
        }

        /// <summary>
        /// The get related links list.
        /// </summary>
        /// <param name="publishedContent">
        /// The published content.
        /// </param>
        /// <param name="rlPropertyAlias">
        /// The rl property alias.
        /// </param>
        /// <param name="htmlAttributes">
        /// The html attributes.
        /// </param>
        /// <param name="listType">
        /// The list type.
        /// </param>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        public static MvcHtmlString GetRelatedLinksList(
            this IPublishedContent publishedContent, 
            string rlPropertyAlias, 
            object htmlAttributes = null, 
            string listType = "ul")
        {
            if (!publishedContent.HasValue(rlPropertyAlias))
            {
                return MvcHtmlString.Empty;
            }

            var helper = new UmbracoHelper(UmbracoContext.Current);

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;

            listType = (listType.ToLower() != "ol" || listType.ToLower() != "ul") ? "ul" : listType;

            var htmlList = new TagBuilder(listType);
            htmlList.CustomMergeAttributes(attributes);

            foreach (JToken item in publishedContent.GetPropertyValue<JArray>(rlPropertyAlias))
            {
                var li = new TagBuilder("li");
                var a = new TagBuilder("a");

                string linkUrl = item.Value<bool>("isInternal")
                                     ? helper.NiceUrl(item.Value<int>("internal"))
                                     : item.Value<string>("link");
                string linkTarget = item.Value<bool>("newWindow") ? "_blank" : string.Empty;
                var caption = item.Value<string>("caption");

                a.Attributes.Add("href", linkUrl);
                a.Attributes.Add("target", linkTarget);
                if (!item.Value<bool>("isInternal"))
                {
                    a.Attributes.Add("rel", "nofollow");
                }

                a.SetInnerText(caption);

                li.InnerHtml += a.ToString();
                htmlList.InnerHtml += li.ToString();
            }

            return MvcHtmlString.Create(htmlList.ToString());
        }

        /// <summary>
        /// The mntp count.
        /// </summary>
        /// <param name="publishedContent">
        /// The published content.
        /// </param>
        /// <param name="propertyAlias">
        /// The property alias. instance of Multinode Treepicker or Multi Media Picker
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int MntpCount(this IPublishedContent publishedContent, string propertyAlias)
        {
            if (!publishedContent.HasValue(propertyAlias))
            {
                return default(int);
            }

            return
                publishedContent.GetPropertyValue<string>(propertyAlias)
                    .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Length;
        }

        #endregion
    }
}