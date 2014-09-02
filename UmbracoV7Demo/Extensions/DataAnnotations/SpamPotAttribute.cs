﻿namespace UmbracoV7Demo.Extensions.DataAnnotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class SpamPotAttribute : ValidationAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return string.IsNullOrEmpty(Convert.ToString(value)) ? ValidationResult.Success : new ValidationResult("Honeypot must be left empty.");
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata,
            ControllerContext context)
        {
            yield return new ModelClientValidationRule { ErrorMessage = this.ErrorMessage, ValidationType = "spampot" };
        } 
    }
}