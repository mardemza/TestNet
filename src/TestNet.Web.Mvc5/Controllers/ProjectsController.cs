using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestNet.Web.Mvc5.Extentions;
using TestNet.Web.Mvc5.Models;
using TestNet.Web.Mvc5.Models.Domain;

namespace TestNet.Web.Mvc5.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projects
        public ActionResult Index()
        {
            var createdUserId = User.GetUserId();

            var projects = db.Projects.Where(x => x.CreatedUserId == createdUserId);

            ViewBag.ProjectWithTasksAsigned = db.Projects.Where(x => x.Jobs.Any(s => s.AsignedUserId == createdUserId));         
            return View(projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.FirstOrDefault(x => x.CreatedUserId == User.GetUserId());
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.CreatedUserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Projects/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Start,End,CreatedUserId,Created")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedUserId = new SelectList(db.Users, "Id", "Email", project.CreatedUserId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.FirstOrDefault(x => x.CreatedUserId == User.GetUserId());
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedUserId = new SelectList(db.Users, "Id", "Email", project.CreatedUserId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Start,End,CreatedUserId,Created")] Project project)
        {
            if (ModelState.IsValid && db.Projects.Any(x => x.Id == project.Id && x.CreatedUserId == User.GetUserId()))
            {                
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedUserId = new SelectList(db.Users, "Id", "Email", project.CreatedUserId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.FirstOrDefault(x => id.HasValue && x.Id == id.Value && x.CreatedUserId == User.GetUserId());
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (db.Projects.Any(x => x.Id == id && x.CreatedUserId == User.GetUserId()))
            {
                Project project = db.Projects.Find(id);
                db.Projects.Remove(project);
                db.SaveChanges();
            }
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
