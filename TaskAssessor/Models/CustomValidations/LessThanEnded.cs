using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskAssessor.Models
{
    public class LessThanEnded : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var hourInterval = (HourInterval)validationContext.ObjectInstance;

            if (hourInterval.TimeStarted >= hourInterval.TimeEnded)
                return new ValidationResult("Time Started should be less than Time Ended");

            return ValidationResult.Success;
        }
    }
}