namespace UmbracoV7Demo.Infrastructure.Interfaces
{
    using System;

    using UmbracoV7Demo.Infrastructure.Data.Models;

    public interface IUnitOfWork : IDisposable
    {
        IRepository<BlogComment> BlogCommentsRepositry { get; }

        void Commit();
    }
}