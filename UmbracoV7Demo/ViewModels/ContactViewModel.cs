namespace UmbracoV7Demo.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ContactViewModel
    {
        public string Captcha { get; set; }

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