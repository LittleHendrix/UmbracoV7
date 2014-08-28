namespace UmbracoV7Demo.Infrastructure.Providers
{
    using UmbracoV7Demo.Core.Interfaces;
    using UmbracoV7Demo.Infrastructure.Uow;

    public class PetaPocoUnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork GetUnitOfWork()
        {
            return new PetaPocoUnitOfWork();
        }
    }
}
