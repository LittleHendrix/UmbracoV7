namespace UmbracoV7Demo.ViewModels
{
    using System.Collections.Generic;

    using UmbracoV7Demo.DAL.EntityModels;

    public class BlogPostViewModel
    {
        public int UmbracoNodeId { get; set; }

        public IEnumerable<BlogComment> Comments { get; set; }
    }
}