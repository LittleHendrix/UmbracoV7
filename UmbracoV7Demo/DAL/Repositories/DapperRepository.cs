namespace UmbracoV7Demo.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq.Expressions;

    using Dapper;

    using UmbracoV7Demo.DAL.Interfaces;
    using UmbracoV7Demo.DAL.Utility;

    public class DapperRepository<T> : IRepository<T> where T : class
    {
        private readonly string tableName;

        internal IDbConnection connection
        {
            get
            {
                return new SqlConnection(Constant.DatabaseConnection);
            }
        }

        public DapperRepository(string tableName)
        {
            this.tableName = tableName;
        }

        public IEnumerable<T> Find(Expression<System.Func<T, bool>> predicate)
        {
            IEnumerable<T> items = null;

            using (IDbConnection cn = this.connection)
            {
                cn.Open();
                items = cn.Query<T>("SELECT * FROM @Tbl WHERE @condition", new { Tbl = this.tableName, condition = predicate });
                cn.Close();
            }

            return items;
        }

        public T First(Expression<System.Func<T, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public T Single(Expression<System.Func<T, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        public T SingleOrDefault(Expression<System.Func<T, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }
    }
}