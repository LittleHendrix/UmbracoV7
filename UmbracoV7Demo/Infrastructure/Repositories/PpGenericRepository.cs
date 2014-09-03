// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PpGenericRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The pp generic repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.Core.Interfaces;

    /// <summary>
    /// The pp generic repository.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class PpGenericRepository<T> : IEditableRepository<T>
        where T : class
    {
        #region Fields

        /// <summary>
        /// The db.
        /// </summary>
        private readonly Database db;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PpGenericRepository{T}"/> class.
        /// </summary>
        /// <param name="db">
        /// The db.
        /// </param>
        public PpGenericRepository(Database db)
        {
            this.db = db;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Create(T entity)
        {
            this.db.Insert(typeof(T).ToString(), "id", entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Delete(T entity)
        {
            this.db.Delete(typeof(T).ToString(), "id", entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public virtual void Delete(int id)
        {
            this.db.Delete<T>("WHERE id=@0", id);
        }

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.db.Query<T>("SELECT * FROM @0 WHERE @1", typeof(T).ToString(), predicate);
        }

        /// <summary>
        /// The first.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public T First(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public virtual IEnumerable<T> GetAll()
        {
            return this.db.Query<T>("SELECT * FROM @0", typeof(T).ToString());
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public virtual T GetById(int id)
        {
            return this.db.SingleOrDefault<T>(id);
        }

        /// <summary>
        /// The single.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public T Single(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The single or default.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Update(T entity)
        {
            this.db.Update(typeof(T).ToString(), "id", entity);
        }

        #endregion
    }
}