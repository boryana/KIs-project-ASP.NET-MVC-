using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using New.Models;

namespace New.Controllers
{
    public class LawsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Laws
        public ActionResult Index()
        {
            return View(db.Laws.ToList());
        }

        // GET: Laws/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Law law = db.Laws.Find(id);
            if (law == null)
            {
                return HttpNotFound();
            }
            return View(law);
        }

        // GET: Laws/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Laws/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LawId,LawName")] Law law)
        {
            if (ModelState.IsValid)
            {
                db.Laws.Add(law);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(law);
        }

        // GET: Laws/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Law law = db.Laws.Find(id);
            if (law == null)
            {
                return HttpNotFound();
            }
            return View(law);
        }

        // POST: Laws/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LawId,LawName")] Law law)
        {
            if (ModelState.IsValid)
            {
                db.Entry(law).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(law);
        }

        // GET: Laws/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Law law = db.Laws.Find(id);
            if (law == null)
            {
                return HttpNotFound();
            }
            return View(law);
        }

        // POST: Laws/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Law law = db.Laws.Find(id);
            db.Laws.Remove(law);
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
