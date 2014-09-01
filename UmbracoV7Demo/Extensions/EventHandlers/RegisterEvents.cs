//namespace UmbracoV7Demo.Extensions.EventHandlers
//{
//    using System.Reflection;
//    using System.Web.Mvc;

//    using Autofac;
//    using Autofac.Integration.Mvc;

//    using Umbraco.Core;
//    using Umbraco.Core.Persistence;

//    using UmbracoV7Demo.Infrastructure.Data.Models;
//    using UmbracoV7Demo.ViewModels;

//    public class UmbracoV7DemoApplication : ApplicationEventHandler
//    {
//        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
//        {
//            // Get the Umbraco Database context
//            var db = applicationContext.DatabaseContext.Database;

//            //Check if the DB table does NOT exist
//            if (!db.TableExist("BlogComments"))
//            {
//                //Create DB table - and set overwrite to false
//                db.CreateTable<BlogComment>(false);
//            }

//            this.SetUpDependencyInjection();
//        }

//        private void SetUpDependencyInjection()
//        {
//            var builder = new ContainerBuilder();

//            // register all controllers found in this assembly
//            builder.RegisterControllers(Assembly.GetExecutingAssembly());

//            // add custom class to the container as Transient instance
//            builder.RegisterType<NewsViewModel>();

//            // bind abstract IUnitOfWork with specific provider (petapoco, EF, ...)
//            // builder.RegisterType<ppUnitOfWOrk>().As<IUnitOfWork>().InstancePerRequest();
//            IContainer container = builder.Build();
//            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
//        }
//    }
//}