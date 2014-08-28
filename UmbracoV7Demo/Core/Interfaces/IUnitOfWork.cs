// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
//   The UnitOfWork interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Core.Interfaces
{
    using System;

    using UmbracoV7Demo.Models;

    /// <summary>
    /// The UnitOfWork interface.
    /// </summary>
    internal interface IUnitOfWork : IDisposable
    {
        #region Public Methods and Operators

        IRepository<BlogComments> BlogCommentsRepository { get; }

        /// <summary>
        /// The commit.
        /// </summary>
        void Commit();

        #endregion
    }
}