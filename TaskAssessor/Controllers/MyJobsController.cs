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
    public class MyJobsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        private string SetDate(DateTime date)
        { 
            return date.ToShortDateString();
        }


        // GET: MyJobs
        public ActionResult Index(string date)
        {
            if (date == null)
            {
                date = SetDate(DateTime.Now);
            }

            var currentUserJobs = _context.HourIntervals.Include(u => u.Job).ToList().Where(u => u.ApplicationUserId == User.Identity.GetUserId() && date.Equals(SetDate(u.DateAdded)));
            if (currentUserJobs == null)
            {
                return View();
            }

            return View(currentUserJobs);
        }
      

        [Authorize]
        public ActionResult New()
        {
            var viewModel = new HourIntervalJobs()
            {
                HourInterval = new HourInterval(),
                Jobs = _context.Jobs.ToList()
            };
            return View("CreateMyJob", viewModel);
        }
        [HttpPost]
        public ActionResult CreateMyJob(HourInterval hourInterval)
        {
            if (hourInterval.Id == 0)
            {
                hourInterval.ApplicationUserId = User.Identity.GetUserId();
                hourInterval.DateAdded = DateTime.Now;
                _context.HourIntervals.Add(hourInterval);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "MyJobs");

        }


    }//class
}//namespace