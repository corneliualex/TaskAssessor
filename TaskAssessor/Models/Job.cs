using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskAssessor.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public string AddedBy { get; set; }
    }
}