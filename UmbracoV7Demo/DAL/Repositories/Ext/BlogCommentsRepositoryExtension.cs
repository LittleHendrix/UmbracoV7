namespace UmbracoV7Demo.DAL.Repositories
{
    using System.Collections.Generic;

    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.DAL.EntityModels;

    public static class BlogCommentsRepositoryExtension
    {
        public static IEnumerable<BlogComment> GetComments(this PetaPocoRepository blogCommentsRepository, int blogPostId)
        {
            var sql = Sql.Builder.Append("SELECT * FROM BlogComments WHERE BlogPostUmbracoId = @0", blogPostId);
            return blogCommentsRepository.Query<BlogComment>(sql.ToString());
        }
    }
}