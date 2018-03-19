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
    public class FondController : Controller
    {
        private JeDjanguiContext db = new JeDjanguiContext();

        // GET: Fond
        public ActionResult Index()
        {
            var fonds = db.Fonds.Include(f => f.ASSOCIATION);
            return View(fonds.ToList());
        }

        // GET: Fond/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fond fond = db.Fonds.Find(id);
            if (fond == null)
            {
                return HttpNotFound();
            }
            return View(fond);
        }

        // GET: Fond/Create
        public ActionResult Create()
        {
            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO");
            return View();
        }

        // POST: Fond/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODEFOND,CODEASSO,NOMFOND,COMPTEBANQUEFOND,BANQUE,OBJECTIFFOND,OBLIGATOIRE,TYPEFOND")] Fond fond)
        {
            if (ModelState.IsValid)
            {
                db.Fonds.Add(fond);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO", fond.CODEASSO);
            return View(fond);
        }

        // GET: Fond/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fond fond = db.Fonds.Find(id);
            if (fond == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO", fond.CODEASSO);
            return View(fond);
        }

        // POST: Fond/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODEFOND,CODEASSO,NOMFOND,COMPTEBANQUEFOND,BANQUE,OBJECTIFFOND,OBLIGATOIRE,TYPEFOND")] Fond fond)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fond).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO", fond.CODEASSO);
            return View(fond);
        }

        // GET: Fond/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fond fond = db.Fonds.Find(id);
            if (fond == null)
            {
                return HttpNotFound();
            }
            return View(fond);
        }

        // POST: Fond/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Fond fond = db.Fonds.Find(id);
            db.Fonds.Remove(fond);
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
