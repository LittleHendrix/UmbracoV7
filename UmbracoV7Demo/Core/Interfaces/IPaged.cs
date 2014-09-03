// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPaged.cs" company="">
//   
// </copyright>
// <summary>
//   The Paged interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Core.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The Paged interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IPaged<T> : IEnumerable<T>
    {
        #region Public Properties

        /// <summary>
        /// Gets the count.
        /// </summary>
        int Count { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get range.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<T> GetRange(int index, int count);

        #endregion
    }
}