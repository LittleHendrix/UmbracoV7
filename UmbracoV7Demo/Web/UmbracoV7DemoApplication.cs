namespace UmbracoV7Demo.Web
{
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;

    using Umbraco.Core;
    using Umbraco.Core.Persistence;
    using Umbraco.Web;

    using UmbracoV7Demo.Infrastructure.Interfaces;
    using UmbracoV7Demo.Infrastructure.Data.Models;
    using UmbracoV7Demo.Infrastructure.Uow;
    using UmbracoV7Demo.ViewModels;

    public class UmbracoV7DemoApplication : ApplicationEventHandler
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

            this.SetUpDependencyInjection();
        }

        private void SetUpDependencyInjection()
        {
            var builder = new ContainerBuilder();

            // register all controllers found in this assembly
            // builder.RegisterControllers(typeof(UmbracoV7DemoApplication).Assembly);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);

            // add custom class to the container as Transient instance
            builder.RegisterType<NewsViewModel>();
            builder.RegisterType<ContactViewModel>();

            // if components appear in many object graphs using the following method to gain exra performance
            // builder.Register(c => new MyCustomModel());

            builder.RegisterType<PpUnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            // bind abstract IUnitOfWork with specific provider (petapoco, EF, ...)
            // builder.RegisterType<ppUnitOfWOrk>().As<IUnitOfWork>().InstancePerRequest();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}