// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewsOverviewController.cs" company="">
//   
// </copyright>
// <summary>
//   The news overview controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;

    using UmbracoV7Demo.ViewModels;

    /// <summary>
    /// The news overview controller.
    /// </summary>
    public class NewsOverviewController : RenderMvcController
    {
        #region Fields

        /// <summary>
        /// The _news view model.
        /// </summary>
        private readonly NewsViewModel _newsViewModel;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsOverviewController"/> class.
        /// </summary>
        /// <param name="newsViewModel">
        /// The news view model.
        /// </param>
        public NewsOverviewController(NewsViewModel newsViewModel)
        {
            this._newsViewModel = newsViewModel;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The news overview.
        /// </summary>
        /// <param name="umbracoModel">
        /// The umbraco model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [OutputCache(Duration = 60, VaryByParam = "*")]
        public ActionResult NewsOverview(RenderModel umbracoModel)
        {
            string page = this.HttpContext.Request.QueryString["Page"] ?? "1";
            int pageInt = Convert.ToInt32(page);

            this._newsViewModel.Page = pageInt;
            this._newsViewModel.BlogPost = GetPagedBlogPost(this._newsViewModel);

            return this.CurrentTemplate(this._newsViewModel);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get paged blog post.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private static IEnumerable<IPublishedContent> GetPagedBlogPost(NewsViewModel model)
        {
            int pageSise = model.Content.HasValue("itemsPerPage")
                               ? Convert.ToInt32(model.Content.GetPropertyValue("itemsPerPage"))
                               : model.PageSize;
            int skipItems = (pageSise * model.Page) - pageSise;

            List<IPublishedContent> posts =
                model.Content.Children.Where(x => x.IsVisible())
                    .OrderByDescending(
                        x => x.HasValue("publishDate") ? x.GetPropertyValue<DateTime>("publishDate") : x.CreateDate)
                    .ToList();
            model.TotalPages = Convert.ToInt32(Math.Ceiling((double)posts.Count() / pageSise));

            model.PreviousPage = model.Page - 1;
            model.NextPage = model.Page + 1;

            model.IsFirstPage = model.Page <= 1;
            model.IsLastPage = model.Page >= model.TotalPages;

            return posts.Skip(skipItems).Take(pageSise);
        }

        #endregion
    }
}