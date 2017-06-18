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
    public class GrifNamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GrifNames
        public ActionResult Index()
        {
            return View(db.GrifNames.ToList());
        }

        // GET: GrifNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrifName grifName = db.GrifNames.Find(id);
            if (grifName == null)
            {
                return HttpNotFound();
            }
            return View(grifName);
        }

        // GET: GrifNames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrifNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrifNameId,Name")] GrifName grifName)
        {
            if (ModelState.IsValid)
            {
                db.GrifNames.Add(grifName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grifName);
        }

        // GET: GrifNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrifName grifName = db.GrifNames.Find(id);
            if (grifName == null)
            {
                return HttpNotFound();
            }
            return View(grifName);
        }

        // POST: GrifNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrifNameId,Name")] GrifName grifName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grifName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grifName);
        }

        // GET: GrifNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrifName grifName = db.GrifNames.Find(id);
            if (grifName == null)
            {
                return HttpNotFound();
            }
            return View(grifName);
        }

        // POST: GrifNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrifName grifName = db.GrifNames.Find(id);
            db.GrifNames.Remove(grifName);
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
