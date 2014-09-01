namespace UmbracoV7Demo.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using UmbracoV7Demo.Extensions.DataAnnotations;

    public class ContactViewModel
    {
        [StringLength(0, ErrorMessage = "Gotcha!")]
        public string Honeypot { get; set; }

        [SpamProtection(60)]
        public long TimeStamp { get; set; }

        [Required]
        public DateTime SubmitDate { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [Display(Name = "Email")]
        [StringLength(50)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(1024)]
        public string Message { get; set; }
    }
}