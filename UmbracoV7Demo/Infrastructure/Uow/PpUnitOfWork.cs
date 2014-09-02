namespace UmbracoV7Demo.Infrastructure.Uow
{

    using Umbraco.Core;
    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.Core.Interfaces;
    using UmbracoV7Demo.Infrastructure.Data.Models;
    using UmbracoV7Demo.Infrastructure.Repositories;

    public abstract class PpUnitOfWork : IUnitOfWork
    {
        private readonly GenericRepository<BlogComment> blogRepository;

        private readonly Database db;

        private readonly Transaction petaTranaction;


        public PpUnitOfWork()
        {
            this.db = ApplicationContext.Current.DatabaseContext.Database;
            this.petaTranaction = new Transaction(this.db);

            this.blogRepository = new GenericRepository<BlogComment>(this.db);
        }

        public IRepository<BlogComment> BlogComments
        {
            get
            {
                return this.blogRepository;
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