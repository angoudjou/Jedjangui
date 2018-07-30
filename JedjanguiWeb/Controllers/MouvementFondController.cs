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
    [Authorize]
    public class MouvementFondController : Controller
    {
        private JeDjanguiContext db = new JeDjanguiContext();

        // GET: MouvementFond
        public ActionResult Index(long? codefondseance)
        {
            var mouvementFonds = db.MouvementFonds.Include(m => m.FONDEMEMBRE).Include(m => m.FONDSEANCE).Include(m => m.REMBOURSEMENTPRET);
          
            if(codefondseance != null)
            {
                mouvementFonds = mouvementFonds.Where(d => d.CODEFONDSEANCE == codefondseance);
            }
            // when id == null c,est tout le brouillard des mouvement qu,on affiche
             return View(mouvementFonds.ToList());
        }

        // GET: MouvementFond/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MouvementFond mouvementFond = db.MouvementFonds.Find(id);
            if (mouvementFond == null)
            {
                return HttpNotFound();
            }
            return View(mouvementFond);
        }

        // GET: MouvementFond/Create
        public ActionResult Create()
        {
            ViewBag.CODEFONDMEMBRE = new SelectList(db.FondMembres, "CODEFONDMEMBRE", "CODEFONDMEMBRE");
            ViewBag.CODEFONDSEANCE = new SelectList(db.FondSeances, "CODEFONDSEANCE", "CODEFONDSEANCE");
            ViewBag.CODEREMBOURSEMENT = new SelectList(db.Remboursementprets, "CODEREMBOURSEMENT", "EMAIL");
            return View();
        }

        // POST: MouvementFond/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODEMVT,CODEFONDSEANCE,CODEFONDMEMBRE,CODEPRET,CODEREMBOURSEMENT,MONTANTCOTISATIONMVT,INTERETMVT,MONTANTCOTISATIONAVANTMVT,INTERETSEANCEAVANT,CREDITMVT,DEBITMVT,MOTIFMVT")] MouvementFond mouvementFond)
        {
            if (ModelState.IsValid)
            {
                db.MouvementFonds.Add(mouvementFond);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CODEFONDMEMBRE = new SelectList(db.FondMembres, "CODEFONDMEMBRE", "CODEFONDMEMBRE", mouvementFond.CODEFONDMEMBRE);
            ViewBag.CODEFONDSEANCE = new SelectList(db.FondSeances, "CODEFONDSEANCE", "CODEFONDSEANCE", mouvementFond.CODEFONDSEANCE);
            ViewBag.CODEREMBOURSEMENT = new SelectList(db.Remboursementprets, "CODEREMBOURSEMENT", "EMAIL", mouvementFond.CODEREMBOURSEMENT);
            return View(mouvementFond);
        }

        // GET: MouvementFond/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MouvementFond mouvementFond = db.MouvementFonds.Find(id);
            if (mouvementFond == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODEFONDMEMBRE = new SelectList(db.FondMembres, "CODEFONDMEMBRE", "CODEFONDMEMBRE", mouvementFond.CODEFONDMEMBRE);
            ViewBag.CODEFONDSEANCE = new SelectList(db.FondSeances, "CODEFONDSEANCE", "CODEFONDSEANCE", mouvementFond.CODEFONDSEANCE);
            ViewBag.CODEREMBOURSEMENT = new SelectList(db.Remboursementprets, "CODEREMBOURSEMENT", "EMAIL", mouvementFond.CODEREMBOURSEMENT);
            return View(mouvementFond);
        }

        // POST: MouvementFond/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODEMVT,CODEFONDSEANCE,CODEFONDMEMBRE,CODEPRET,CODEREMBOURSEMENT,MONTANTCOTISATIONMVT,INTERETMVT,MONTANTCOTISATIONAVANTMVT,INTERETSEANCEAVANT,CREDITMVT,DEBITMVT,MOTIFMVT")] MouvementFond mouvementFond)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mouvementFond).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODEFONDMEMBRE = new SelectList(db.FondMembres, "CODEFONDMEMBRE", "CODEFONDMEMBRE", mouvementFond.CODEFONDMEMBRE);
            ViewBag.CODEFONDSEANCE = new SelectList(db.FondSeances, "CODEFONDSEANCE", "CODEFONDSEANCE", mouvementFond.CODEFONDSEANCE);
            ViewBag.CODEREMBOURSEMENT = new SelectList(db.Remboursementprets, "CODEREMBOURSEMENT", "EMAIL", mouvementFond.CODEREMBOURSEMENT);
            return View(mouvementFond);
        }

        // GET: MouvementFond/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MouvementFond mouvementFond = db.MouvementFonds.Find(id);
            if (mouvementFond == null)
            {
                return HttpNotFound();
            }
            return View(mouvementFond);
        }

        // POST: MouvementFond/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MouvementFond mouvementFond = db.MouvementFonds.Find(id);
            db.MouvementFonds.Remove(mouvementFond);
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
