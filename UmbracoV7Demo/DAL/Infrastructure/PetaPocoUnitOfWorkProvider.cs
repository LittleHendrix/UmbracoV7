namespace UmbracoV7Demo.DAL.Infrastructure
{
    using UmbracoV7Demo.DAL.Interfaces;

    public class PetaPocoUnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork GetUnitOfWork()
        {
            return new PetaPocoUnitOfWork();
        }
    }
}