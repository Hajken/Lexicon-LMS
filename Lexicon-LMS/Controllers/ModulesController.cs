using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lexicon_LMS.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Lexicon_LMS;

namespace Lexicon_LMS.Controllers
{
    [Authorize]
    public class ModulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ApplicationUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

        // GET: Modules
        public async Task<ActionResult> Index(int? id)
        {
            var CurrentUser = await UserManager.FindByNameAsync(User.Identity.Name);
            
            int? courseId = User.IsInRole("Teacher") ? id : CurrentUser.CourseId;
            var modules = db.Modules.Where(a => a.CourseId == courseId);

            ViewBag.BreadCrumbs = Url.BreadCrumb(db.Courses.Find(courseId));

            return View(modules.ToList());

         }

        // GET: Modules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }
        // GET: Modules/ModuleDetails/5
        public ActionResult ModuleDocuments(int? id)
        {
            //ApplicationUser CurrentUser = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();

            //var cUserRoleId = CurrentUser.Roles.First().RoleId;

            //var roleIdTeacher = db.Roles.FirstOrDefault(x => x.Name == "Teacher").Id;

            //var ModuleDocuments = db.Documents.Where(doc => doc.ModuleId == id && doc.CourseId==doc.Module.CourseId && doc.User.Roles.FirstOrDefault().RoleId == roleIdTeacher);

            var ModuleDocuments = db.Documents.Where(doc => doc.ModuleId == id && doc.IsHandIn == false);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModuleDocuments == null)
            {
                return HttpNotFound();
            }
            ViewBag.BreadCrumbs = Url.BreadCrumb(db.Modules.Find(id));

            return View(ModuleDocuments);


            //var ActiveModule = db.Modules.Where(m => m.ModuleId == id).FirstOrDefault();
            //var roleName = db.Roles.FirstOrDefault(x => x.Id == cUserRoleId).Name;
            //   var d = db.Modules.Where(u => u.Documents.FirstOrDefault().User.Roles.FirstOrDefault().RoleId==roleIdTeacher);
            //var courseDocument = db.Documents.Where(u => u.CourseId == ActiveModule.CourseId && u.User.Roles.FirstOrDefault().RoleId == roleIdTeacher);
            //   Module module = db.Modules.Find(id);
            //Document documents = db.Documents.Find(id);



        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModuleId,Name,Description,StartDate,EndDate,CourseId")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Modules.Add(module);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", module.CourseId);
            return View(module);
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", module.CourseId);
            return View(module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModuleId,Name,Description,StartDate,EndDate,CourseId")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", module.CourseId);
            return View(module);
        }

        // GET: Modules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Module module = db.Modules.Find(id);
            db.Modules.Remove(module);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
