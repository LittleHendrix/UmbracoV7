namespace UmbracoV7Demo.DAL.Interfaces
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork GetUnitOfWork();
    }
}
