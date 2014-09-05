namespace UmbracoV7Demo.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.DAL.Interfaces;

    public class PpGenericRepository<T> : IEditableRepository<T>
        where T : class
    {
        private readonly Database db;

        public PpGenericRepository(Database db)
        {
            this.db = db;
        }

        public virtual void Create(T entity)
        {
            this.db.Insert(typeof(T).ToString(), "id", entity);
        }

        public virtual void Delete(T entity)
        {
            this.db.Delete(typeof(T).ToString(), "id", entity);
        }

        public virtual void Delete(int id)
        {
            this.db.Delete<T>("WHERE id=@0", id);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.db.Query<T>("SELECT * FROM @0 WHERE @1", typeof(T).ToString(), predicate);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.db.Query<T>("SELECT * FROM @0", typeof(T).ToString());
        }

        public virtual T GetById(int id)
        {
            return this.db.SingleOrDefault<T>(id);
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            this.db.Update(typeof(T).ToString(), "id", entity);
        }
    }
}