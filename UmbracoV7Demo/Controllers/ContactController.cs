namespace UmbracoV7Demo.Controllers
{
    using System.Web.Mvc;

    using UmbracoV7Demo.Core;
    using UmbracoV7Demo.ViewModels;

    public class ContactController : Controller
    {
        [HttpPost]
        [ActionName("ContactUsJson")]
        public ActionResult ContactUsJsonPost(ContactViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new { message = "Opps! There has been an error!" });
            }

            EmailDispatcher.SendContactEmail(model);

            return this.Json(new { message = "Your message has been submitted successfully. A email has been sent to the web administrator." });
        }
    }
}