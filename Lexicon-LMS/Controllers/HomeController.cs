using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lexicon_LMS.Models;

namespace Lexicon_LMS.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.ActivityType).Include(a => a.Module);
            List<Activity> SortedList = activities.ToList().OrderBy(o => o.StartDate).ToList();
            return View(SortedList);
        }

        public ActionResult GetExerciseToSubmit()
        {
            if (Request.IsAjaxRequest())
            {
                var activities = db.Activities.Include(a => a.ActivityType).Include(a => a.Module);

                if (activities == null)
                {
                    ViewBag.Message = "Did not find your any item!";
                }
                return PartialView("_RightMenuBar", activities.ToList());

            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}