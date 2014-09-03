// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PpBlogCommentsRepositoryExtension.cs" company="">
//   
// </copyright>
// <summary>
//   The pp blog comments repository extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Infrastructure.Repositories.Ext
{
    using System.Collections.Generic;

    using UmbracoV7Demo.Core.Interfaces;
    using UmbracoV7Demo.Infrastructure.Data.Models;

    /// <summary>
    /// The pp blog comments repository extension.
    /// </summary>
    public static class PpBlogCommentsRepositoryExtension
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get all comments by post id.
        /// </summary>
        /// <param name="blogCommentsRepository">
        /// The blog comments repository.
        /// </param>
        /// <param name="postId">
        /// The post id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<BlogComment> GetAllCommentsByPostId(
            this IRepository<BlogComment> blogCommentsRepository, 
            int postId)
        {
            return blogCommentsRepository.Find(x => x.BlogPostUmbracoId == postId);
        }

        #endregion
    }
}