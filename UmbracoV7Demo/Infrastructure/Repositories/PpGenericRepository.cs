namespace UmbracoV7Demo.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.Core.Interfaces;

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly Database db;

        public GenericRepository(Database db)
        {
            this.db = db;
        }

        public virtual T GetById(int id)
        {
            return this.db.SingleOrDefault<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.db.Query<T>("SELECT * FROM @0", typeof(T));
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.db.Query<T>("SELECT * FROM @0 WHERE @1", typeof(T), predicate);
        }

        public virtual void Create(T entity)
        {
            this.db.Insert(typeof(T).ToString(), "id", entity);
        }

        public virtual void Delete(T entity)
        {
            this.db.Delete(typeof(T).ToString(), "id", entity);
        }

        public virtual void Update(T entity)
        {
            this.db.Update(typeof(T).ToString(), "id", entity);
        }
    }
}