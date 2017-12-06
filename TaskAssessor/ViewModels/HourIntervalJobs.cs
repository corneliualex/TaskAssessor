using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskAssessor.Models;

namespace TaskAssessor.ViewModels
{
    public class HourIntervalJobs
    {
        public HourInterval HourInterval { get; set; }

        public IEnumerable<Job> Jobs { get; set; }
    }
}