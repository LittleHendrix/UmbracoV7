namespace UmbracoV7Demo.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Examine;
    using Examine.Providers;
    using Examine.SearchCriteria;

    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;

    using UmbracoV7Demo.ViewModels;

    public class SearchController : RenderMvcController
    {
        public override ActionResult Index(RenderModel umbracoModel)
        {
            return this.GetDefaultAction(umbracoModel);
        }

        public ActionResult Search(RenderModel umbracoModel, string searchTerms = "", string json = "")
        {
            if (!string.IsNullOrEmpty(json))
            {
                var jsonResults =
                    this.GetSearchResults(searchTerms, 100)
                        .Results.Select(x => new { Url = this.Umbraco.NiceUrl(x.Id), Title = x.Fields["nodeName"] });

                return this.Json(jsonResults);
            }

            SearchResultsViewModel model = this.GetSearchResults(searchTerms, 20);

            return this.GetDefaultAction(model);
        }

        private ActionResult GetDefaultAction(object model)
        {
            // get the template name from the route values:
            // string template = this.ControllerContext.RouteData.Values["action"].ToString();

            // return this.View(template, model);

            return this.CurrentTemplate(model);
        }

        private SearchResultsViewModel GetSearchResults(string searchTerms, int pageSize)
        {
            int page;
            int resultCount = 0;
            int totalPages = 0;
            IOrderedEnumerable<SearchResult> searchResults = null;

            if (!int.TryParse(this.Request.QueryString["Page"], out page))
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchTerms))
            {
                searchTerms = searchTerms.ToLower();
                BaseSearchProvider searchProvider = ExamineManager.Instance.SearchProviderCollection["ExternalSearcher"];
                ISearchCriteria searchCriteria = searchProvider.CreateSearchCriteria(BooleanOperation.Or);
                IBooleanOperation queryBuilder = null;

                foreach (var searchValue in searchTerms.Split(' ').Where(searchTerm => !string.IsNullOrEmpty(searchTerm.RemoveStopWords())))
                {
                    if (queryBuilder == null)
                    {
                        queryBuilder =
                            searchCriteria.GroupedOr(
                                new[] { "nodeName", "metaTitle", "metaDescription", "bodyText" },
                                searchValue);
                    }
                    else
                    {
                        queryBuilder =
                            queryBuilder.Or()
                                .GroupedOr(
                                    new[] { "nodeName", "metaTitle", "metaDescription", "bodyText" },
                                    searchValue);
                    }
                }

                if (queryBuilder != null)
                {
                    queryBuilder = queryBuilder.Not().Field("template", "0");

                    ISearchCriteria query =
                        queryBuilder.Not()
                            .GroupedOr(new[] { "umbracoNaviHide", "nodeTypeAlias" }, new[] { "1", "Folder" })
                            .Compile();

                    ISearchResults results = searchProvider.Search(query);
                    searchResults = results.OrderByDescending(x => x.Score);
                    resultCount = results.TotalItemCount;
                }

                totalPages = (int)Math.Ceiling(resultCount / (double)pageSize);

                if (page > totalPages)
                {
                    page = totalPages;
                }
                else if (page < 1)
                {
                    page = 1;
                }
            }

            var searchResultModel = new SearchResultsViewModel
            {
                Page = page,
                PageSize = pageSize,
                ResultCount = resultCount,
                TotalPages = totalPages,
                SearchTerms = searchTerms
            };

            if (searchResults != null)
            {
                searchResultModel.Results = searchResults.Skip((page - 1) * pageSize).Take(pageSize);
            }

            return searchResultModel;
        }
    }
}