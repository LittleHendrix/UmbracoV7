// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The base repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Database.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using UmbracoV7Demo.Core.Interfaces;

    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        #region Fields

        /// <summary>
        /// The db set.
        /// </summary>
        protected readonly DbContext<TEntity> DbSet;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public BaseRepository(DbContext dbContext)
        {
            this.DbSet = dbContext.Set<TEntity>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<TEntity> GetAll()
        {
            return this.DbSet.Set<TEntity>();
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public TEntity GetById(int id)
        {
            return this.DbSet.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// The search for.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Set<TEntity>().Where(predicate);
        }

        #endregion
    }
}