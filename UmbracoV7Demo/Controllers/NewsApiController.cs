namespace UmbracoV7Demo.Controllers
{
    using System;
    using System.Linq;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Umbraco.Web.WebApi;
    using UmbracoV7Demo.ViewModels;

    public class NewsApiController : UmbracoApiController
    {
        public NewsViewModel Get(int page)
        {
            const int pageSize = 2;

            var helper = new UmbracoHelper(UmbracoContext);

            IPublishedContent model = helper.TypedContent(1073);

            var pageInt = Convert.ToInt32(page);
            var vm = new NewsViewModel
            {
                Page = pageInt
            };

            var skipItems = (pageSize * vm.Page) - pageSize;

            var posts = model.Children.Where(x => x.IsVisible()).OrderByDescending(x => x.HasValue("publishDate") ? x.GetPropertyValue<DateTime>("publishDate") : x.CreateDate).ToList();
            vm.TotalPages = Convert.ToInt32(Math.Ceiling((double)posts.Count() / pageSize));

            vm.PreviousPage = vm.Page - 1;
            vm.NextPage = vm.Page + 1;

            vm.IsFirstPage = vm.Page <= 1;
            vm.IsLastPage = vm.Page >= vm.TotalPages;

            vm.BlogPost = posts.Skip(skipItems).Take(pageSize);

            return vm;
        }
    }
}