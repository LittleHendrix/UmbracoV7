﻿namespace UmbracoV7Demo.DAL.Interfaces
{
    using System;

    using Umbraco.Core.Persistence;

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Database Db { get; }
    }
}