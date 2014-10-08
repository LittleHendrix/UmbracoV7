// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AjaxOnlyAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   The ajax only attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Core.CustomAttributes
{
    using System.Reflection;
    using System.Web.Mvc;

    /// <summary>
    /// The ajax only attribute.
    /// </summary>
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        #region Public Methods and Operators

        /// <summary>
        /// The is valid for request.
        /// </summary>
        /// <param name="controllerContext">
        /// The controller context.
        /// </param>
        /// <param name="methodInfo">
        /// The method info.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }

        #endregion
    }
}