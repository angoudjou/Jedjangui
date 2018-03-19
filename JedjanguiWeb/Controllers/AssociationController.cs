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
    public class AssociationController : Controller
    {
        private JeDjanguiContext db = new JeDjanguiContext();

        // GET: Association
        public ActionResult Index()
        {
            return View(db.Associations.ToList());
        }

        // GET: Association/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Association association = db.Associations.Find(id);
            if (association == null)
            {
                return HttpNotFound();
            }
            return View(association);
        }

        // GET: Association/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Mrque une association comme encours
        public ActionResult Ouvrir(long? id)
        {
            if(id != null)
            {
         Session["CODEASSO"] = id;
            return RedirectToAction("Index", "Membre");
            }
            else
                return HttpNotFound();

            //            return View();
        }

        // POST: Association/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODEASSO,NOMASSO,BUTASSO,SIGLEASSO,DATECREATIONASS,COMPTABANKASSO,BANQUEASSO,SLOGANASSO,ADDRESSEASSO,MOTPASSEASSO,LIEURENCONTRE")] Association association)
        {
            if (ModelState.IsValid)
            {
                db.Associations.Add(association);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(association);
        }

        // GET: Association/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Association association = db.Associations.Find(id);
            if (association == null)
            {
                return HttpNotFound();
            }
            return View(association);
        }

        // POST: Association/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODEASSO,NOMASSO,BUTASSO,SIGLEASSO,DATECREATIONASS,COMPTABANKASSO,BANQUEASSO,SLOGANASSO,ADDRESSEASSO,MOTPASSEASSO,LIEURENCONTRE")] Association association)
        {
            if (ModelState.IsValid)
            {
                db.Entry(association).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(association);
        }

        // GET: Association/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Association association = db.Associations.Find(id);
            if (association == null)
            {
                return HttpNotFound();
            }
            return View(association);
        }

        // POST: Association/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Association association = db.Associations.Find(id);
            db.Associations.Remove(association);
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
