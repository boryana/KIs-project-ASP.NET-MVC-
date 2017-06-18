using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using New.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using New.Controllers;


namespace New.Controllers
{
    public class KIsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: KIs
        public ActionResult Index()
        {
            ViewBag.grId = new SelectList(db.GrifNames, "GrifNameId", "Name");
            return View(db.KIs.ToList());
        }

        // GET: KIs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KI kI = db.KIs.Find(id);
            if (kI == null)
            {
                return HttpNotFound();
            }
            return View(kI);
        }

        // GET: KIs/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.GrifNameId = new SelectList(db.GrifNames, "GrifNameId", "Name");
            ViewBag.KIId = new SelectList(db.KIs, "KIId", "UniRegNum");
            ViewBag.LawId = new SelectList(db.Laws, "LawId", "LawName");
            return View();

        }

        // POST: KIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KIId,UniRegNum,OE,Note,GrifId,GrifNameId,LawId,DateCreated, DateExpired, KIId")] CreateKiViewModel vki)
        {
            if (ModelState.IsValid)
            {
                var ki = new KI();

                //ki.Number = vki.Number;
                ki.UniRegNum = vki.UniRegNum;
                var p = ki.UniRegNum.Substring(ki.UniRegNum.Length - 10);
                if (ki.UniRegNum.Length < 25)  { return View("Error"); }
                //DateTime dateCr = DateTime.ParseExact(p, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime dateCr;
                try
                {
                     dateCr = DateTime.ParseExact(p, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    
                }
                catch {
                    //throw new ArgumentException(" Not a valid date");
                    //return RedirectToAction("Create");
                    return View("Error");
                }

                dateCr = DateTime.ParseExact(p, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                ki.OE = vki.OE;
                ki.Note = vki.Note;
                db.KIs.Add(ki);
               db.SaveChanges();

                var gr = new Grif();

                ViewBag.GrifNameId = new SelectList(db.GrifNames, "GrifNameId", "Name", vki.GrifNameId);
                ViewBag.LawId = new SelectList(db.Laws, "LawId", "LawName", vki.LawId);
                
                gr.GrifNameId = vki.GrifNameId;
                gr.LawId = vki.LawId;
                gr.DateCreated = dateCr;
                gr.DateExpired = vki.DateExpired;
                gr.KIId = ki.KIId;

                gr.UserId = User.Identity.GetUserId();
                db.Grifs.Add(gr);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddGrif()
        {
            ViewBag.GrifNameId = new SelectList(db.GrifNames, "GrifNameId", "Name");
            ViewBag.LawId = new SelectList(db.Laws, "LawId", "LawName");
            return View();
        }


        [HttpPost]
        public ActionResult AddGrif(int id, Grif grif)
        {
            var gr = new Grif();

            ViewBag.GrifNameId = new SelectList(db.GrifNames, "GrifNameId", "Name", grif.GrifNameId);
            ViewBag.LawId = new SelectList(db.Laws, "LawId", "LawName", grif.LawId);
            
            gr.GrifNameId = grif.GrifNameId;
            gr.LawId = grif.LawId;
            gr.DateCreated = grif.DateCreated;
            gr.DateExpired = grif.DateExpired;

            gr.KIId = id;
            db.Grifs.Add(gr);
            db.SaveChanges();

            return RedirectToAction("Index");
        }





        // GET: KIs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ki = db.KIs.Find(id);
            
            if (ki == null)
            {
                return HttpNotFound();
            }
            
            return View(ki);
        }



        // POST: KIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KI ki)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(ki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ki);
        }


        // GET: KIs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KI kI = db.KIs.Find(id);
            if (kI == null)
            {
                return HttpNotFound();
            }
            return View(kI);
        }

        // POST: KIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KI kI = db.KIs.Find(id);
            db.KIs.Remove(kI);
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




        public ActionResult SearchByGrif(string grId)
        {
            ViewBag.grId = new SelectList(db.GrifNames, "GrifNameId", "Name");

            //var query =from ki in db.KIs select ki;

            var l = new List<Grif>();
            var m = new List<KI>();
            var kis = db.KIs.Include(x => x.Grifs).ToList();

            if (!string.IsNullOrEmpty(grId))
            {
                foreach (KI k in kis)
                {
                    foreach (Grif g in k.Grifs)
                    {
                        l.Add(g);
                    }

                    var p = l.LastOrDefault();
                    if ((p.GrifNameId.ToString() == grId))//&&(p.DateExpired>DateTime.Now))
                    {
                        m.Add(k);
                    }
                }

            }
            m.OrderBy(f => f.Grifs);//.OrderBy(s => s.DateExpired));
            return View(m);
        }


        public ActionResult SearchByYearExpired(string year)
        {
            ViewBag.grId = new SelectList(db.GrifNames, "GrifNameId", "Name");

            var kis = db.KIs.Include(x => x.Grifs).ToList();
            //kis = from ki in db.KIs select ki;
            var l = new List<Grif>();
            var m = new List<KI>();
            if (!string.IsNullOrEmpty(year))
            {
                foreach (KI k in kis)
                {
                    foreach (Grif g in k.Grifs)
                    {
                        l.Add(g);
                    }

                    var p = l.LastOrDefault();
                    if (p.DateExpired.Year.ToString()==year)
                    {
                        m.Add(k);
                    }
                }

            }

            return View(m);
        }


        public ActionResult SearchByYearCreated(string year)
        {
            ViewBag.grId = new SelectList(db.GrifNames, "GrifNameId", "Name");

            var kis = db.KIs.Include(x => x.Grifs).ToList();
            var l = new List<Grif>();
            var m = new List<KI>();
            if (!string.IsNullOrEmpty(year))
            {
                foreach (KI k in kis)
                {
                    foreach (Grif g in k.Grifs)
                    {
                        l.Add(g);
                    }

                    var p = l.LastOrDefault();
                    if (p.DateCreated.Year.ToString() == year)
                    {
                        m.Add(k);
                    }
                }

            }

            return View(m);
        }

        
        public ActionResult Count()
        {
            //var u = 0;
            var l = new List<Grif>();
            var GrifnameLength = db.GrifNames.Count();
            int[] m = new int[GrifnameLength];
            var gn = db.GrifNames.ToList();
            var kis = db.KIs.ToList();
            for (int i = 0; i < (gn.Count()); i++)
            {
                foreach (var k in kis)
                {
                    foreach (var g in k.Grifs)
                    {
                        l.Add(g);
                    }

                    var p = l.LastOrDefault(); //aktualen grif
                    if (gn[i] != null)
                    {
                        if (p.GrifNames.Name == gn[i].Name)
                        {
                            m[i] = m[i] + 1;
                        }
                    }
                }
            }
            ViewBag.all = db.KIs.Count();
            ViewBag.m = m;
            return View(gn);
        }


        public ActionResult CreateLawBtn()
        {
            return View();
        }

        // POST: Laws/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLawBtn([Bind(Include = "LawId,LawName")] Law law)
        {
            if (ModelState.IsValid)
            {
                db.Laws.Add(law);
                db.SaveChanges();
                return RedirectToAction("Create", "KIs");
            }

            return View("Create", "Laws");
        }

    }
}

