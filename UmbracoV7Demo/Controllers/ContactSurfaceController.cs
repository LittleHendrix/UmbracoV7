// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactSurfaceController.cs" company="">
//   
// </copyright>
// <summary>
//   The contact surface controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.UI;

    using Umbraco.Web.Mvc;

    using UmbracoV7Demo.Core;
    using UmbracoV7Demo.ViewModels;

    /// <summary>
    /// The contact surface controller.
    /// </summary>
    public class ContactSurfaceController : SurfaceController
    {
        private readonly ContactViewModel contactViewModel;

        public ContactSurfaceController(ContactViewModel contactViewModel)
        {
            this.contactViewModel = contactViewModel;
        }

        #region Public Methods and Operators

        /// <summary>
        /// The contact us post.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        [OutputCache(Duration = 0, VaryByParam = "none", Location = OutputCacheLocation.Any, NoStore = true)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("ContactUs")]
        public ActionResult ContactUsPost(ContactViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.CurrentUmbracoPage();
            }

            EmailDispatcher.SendContactEmail(model);

            try
            {
                if ((this.TempData.ContainsValue("true") == false)
                    || (this.TempData.ContainsKey("FormCompleted") == false))
                {
                    this.TempData.Add("FormCompleted", "true");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    ex.Message + " containsValue=" + this.TempData.ContainsValue("true") + " containsKey="
                    + this.TempData.ContainsKey("FormCompleted"));
            }

            return this.RedirectToCurrentUmbracoPage();
        }

        /// <summary>
        /// The render contact form.
        /// @Html.Action("RenderContactForm","ContactSurface");
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult RenderContactForm()
        {
            return this.PartialView("ContactForm", this.contactViewModel);
        }

        #endregion
    }
}