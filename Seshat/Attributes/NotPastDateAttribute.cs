using System;
using System.ComponentModel.DataAnnotations;

namespace MikeRobbins.Seshat.Attributes
{
    public class NotPastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateProperty = (DateTime)value;

            DateTime dateNow = DateTime.Now;

            return dateProperty >= dateNow ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}