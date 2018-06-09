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
    public class SeanceController : Controller
    {
        private JeDjanguiContext db = new JeDjanguiContext();
        long codeexo = 0;
        // GET: Seance
        public ActionResult Index()
        {
            if (Session["CODEEXO"] != null)
            {
                codeexo = int.Parse(Session["CODEEXO"].ToString());
                var seances = db.Seances.Where(s => s.CODEEXO.Equals(codeexo));
                return View(seances.ToList());
            }
            else return RedirectToAction("Create", "Exercice");
          
        }

        // GET: Seance/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = db.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        // GET: Seance/Create
        public ActionResult Create()
        {
            ViewBag.CODEEXO = new SelectList(db.Exercices, "CODEEXO", "CODEEXO");
            return View();
        }

        // POST: Seance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODESEANCE,DATESEANCE,DEBUTSEANCE,FINSEANCE,STATUTSEANCE,NOMSEANCE,LIEUSEANCE,COMPTERENDUSEANCE")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                seance.CODEEXO = int.Parse(Session["CODEEXO"].ToString());
            
                    db.Seances.Add(seance);
                // list of its fonds
                FondSeance fs = new FondSeance();
                List<FondSeance> lfs = new List<FondSeance>();
                int codeasso =int.Parse( Session["CODEASSO"].ToString());
                List<Fond> lf = db.Fonds.Where(d => d.CODEASSO == codeasso).AsNoTracking().ToList();
                lf.ForEach(
                    g =>
                    {
                        fs = new FondSeance();
                        fs.CODEFOND = g.CODEFOND;
                        fs.CODESEANCE = seance.CODESEANCE;
                         // find the last fondseance
                        
                        //fill the mvt for the tontine and djangui

                        lfs.Add(fs);
                    }
                    );
                db.FondSeances.AddRange(lfs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CODEEXO = new SelectList(db.Exercices, "CODEEXO", "STATUTEXO", seance.CODEEXO);
            return View(seance);
        }

        // GET: Seance/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = db.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODEEXO = new SelectList(db.Exercices, "CODEEXO", "STATUTEXO", seance.CODEEXO);
            return View(seance);
        }

        // POST: Seance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODESEANCE,CODEEXO,DATESEANCE,DEBUTSEANCE,FINSEANCE,STATUTSEANCE,NOMSEANCE,LIEUSEANCE,COMPTERENDUSEANCE")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODEEXO = new SelectList(db.Exercices, "CODEEXO", "STATUTEXO", seance.CODEEXO);
            return View(seance);
        }

        // GET: Seance/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = db.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        // POST: Seance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Seance seance = db.Seances.Find(id);
            db.Seances.Remove(seance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //display the list of tontine of the seance

        protected   void tontine(int id)
        {
            if(id!= null)
            {
                List<Pret> prets;

            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: Seance/Ouvrir/5
        public ActionResult Ouvrir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = db.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODEEXO = new SelectList(db.Exercices, "CODEEXO", "STATUTEXO", seance.CODEEXO);
            Session["CODESEANCE" ]= seance.CODESEANCE;

            //we should return to the menu of the seance
            return RedirectToAction("Index");
        }

    }
}
