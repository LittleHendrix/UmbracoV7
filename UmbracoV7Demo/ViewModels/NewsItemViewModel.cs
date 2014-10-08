namespace UmbracoV7Demo.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class NewsItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Page heading is required")]
        public string PageHeading { get; set; }

        public string PageMedia { get; set; }

        public string BodyText { get; set; }

        public bool SearchEngineHide { get; set; }

        public bool UmbracoNaviHide { get; set; }

        public string CreatorName { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}