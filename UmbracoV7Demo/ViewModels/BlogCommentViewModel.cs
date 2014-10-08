namespace UmbracoV7Demo.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using UmbracoV7Demo.Extensions.DataAnnotations;

    public class BlogCommentViewModel
    {
        [SpamPot(ErrorMessage = "Honeypot must be left empty.")]
        public string Honeypot { get; set; }

        [SpamTimer(6)]
        public long TimeStamp { get; set; }

        [Required]
        public int UmbracoNodeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Comment")]
        public string Message { get; set; }

        [Required]
        public DateTime DatePosted { get; set; }
    }
}