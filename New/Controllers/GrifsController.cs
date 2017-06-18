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
    public class GrifsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Grifs
        public ActionResult Index()
        {
            var grifs = db.Grifs.Include(g => g.GrifNames).Include(g => g.KIs).Include(g => g.Laws);
            return View(grifs.ToList());
        }

        // GET: Grifs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grif grif = db.Grifs.Find(id);
            if (grif == null)
            {
                return HttpNotFound();
            }
            return View(grif);
        }

        [Authorize]
        // GET: Grifs/Create
        public ActionResult Create()
        {
            ViewBag.GrifNameId = new SelectList(db.GrifNames, "GrifNameId", "Name");
            ViewBag.KIId = new SelectList(db.KIs, "KIId", "UniRegNum");
            ViewBag.LawId = new SelectList(db.Laws, "LawId", "LawName");
            return View();
        }

        // POST: Grifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrifId,GrifNameId,LawId,DateCreated,DateExpired, KIId")] Grif grif)
        {
            var user = System.Web.HttpContext.Current.User.Identity.Name;
                grif.User.UserName = user;
            if (ModelState.IsValid)
            {
                db.Grifs.Add(grif);
                db.SaveChanges();
                return RedirectToAction("Details", "KIs", new { id = grif.KIId });
            }

            ViewBag.GrifNameId = new SelectList(db.GrifNames, "GrifNameId", "Name", grif.GrifNameId);
            
            ViewBag.LawId = new SelectList(db.Laws, "LawId", "LawName", grif.LawId);

            ViewBag.KIId = new SelectList(db.KIs, "KIId", "UniRegNum", grif.KIId);

            return RedirectToAction("Details", "KIs", new { id = grif.KIId });
        }

        // GET: Grifs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grif grif = db.Grifs.Find(id);
            if (grif == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrifNameId = new SelectList(db.GrifNames, "GrifNameId", "Name", grif.GrifNameId);
            ViewBag.KIId = new SelectList(db.KIs, "KIId", "UniRegNum", grif.KIId);
            ViewBag.LawId = new SelectList(db.Laws, "LawId", "LawName", grif.LawId);
            return View(grif);
        }

        // POST: Grifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Grif grif)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(grif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "KIs", new { id = grif.KIId });
            }
            ViewBag.GrifNameId = new SelectList(db.GrifNames, "GrifNameId", "Name", grif.GrifNameId);
            ViewBag.LawId = new SelectList(db.Laws, "LawId", "LawName", grif.LawId);

            ViewBag.KIId = new SelectList(db.KIs, "KIId", "UniRegNum", grif.KIId);
           
            return RedirectToAction("Details", "KIs", new { id = grif.KIId });
        }

        //[Authorize(Roles ="Admin")]
        // GET: Grifs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grif grif = db.Grifs.Find(id);
            if (grif == null)
            {
                return HttpNotFound();
            }
            return View(grif);
        }

        // POST: Grifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grif grif = db.Grifs.Find(id);
            
            db.Grifs.Remove(grif);
            db.SaveChanges();
            return RedirectToAction("Details", "KIs", new { id = grif.KIId });
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
