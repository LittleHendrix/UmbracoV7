// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlogCommentsRepositoryExtension.cs" company="">
//   
// </copyright>
// <summary>
//   The blog comments repository extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.DAL.Repositories
{
    using System.Collections.Generic;

    using Umbraco.Core.Persistence;

    using UmbracoV7Demo.DAL.EntityModels;

    /// <summary>
    /// The blog comments repository extension.
    /// </summary>
    public static class BlogCommentsRepositoryExtension
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get comments.
        /// </summary>
        /// <param name="blogCommentsRepository">
        /// The blog comments repository.
        /// </param>
        /// <param name="blogPostId">
        /// The blog post id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<BlogComment> GetComments(
            this PetaPocoRepository blogCommentsRepository, 
            int blogPostId)
        {
            Sql sql =
                Sql.Builder.Select("*")
                    .From<BlogComment>()
                    .Where<BlogComment>(x => x.BlogPostUmbracoId == blogPostId)
                    .OrderByDescending<BlogComment>(x => x.DatePosted);

            return blogCommentsRepository.Query<BlogComment>(sql);
        }

        #endregion
    }
}