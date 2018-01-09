using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskAssessor.Models.CustomValidations
{
    public class GreaterThanStarted : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var hourInterval = (HourInterval)validationContext.ObjectInstance;

            if (hourInterval.TimeEnded <= hourInterval.TimeStarted)
                return new ValidationResult("Time Ended should be greater than Time Started");

            return ValidationResult.Success;
        }
    }
}