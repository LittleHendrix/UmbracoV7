// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpamTimerAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   The spam protection attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UmbracoV7Demo.Extensions.DataAnnotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    ///     The spam protection attribute.
    /// </summary>
    public class SpamTimerAttribute : ValidationAttribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SpamTimerAttribute"/> class.
        /// </summary>
        /// <param name="timespan">
        /// The timespan.
        /// </param>
        public SpamTimerAttribute(int timespan)
        {
            this.Timespan = timespan;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the timespan.
        /// </summary>
        public int Timespan { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="validationContext">
        /// The validation context.
        /// </param>
        /// <returns>
        /// The <see cref="ValidationResult"/>.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            long timestamp;

            if (long.TryParse(Convert.ToString(value), out timestamp))
            {
                var currentTime = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

                if (currentTime <= timestamp + this.Timespan)
                {
                    return
                        new ValidationResult(
                            string.Format(
                                "Invalid form submission. At least {0} seconds have to pass before form submission ({1}).", 
                                this.Timespan, 
                                value));
                }
            }

            return ValidationResult.Success;
        }

        #endregion
    }
}