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
    public class MembreController : Controller
    {
        private JeDjanguiContext db = new JeDjanguiContext();

        // GET: Membre
        public ActionResult Index()
        {
            var membres = db.Membres.Include(m => m.association);
            return View(membres.ToList());
        }

        // GET: Membre/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = db.Membres.Find(id);
            if (membre == null)
            {
                return HttpNotFound();
            }
            return View(membre);
        }

        // GET: Membre/Create
        public ActionResult Create()
        {
            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO");
            return View();
        }

        // POST: Membre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODEMEMBRE,MEM_CODEMEMBRE,CODEASSO,NOMMEMBRE,DATEADEHSIONMEMEBRE,DATEDEMISSION,DATENAISSANCEMEMBRE,STATUTMEMBRE,FONCTIONMEMBRE,TELMEMBRE,RESIDENCEMEMEBRE,ADRESSEMEMEBRE,SEXEMEMBRE,STATUTMATRIMONIALE,EMAILMEMBRE,NOMBREENFANT,NOTEMEMBRE,TITREMEMBRE,TYPEMEMBRE,ELOGE,MATRICULE")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                db.Membres.Add(membre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO", membre.CODEASSO);
            return View(membre);
        }

        // GET: Membre/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = db.Membres.Find(id);
            if (membre == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO", membre.CODEASSO);
            return View(membre);
        }

        // POST: Membre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODEMEMBRE,MEM_CODEMEMBRE,CODEASSO,NOMMEMBRE,DATEADEHSIONMEMEBRE,DATEDEMISSION,DATENAISSANCEMEMBRE,STATUTMEMBRE,FONCTIONMEMBRE,TELMEMBRE,RESIDENCEMEMEBRE,ADRESSEMEMEBRE,SEXEMEMBRE,STATUTMATRIMONIALE,EMAILMEMBRE,NOMBREENFANT,NOTEMEMBRE,TITREMEMBRE,TYPEMEMBRE,ELOGE,MATRICULE")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO", membre.CODEASSO);
            return View(membre);
        }

        // GET: Membre/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membre membre = db.Membres.Find(id);
            if (membre == null)
            {
                return HttpNotFound();
            }
            return View(membre);
        }

        // POST: Membre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Membre membre = db.Membres.Find(id);
            db.Membres.Remove(membre);
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
