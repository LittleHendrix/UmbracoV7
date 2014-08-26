// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlSitemapSurfaceController.cs" company="">
//   
// </copyright>
// <summary>
//   The xml sitemap surface controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Controllers
{
    using System.Web.Mvc;

    using Umbraco.Web.Mvc;

    /// <summary>
    /// The xml sitemap surface controller.
    /// </summary>
    public class XmlSitemapSurfaceController : SurfaceController
    {
        #region Public Methods and Operators

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            this.Response.ContentType = "text/xml";
            return this.PartialView("XmlSitemapPartial", this.CurrentPage);
        }

        #endregion
    }
}