using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskAssessor.Models.CustomValidations;

namespace TaskAssessor.Models
{
    public class HourInterval
    {
        public int Id { get; set; }

        [LessThanEnded] //custom validation
        [Display(Name = "Started at")]
        public TimeSpan TimeStarted { get; set; }

        [GreaterThanStarted] //custom validation
        [Display(Name = "Ended at")]
        public TimeSpan TimeEnded { get; set; }

        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(500, MinimumLength = 6)]
        public string Description { get; set; }

        //private double totalTime = 0;

        public double TotalTime
        {
            get; //{ return totalTime;}
            set; //{ totalTime = Math.Round((TimeEnded - TimeStarted).TotalHours, 2); }
        }

        //foreign keys
        public string ApplicationUserId { get; set; }

        [Display(Name = "Job")]
        [Required(ErrorMessage = "Required")]
        public Int32? JobId { get; set; }

        //nav properties
        public Job Job { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}