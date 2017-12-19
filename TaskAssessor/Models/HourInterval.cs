using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskAssessor.Models
{
    public class HourInterval
    {
        public int Id { get; set; }

        [Display(Name = "Started at")]
        public TimeSpan TimeStarted { get; set; }

        //will need here custom validation attribute. TimeEnded > TimeStarted
        [Display(Name = "Ended at")]
        public TimeSpan TimeEnded { get; set; }

        public DateTime DateAdded { get; set; }

        public string Description { get; set; }

        private double totalTime = 0;

        public double TotalTime
        {
            get { return totalTime; }
            set { totalTime = Math.Round((TimeEnded - TimeStarted).TotalHours, 2); }
        }

        //foreign keys
        public string ApplicationUserId { get; set; }
        public int JobId { get; set; }

        //nav properties
        public Job Job { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}