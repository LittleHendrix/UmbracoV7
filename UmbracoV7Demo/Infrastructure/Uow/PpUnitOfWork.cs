namespace UmbracoV7Demo.Infrastructure.Uow
{
    using Umbraco.Core;
    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.Infrastructure.Data.Models;
    using UmbracoV7Demo.Infrastructure.Interfaces;
    using UmbracoV7Demo.Infrastructure.Repositories;

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