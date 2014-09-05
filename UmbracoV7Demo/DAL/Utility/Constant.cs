// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constant.cs" company="">
//   
// </copyright>
// <summary>
//   The constant.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.DAL.Utility
{
    using System.Configuration;

    /// <summary>
    /// The constant.
    /// </summary>
    public class Constant
    {
        #region Static Fields

        /// <summary>
        /// The database connection.
        /// </summary>
        public static string DatabaseConnection =
            ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;

        #endregion
    }
}