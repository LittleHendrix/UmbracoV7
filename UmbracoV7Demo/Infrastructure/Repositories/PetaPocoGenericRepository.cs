namespace UmbracoV7Demo.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.Core.Interfaces;

    public class PetaPocoGenericRepository<T> : IRepository<T> where T : class
    {
        private readonly Database db;

        public PetaPocoGenericRepository(Database database)
        {
            this.db = database;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.db.Query<T>("SELECT * FROM " + T + " WHERE " + predicate);
        }

        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual T Single(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}