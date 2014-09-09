namespace UmbracoV7Demo.DAL.Infrastructure
{
    using Umbraco.Core;
    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.DAL.Interfaces;

    public class PetaPocoUnitOfWork : IUnitOfWork
    {
        private readonly Database db;

        private readonly Transaction petaTranaction;

        public PetaPocoUnitOfWork()
        {
            this.db = ApplicationContext.Current.DatabaseContext.Database;
            this.petaTranaction = new Transaction(this.db);
        }

        public void Commit()
        {
            this.petaTranaction.Complete();
        }

        public void Dispose()
        {
            this.petaTranaction.Dispose();
        }

        public Database Db
        {
            get
            {
                return this.db;
            }
        }
    }
}