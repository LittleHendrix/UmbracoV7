// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlogCommentSurfaceController.cs" company="">
//   
// </copyright>
// <summary>
//   The blog comments surface controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UmbracoV7Demo.Controllers
{
    using System.Web.Mvc;

    using Umbraco.Web.Mvc;

    using UmbracoV7Demo.DAL.EntityModels;
    using UmbracoV7Demo.DAL.Infrastructure;
    using UmbracoV7Demo.DAL.Interfaces;
    using UmbracoV7Demo.DAL.Repositories;
    using UmbracoV7Demo.ViewModels;

    /// <summary>
    ///     The blog comments surface controller.
    /// </summary>
    public class BlogCommentSurfaceController : SurfaceController
    {
        #region Fields

        /// <summary>
        ///     The blog comment view model.
        /// </summary>
        private readonly BlogCommentViewModel blogCommentViewModel;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogCommentSurfaceController"/> class.
        /// </summary>
        /// <param name="blogCommentViewModel">
        /// The bc view model.
        /// </param>
        public BlogCommentSurfaceController(BlogCommentViewModel blogCommentViewModel)
        {
            this.blogCommentViewModel = blogCommentViewModel;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The handle comment post.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("PostComment")]
        public ActionResult HandleCommentPost(BlogCommentViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.CurrentUmbracoPage();
            }

            var uowProvider = new PetaPocoUnitOfWorkProvider();
            using (IUnitOfWork uow = new PetaPocoUnitOfWork())
            {
                var blogCommentsRepository = new PetaPocoRepository(uow);

                var comment = new BlogComment
                                  {
                                      Name = model.Name, 
                                      Email = model.Email, 
                                      Message = model.Message, 
                                      BlogPostUmbracoId = model.UmbracoNodeId, 
                                      DatePosted = model.DatePosted
                                  };

                int commentId = blogCommentsRepository.Insert(comment);

                uow.Commit();
            }

            return this.RedirectToCurrentUmbracoPage();
        }

        /// <summary>
        ///     The render comment form.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [ChildActionOnly]
        public ActionResult RenderCommentForm()
        {
            return this.PartialView("CommentForm", this.blogCommentViewModel);
        }

        /// <summary>
        /// The render comments.
        /// </summary>
        /// <param name="umbNodeId">
        /// The umb node id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ChildActionOnly]
        public ActionResult RenderComments(int umbNodeId)
        {
            var blogPostViewModel = new BlogPostViewModel();

            using (IUnitOfWork uow = new PetaPocoUnitOfWork())
            {
                var repository = new PetaPocoRepository(uow);

                blogPostViewModel.UmbracoNodeId = umbNodeId;

                blogPostViewModel.Comments = repository.GetComments(umbNodeId);

                uow.Commit();
            }

            return this.PartialView("CommentsWidget", blogPostViewModel);
        }

        #endregion
    }
}