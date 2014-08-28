// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWorkProvider.cs" company="">
//   
// </copyright>
// <summary>
//   The UnitOfWorkProvider interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Core.Interfaces
{
    /// <summary>
    /// The UnitOfWorkProvider interface.
    /// </summary>
    public interface IUnitOfWorkProvider
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get unit of work.
        /// </summary>
        /// <returns>
        /// The <see cref="IUnitOfWork"/>.
        /// </returns>
        IUnitOfWork GetUnitOfWork();

        #endregion
    }
}