// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpamProtectionAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   The spam protection attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UmbracoV7Demo.Extensions.DataAnnotations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The spam protection attribute.
    /// </summary>
    public class SpamProtectionAttribute : ValidationAttribute
    {
        public int Timespan { get; private set; }

        public SpamProtectionAttribute(int timespan)
        {
            this.Timespan = timespan;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                long timestamp = long.MaxValue;

                if (long.TryParse(value.ToString(), out timestamp))
                {
                    var currentTime = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

                    if (currentTime <= timestamp - this.Timespan)
                    {
                        return
                            new ValidationResult(
                                string.Format(
                                    "Invalid form submission. At least {0} seconds have to pass before form submission ({1}).",
                                    this.Timespan.ToString(),
                                    value.ToString()));
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}