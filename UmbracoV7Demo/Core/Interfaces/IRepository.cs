// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The Repository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UmbracoV7Demo.Core.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IRepository<T>
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The get all.
        /// </summary>
        /// <returns>
        ///     The <see cref="IQueryable" />.
        /// </returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetById(int id);

        /// <summary>
        /// The search for.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);

        #endregion
    }

    /// <summary>
    /// The EditableRepository interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IEditableRepository<T> : IRepository<T>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Create(T entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Delete(T entity);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Update(T entity);

        #endregion
    }
}