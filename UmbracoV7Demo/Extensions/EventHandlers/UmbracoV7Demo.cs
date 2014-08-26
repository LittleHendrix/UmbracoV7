// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmbracoV7Demo.cs" company="">
//   
// </copyright>
// <summary>
//   The umbraco v 7 demo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Extensions.EventHandlers
{
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using Umbraco.Core;

    using global::UmbracoV7Demo.ViewModels;

    /// <summary>
    /// The umbraco v 7 demo.
    /// </summary>
    public class UmbracoV7Demo : ApplicationEventHandler
    {
        #region Methods

        /// <summary>
        /// The application started.
        /// </summary>
        /// <param name="umbracoApplication">
        /// The umbraco application.
        /// </param>
        /// <param name="applicationContext">
        /// The application context.
        /// </param>
        //protected override void ApplicationStarted(
        //    UmbracoApplicationBase umbracoApplication, 
        //    ApplicationContext applicationContext)
        //{
        //    var builder = new ContainerBuilder();

        //    // register all controllers found in this assembly
        //    builder.RegisterControllers(typeof(UmbracoV7Demo).Assembly);

        //    // add custom class to the container as Transient instance
        //    builder.RegisterType<NewsViewModel>();

        //    IContainer container = builder.Build();
        //    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        //}

        #endregion
    }
}