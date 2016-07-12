﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lexicon_LMS.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using PagedList;
using PagedList.Mvc;

namespace Lexicon_LMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("Index", "Courses");
            }
            else
            {
               
                var activities = db.Activities.Include(a => a.ActivityType).Include(a => a.Module);
                List<Activity> SortedList = activities.ToList().OrderBy(o => o.StartDate).ToList();
                ViewBag.Count = SortedList.Count();
                ViewBag.C = SortedList.Where(x => x.StartDate.Date == DateTime.Now.Date).Count();


                int indexOfTodaysActivity = SortedList.FindIndex(c => c.StartDate.Date == DateTime.Now.Date);
               
                int? pageSchedule = page;
                if (pageSchedule==null)
                {
                    page = (indexOfTodaysActivity / pageSize) + 1;
                    return View(SortedList.ToPagedList(page ?? 1, pageSize));
                   
                }
                else
                {
                   
                    return View(SortedList.ToPagedList(page ?? 1, pageSize));
                }
                 
                
        }
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
        public ActionResult Documents(int? id)
        {
            //var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            //ApplicationUser CurrentUser = userManager.FindById(User.Identity.GetUserId()); // db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            //var cUserRoleId = CurrentUser.Roles.First().RoleId;

            //    .Where(doc => doc.IsPublic)
            //    .Where(doc=>doc.User.Roles.FirstOrDefault().RoleId == roleIdTeacher && doc.CourseId==CurrentUser.CourseId);

            //if (User.IsInRole("Teacher")) { var courseDocument = db.Documents.Where(doc => doc.User.Roles.FirstOrDefault().RoleId == roleIdTeacher && doc.CourseId ==doc.Course.CourseId); }

           ApplicationUser CurrentUser = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
           var roleIdTeacher = db.Roles.FirstOrDefault(x =>x.Name == "Teacher").Id;
            
            if (User.IsInRole("Teacher"))
            {
               var  courseDocument = db.Documents.Where(doc => doc.IsHandIn==false && doc.CourseId ==id &&doc.CourseId!=null);
                return View(courseDocument);
            }

            else
        {
                var courseDocument = db.Documents.Where(doc => doc.User.Roles.FirstOrDefault().RoleId == roleIdTeacher && doc.CourseId == CurrentUser.CourseId);
                return View(courseDocument);
            }
         

           

            


           
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