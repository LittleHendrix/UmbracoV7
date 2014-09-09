namespace UmbracoV7Demo.Controllers
{
    using System.Web.Mvc;
    using UmbracoV7Demo.DAL.EntityModels;
    using UmbracoV7Demo.DAL.Infrastructure;
    using UmbracoV7Demo.DAL.Repositories;

    public class BlogCommentsController
    {
        public ActionResult Index()
        {
            var uowProvider = new PetaPocoUnitOfWorkProvider();
            using (var uow = uowProvider.GetUnitOfWork())
            {
                var blogCommentsRepository = new PetaPocoRepository(uow);

                var comment = new BlogComment();
                comment.Email = "luchen_sv@msn.com";

                var id = blogCommentsRepository.Insert(comment);

                uow.Commit();
            }

        }
    }
}