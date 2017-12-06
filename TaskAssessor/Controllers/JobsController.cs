using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskAssessor.Models;

namespace TaskAssessor.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Jobs
        public ActionResult Index()
        {
            var jobs = _context.Jobs.ToList();

            return View(jobs);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
        
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateForm(Job job)
        {
            return View();
        }
    }
}