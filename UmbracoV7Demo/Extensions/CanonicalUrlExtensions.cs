﻿namespace UmbracoV7Demo.Extensions
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Umbraco.Core.Models;

    public static class CanonicalUrlExtensions
    {
        public static MvcHtmlString CanonicalUrl(this HtmlHelper html)
        {
            var rawUrl = html.ViewContext.RequestContext.HttpContext.Request.Url;

            return CanonicalUrl(html, String.Format("{0}://{1}{2}", rawUrl.Scheme, rawUrl.Host, rawUrl.AbsolutePath));
        }

        private static MvcHtmlString CanonicalUrl(this HtmlHelper html, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                var rawUrl = html.ViewContext.RequestContext.HttpContext.Request.Url;
                path = string.Format("{0}://{1}{2}", rawUrl.Scheme, rawUrl.Host, rawUrl.AbsolutePath);
            }

            path = path.ToLower();

            if (path.Count(c => c == '/') > 3)
            {
                path = path.TrimEnd('/');
            }

            if (path.EndsWith("/index"))
            {
                path = path.Substring(0, path.Length - 6);
            }

            var canonical = new TagBuilder("link");
            canonical.MergeAttribute("rel", "canonical");
            canonical.MergeAttribute("href", path);

            return new MvcHtmlString(canonical.ToString(TagRenderMode.SelfClosing));
        }
    }
}