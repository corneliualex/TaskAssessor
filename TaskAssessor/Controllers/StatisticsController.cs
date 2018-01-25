using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace TaskAssessor.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        //instead of index
        public ActionResult UserProfile()
        {
            ViewBag.CurrentUser = User.Identity.GetUserName() ;
            return View();
        }


        //Stats per Task
        public ActionResult HoursPerTask(string jobName)
        {
            return View();
        }

        public ActionResult GeneralStatsPerTask()
        {
            return View();
        }


        //Stats per User
        public ActionResult HoursPerUser(string userName)
        {
            return View();
        }

        public ActionResult GeneralStatsPerUser()
        {
            return View();
        }


        //Combined
        public ActionResult HoursPerUserTask()
        {
            return View();
        }


    }
}