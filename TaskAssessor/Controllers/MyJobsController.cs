using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskAssessor.Models;
using TaskAssessor.ViewModels;
using System.Data.Entity;
using System.Threading;
using System.Globalization;

namespace TaskAssessor.Controllers
{
    [Authorize]
    public class MyJobsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index(string date)
        {
            if (date == null)
                date = SetDate(DateTime.Now);

            var currentUserJobs = _context.HourIntervals.Include(u => u.Job).ToList().Where(u => u.ApplicationUserId == User.Identity.GetUserId() && date.Equals(SetDate(u.DateAdded)));
            if (currentUserJobs == null)
                return View();

            ViewBag.Date = date;
            return View(currentUserJobs);
        }

        public ActionResult Details(int id)
        {
            var interval = _context.HourIntervals.Include(i => i.Job).SingleOrDefault(i => i.Id == id);
            if (interval == null)
                return HttpNotFound();

            return View(interval);
        }

        public ActionResult New()
        {
            var viewModel = new HourIntervalJobs()
            {
                HourInterval = new HourInterval(),
                Jobs = _context.Jobs.ToList()
            };
            return View("CreateMyJob", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var hourInterval = _context.HourIntervals.Include(i => i.Job).SingleOrDefault(i => i.Id == id);
            if (hourInterval == null)
                return HttpNotFound();

            var hourIntervalJobs = new HourIntervalJobs()
            {
                HourInterval = hourInterval,
                Jobs = _context.Jobs.ToList()
            };

            return View("CreateMyJob", hourIntervalJobs);
        }
        [HttpPost]
        public ActionResult CreateMyJob(HourInterval hourInterval)
        {
            if (hourInterval.Id == 0)
            {
                hourInterval.ApplicationUserId = User.Identity.GetUserId();
                hourInterval.DateAdded = DateTime.Now;
                hourInterval.TotalTime = Math.Round((hourInterval.TimeEnded - hourInterval.TimeStarted).TotalHours, 2);
                _context.HourIntervals.Add(hourInterval);
            }else
            {
                var hourIntervalInDb = _context.HourIntervals.Single(h => h.Id == hourInterval.Id);

                hourIntervalInDb.Description = hourInterval.Description;
                hourIntervalInDb.TimeStarted = hourInterval.TimeStarted;
                hourIntervalInDb.TimeEnded = hourInterval.TimeEnded;
                hourIntervalInDb.ApplicationUserId = hourInterval.ApplicationUserId;
                hourIntervalInDb.JobId = hourInterval.JobId;
                hourIntervalInDb.DateAdded = hourIntervalInDb.DateAdded;
                hourIntervalInDb.TotalTime = Math.Round((hourInterval.TimeEnded - hourInterval.TimeStarted).TotalHours, 2);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "MyJobs");

        }



        /************************************************************************************************/
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private string SetDate(DateTime date)
        {
            return date.ToShortDateString();
        }
    }//class
}//namespace