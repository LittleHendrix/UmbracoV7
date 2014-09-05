namespace UmbracoV7Demo.DAL.Interfaces
{
    using System;

    using UmbracoV7Demo.DAL.EntityModels;

    public interface IUnitOfWork : IDisposable
    {
        IRepository<BlogComment> BlogCommentsRepositry { get; }

        void Commit();
    }
}