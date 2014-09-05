namespace UmbracoV7Demo.DAL.Infrastructure
{
    using Umbraco.Core;
    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.DAL.EntityModels;
    using UmbracoV7Demo.DAL.Interfaces;
    using UmbracoV7Demo.DAL.Repositories;

    public abstract class PpUnitOfWork : IUnitOfWork
    {
        private readonly PpGenericRepository<BlogComment> blogCommentsRepository;

        private readonly Database db;

        private readonly Transaction petaTranaction;

        protected PpUnitOfWork()
        {
            this.db = ApplicationContext.Current.DatabaseContext.Database;
            this.petaTranaction = new Transaction(this.db);

            this.blogCommentsRepository = new PpGenericRepository<BlogComment>(this.db);
        }

        public IRepository<BlogComment> BlogCommentsRepositry
        {
            get
            {
                return this.blogCommentsRepository;
            }
        }

        public void Commit()
        {
            this.petaTranaction.Complete();
        }

        public void Dispose()
        {
            this.petaTranaction.Dispose();
        }
    }
}