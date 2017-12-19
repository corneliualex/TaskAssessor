using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskAssessor.Models;
using System.Data.Entity;
using TaskAssessor.ViewModels;
using Microsoft.AspNet.Identity;

namespace TaskAssessor.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Jobs
        public ActionResult Index()
        {
            var jobs = _context.Jobs.Include(user => user.ApplicationUser).ToList();
            return View(jobs);
        }

        //gets details regarding a task and sends them to the client
        public ActionResult Details(int id)
        {
            var job = _context.Jobs.Include(user => user.ApplicationUser).SingleOrDefault(j => j.Id == id);
            if (job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }

        [Authorize]
        public ActionResult New()
        {
            return View("CreateJob", new Job());
        }

        public ActionResult Edit(int id)
        {
            var job = _context.Jobs.Include(user => user.ApplicationUser).SingleOrDefault(j => j.Id == id);
            if (job == null)
            {
                return HttpNotFound();
            }

            return View("CreateJob", job);
        }

        public ActionResult Delete(int id)
        {
            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);
            if (job == null)
            {
                return HttpNotFound();
            }
            _context.Jobs.Remove(job);
            _context.SaveChanges();

            return RedirectToAction("Index", "Jobs");
        }

        [HttpPost]
        public ActionResult CreateJob(Job job)
        {

            if (job.Id == 0)
            {
                job.DateAdded = DateTime.Now;
                job.ApplicationUserId = User.Identity.GetUserId();
                _context.Jobs.Add(job);
            }
            else
            {
                var jobInDb = _context.Jobs.Single(j => j.Id == job.Id);
                jobInDb.Name = job.Name;
                jobInDb.DateAdded = job.DateAdded;
                jobInDb.DateModified = DateTime.Now;
                jobInDb.ApplicationUserId = job.ApplicationUserId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Jobs");
        }

    }

}