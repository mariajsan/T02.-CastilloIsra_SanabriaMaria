using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Web.Models;

namespace Proyecto_Web.Controllers
{
    public class ComentariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comentaries
        public ActionResult Index()
        {
            var comentaries = db.Comentaries.Include(c => c.Article).Include(c => c.User);
            return View(comentaries.ToList());
        }

        // GET: Comentaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentary comentary = db.Comentaries.Find(id);
            if (comentary == null)
            {
                return HttpNotFound();
            }
            return View(comentary);
        }

        // GET: Comentaries/Create
        public ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title");
            ViewBag.UserId = new SelectList(db.IdentityUsers, "Id", "Email");
            return View();
        }

        // POST: Comentaries/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,Date,UserId,ArticleId")] Comentary comentary)
        {
            if (ModelState.IsValid)
            {
                db.Comentaries.Add(comentary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title", comentary.ArticleId);
            ViewBag.UserId = new SelectList(db.IdentityUsers, "Id", "Email", comentary.UserId);
            return View(comentary);
        }

        // GET: Comentaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentary comentary = db.Comentaries.Find(id);
            if (comentary == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title", comentary.ArticleId);
            ViewBag.UserId = new SelectList(db.IdentityUsers, "Id", "Email", comentary.UserId);
            return View(comentary);
        }

        // POST: Comentaries/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,Date,UserId,ArticleId")] Comentary comentary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title", comentary.ArticleId);
            ViewBag.UserId = new SelectList(db.IdentityUsers, "Id", "Email", comentary.UserId);
            return View(comentary);
        }

        // GET: Comentaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentary comentary = db.Comentaries.Find(id);
            if (comentary == null)
            {
                return HttpNotFound();
            }
            return View(comentary);
        }

        // POST: Comentaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentary comentary = db.Comentaries.Find(id);
            db.Comentaries.Remove(comentary);
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
