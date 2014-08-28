﻿// --------------------------------------------------------------------------------------------------------------------
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

    /// <summary>
    ///     The UnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The commit.
        /// </summary>
        void Commit();

        #endregion
    }
}