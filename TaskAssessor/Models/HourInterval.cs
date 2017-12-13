using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskAssessor.Models
{
    public class HourInterval
    {
        public int Id { get; set; }
        public TimeSpan TimeStarted { get; set; }
        public TimeSpan TimeEnded { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public double TotalTime { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int JobId { get; set; }
        //nav property using EagerLoading 
        public Job Job { get; set; }
    }
}