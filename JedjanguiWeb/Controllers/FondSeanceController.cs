using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JedjanguiWeb.DAL;
using JedjanguiWeb.Models;

namespace JedjanguiWeb.Controllers
{
    public class FondSeanceController : Controller
    {
        private JeDjanguiContext db = new JeDjanguiContext();

        // GET: FondSeance
        public ActionResult Index()
        {
            int? codeseance = null;
            if (Session["CODESEANCE"] != null)
                codeseance = int.Parse(Session["CODESEANCE"].ToString());

            var fondSeances = db.FondSeances.Where(j => j.CODESEANCE == codeseance);
            //            .Include(f => f.FOND).Include(f => f.SEANCEREUNION);
            return View(fondSeances.ToList());
        }

        // GET: FondSeance/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FondSeance fondSeance = db.FondSeances.Find(id);
            if (fondSeance == null)
            {
                return HttpNotFound();
            }
            return View(fondSeance);
        }

        // GET: FondSeance/Create
        public ActionResult Create()
        {
            ViewBag.CODEFOND = new SelectList(db.Fonds, "CODEFOND", "NOMFOND");
            ViewBag.CODESEANCE = new SelectList(db.Seances, "CODESEANCE", "STATUTSEANCE");
            return View();
        }

        // POST: FondSeance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODEFONDSEANCE,CODEFOND,CODESEANCE,MONTANTCOTISATION,INTERETSEANCE,MONTANTCOTISATIONAVANT,INTERETSEANCEAVANT,CREDITFONDSEANCE,DEBITFONDSEANCE")] FondSeance fondSeance)
        {
            if (ModelState.IsValid)
            {
                db.FondSeances.Add(fondSeance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CODEFOND = new SelectList(db.Fonds, "CODEFOND", "NOMFOND", fondSeance.CODEFOND);
            ViewBag.CODESEANCE = new SelectList(db.Seances, "CODESEANCE", "STATUTSEANCE", fondSeance.CODESEANCE);
            return View(fondSeance);
        }

        // GET: FondSeance/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FondSeance fondSeance = db.FondSeances.Find(id);
            if (fondSeance == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODEFOND = new SelectList(db.Fonds, "CODEFOND", "NOMFOND", fondSeance.CODEFOND);
            ViewBag.CODESEANCE = new SelectList(db.Seances, "CODESEANCE", "STATUTSEANCE", fondSeance.CODESEANCE);
            return View(fondSeance);
        }

        // POST: FondSeance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODEFONDSEANCE,CODEFOND,CODESEANCE,MONTANTCOTISATION,INTERETSEANCE,MONTANTCOTISATIONAVANT,INTERETSEANCEAVANT,CREDITFONDSEANCE,DEBITFONDSEANCE")] FondSeance fondSeance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fondSeance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODEFOND = new SelectList(db.Fonds, "CODEFOND", "NOMFOND", fondSeance.CODEFOND);
            ViewBag.CODESEANCE = new SelectList(db.Seances, "CODESEANCE", "STATUTSEANCE", fondSeance.CODESEANCE);
            return View(fondSeance);
        }

        // GET: FondSeance/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FondSeance fondSeance = db.FondSeances.Find(id);
            if (fondSeance == null)
            {
                return HttpNotFound();
            }
            return View(fondSeance);
        }

        // POST: FondSeance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FondSeance fondSeance = db.FondSeances.Find(id);
            db.FondSeances.Remove(fondSeance);
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
