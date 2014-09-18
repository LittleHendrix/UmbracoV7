namespace UmbracoV7Demo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Umbraco.Web;
    using Umbraco.Web.WebApi;

    using UmbracoV7Demo.Extensions;
    using UmbracoV7Demo.ViewModels;

    public class NewsApiController : UmbracoApiController
    {
        private const string NewsItemDocTypeAlias = "NewsItem";

        public IEnumerable<NewsItemViewModel> GetAll(int parentId)
        {
            UmbracoHelper helper = new UmbracoHelper(UmbracoContext);

            return helper.TypedContent(parentId)
                .Children.Where(c => c.DocumentTypeAlias == NewsItemDocTypeAlias)
                .Select(
                    obj =>
                    new NewsItemViewModel()
                        {
                            Id = obj.Id,
                            PageHeading = obj.Name,
                            BodyText = obj.GetPropertyValue<string>("bodyText"),
                            PageMedia = obj.ImagesNodesFor("pageMedia",1).First().GetPropertyValue<string>("umbracoFile"),
                            SearchEngineHide = obj.GetPropertyValue<bool>("searchEngineSitemapHide"),
                            UmbracoNaviHide = obj.GetPropertyValue<bool>("umbracoNaviHide"),
                            CreatorName = obj.CreatorName,
                            PublishDate = obj.CreateDate,
                            UpdateDate = obj.UpdateDate
                        });
        }

        public NewsItemViewModel GetById(int id)
        {
            UmbracoHelper helper = new UmbracoHelper(UmbracoContext);

            var content = helper.TypedContent(id);

            return new NewsItemViewModel
                       {
                           Id = content.Id,
                           PageHeading = content.Name,
                           BodyText = content.GetPropertyValue<string>("bodyText"),
                           PageMedia = content.GetPropertyValue<string>("pageMedia"),
                           CreatorName = content.CreatorName,
                           PublishDate = content.CreateDate,
                           UpdateDate = content.UpdateDate
                       };
        }

        [HttpPost]
        [UmbracoAuthorize(Roles = "Administrator, editor")]
        [ValidateAntiForgeryToken]
        public NewsItemViewModel PostNewsItem(NewsItemViewModel newsItem, int parentId, int userId = 0)
        {
            var cs = Services.ContentService;
            var ms = Services.MediaService;

            var content = cs.CreateContent(newsItem.PageHeading, parentId, NewsItemDocTypeAlias);

            content.Name = newsItem.PageHeading;
            
            if (content.HasProperty("bodyText"))
            {
                content.SetValue("bodyText", newsItem.BodyText);
            }

            if (content.HasProperty("searchEngineSitemapHide"))
            {
                content.SetValue("searchEngineSitemapHide", newsItem.SearchEngineHide);
            }

            if (content.HasProperty("umbracoNaviHide"))
            {
                content.SetValue("umbracoNaviHide", newsItem.UmbracoNaviHide);
            }

            if (content.HasProperty("pageMedia") && newsItem.Files.Any(x => x.ContentLength > 0))
            {
                var uploadDir = ms.GetChildren(-1).Any(m => m.Name.ToLowerInvariant() == "webapipost") ? ms.GetChildren(-1).SingleOrDefault(m => m.Name.ToLowerInvariant() == "webapipost") : ms.CreateMedia("WebApiPost", -1, "Folder");
                var mName = newsItem.PublishDate.ToString("dd-MM-yy") + newsItem.PageHeading.Replace(" ", "-");

                foreach (var file in newsItem.Files)
                {
                    var media = ms.CreateMedia(mName, uploadDir, "Image");
                    media.SetValue("umbracoFile", file);
                    ms.Save(media, userId);
                }

                // content.SetValue("pageMedia", media);
            }

            cs.SaveAndPublishWithStatus(content);

            return newsItem;
        }

        [HttpPost]
        [UmbracoAuthorize(Roles = "Administrator, editor")]
        public void DeleteNewsItem(int id)
        {
            var cs = Services.ContentService;
            var content = cs.GetById(id);
            cs.Delete(content);
        }

    }
}