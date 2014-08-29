namespace UmbracoV7Demo.Extensions.EventHandlers
{
    using Umbraco.Core;
    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.Infrastructure.Data.Models;
    using UmbracoV7Demo.Infrastructure;

    public class RegisterEvents : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            // Get the Umbraco Database context
            var db = applicationContext.DatabaseContext.Database;

            //Check if the DB table does NOT exist
            if (!db.TableExist("BlogComments"))
            {
                //Create DB table - and set overwrite to false
                db.CreateTable<BlogComment>(false);
            }
        }
    }
}