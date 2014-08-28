// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmbracoV7DemoApplication.cs" company="">
//   
// </copyright>
// <summary>
//   The umbraco v 7 demo application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UmbracoV7Demo.Web
{
    using System;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using Umbraco.Web;

    using UmbracoV7Demo.ViewModels;

    /// <summary>
    ///     The umbraco v 7 demo application.
    /// </summary>
    public class UmbracoV7DemoApplication : UmbracoApplication
    {
        #region Methods

        /// <summary>
        /// The on application started.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            base.OnApplicationStarted(sender, e);

            this.SetUpDependencyInjection();
        }

        /// <summary>
        /// The set up dependency injection.
        /// </summary>
        private void SetUpDependencyInjection()
        {
            var builder = new ContainerBuilder();

            // register all controllers found in this assembly
            builder.RegisterControllers(typeof(UmbracoV7DemoApplication).Assembly);

            // add custom class to the container as Transient instance
            builder.RegisterType<NewsViewModel>();

            // bind abstract IUnitOfWork with specific provider (petapoco, EF, ...)
            // builder.RegisterType<ppUnitOfWOrk>().As<IUnitOfWork>().InstancePerRequest();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        #endregion
    }
}