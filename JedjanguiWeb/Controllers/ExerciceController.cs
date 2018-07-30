using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JedjanguiWeb.DAL;
using JedjanguiWeb.DesignPattern;
using JedjanguiWeb.Models;

namespace JedjanguiWeb.Controllers
{
    [Authorize]
    public class ExerciceController : Controller
    {
        private JeDjanguiContext db = new JeDjanguiContext();
        private Factory factory = new Factory();

        // GET: Exercice
        public ActionResult Index()
        {
            // int codeasso = int.Parse(Session["CODE"]);
            var exercices = db.Exercices.Where(f=>f.CODEASSO == Singleton.CodeAsso);// .Include(e => e.ASSOCIATION);
            return View(exercices.ToList());
        }

        // GET: Exercice/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercice exercice = db.Exercices.Find(id);
            if (exercice == null)
            {
                return HttpNotFound();
            }
            return View(exercice);
        }

        // GET: Exercice/Create
        public ActionResult Create()
        {
            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO");
            return View();
        }

        // POST: Exercice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODEEXO,CODEASSO,DEBUTEXO,FINEXO,STATUTEXO,NOMEXO,FINSAISIE")] Exercice exercice)
        {
            int asso = int.Parse(Session["CODEASSO"].ToString());
            exercice.CODEASSO = asso;

            if (ModelState.IsValid)
            {
                db.Exercices.Add(exercice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO", exercice.CODEASSO);
            return View(exercice);
        }

        // GET: Exercice/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercice exercice = db.Exercices.Find(id);
            if (exercice == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO", exercice.CODEASSO);
            return View(exercice);
        }

        // POST: Exercice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODEEXO,CODEASSO,DEBUTEXO,FINEXO,STATUTEXO,NOMEXO,FINSAISIE")] Exercice exercice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODEASSO = new SelectList(db.Associations, "CODEASSO", "NOMASSO", exercice.CODEASSO);
            return View(exercice);
        }

        // GET: Exercice/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercice exercice = db.Exercices.Find(id);
            if (exercice == null)
            {
                return HttpNotFound();
            }
            return View(exercice);
        }

        // POST: Exercice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Exercice exercice = db.Exercices.Find(id);
            db.Exercices.Remove(exercice);
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

        public ActionResult Inscris(long? id)
        {
            //if the id is not provided we use the current exercice, else we return bad request
            if (id == null)
            {
              
                if(Session["CODEEXO"] != null)
                    id = int.Parse(Session["CODEEXO"].ToString());
                else
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            

            List<InscrisExercice> inscirs = db.Inscrisexercices.Where(t => t.CODEEXO == id).ToList(); ;
            return View(inscirs);
         

        }



        public ActionResult Ouvrir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Exercice exercice = db.Exercices.Find(id);
            //if (exercice == null)
            //{
            //    return HttpNotFound();
            //}
            //else
            //{
            //    Session["CODEEXO"] = exercice.CODEEXO;
            //    Int64 codexo = exercice.CODEEXO;
            //    Seance sc = db.Seances.Where(f => f.CODEEXO == codexo).OrderByDescending(t => t.CODESEANCE).FirstOrDefault();
            //    //if (sc == null )
            //    //    sc = db.Seances.Where(g => g.CODEEXO == exo.CODEEXO).OrderByDescending(t => t.CODESEANCE).FirstOrDefault();
            //    if (sc != null)
            //        Session["CODESEANCE"] = sc.CODESEANCE;
            if (factory.OuvrirExercice(id))
            {
                return RedirectToAction("Index", "Seance");
            }
            else
                return HttpNotFound();

       
          
        }
        //post action
        public ActionResult Inscrire(InscrisExercice _inscris)
        {
            if (ModelState.IsValid) 
            {
             _inscris.CODEEXO = int.Parse(Session["CODEEXO"].ToString());
               
                db.Inscrisexercices .Add(_inscris);
              
                db.SaveChanges();
                return RedirectToAction("Inscris");
            }
                return RedirectToAction("Inscris");
        }

        //form 
        public ActionResult InscrireMembre()
        {
            int asso = int.Parse(Session["CODEASSO"].ToString());
            int exo = int.Parse(Session["CODEEXO"].ToString());
            //llist of registers memebres
            List<Int64> registered = (from elt in db.Inscrisexercices.Where(d => d.CODEEXO == exo) select elt.CODEMEMBRE ).ToList();

            //list of active members

            var membre = db.Membres.Where(s =>s.CODEASSO ==asso && s.STATUTMEMBRE == true && !registered.Contains(s.CODEMEMBRE) ).ToList();
          ViewBag.MEMBRE = new SelectList(membre, "CODEMEMBRE", "NOMMEMBRE","Selectionnner le membre");
           // ViewBag.MEMBRE = new SelectList(db.Membres, "CODEMEMBRE", "NOMMEMBRE", "Selectionnner le membre");

            return View();
        }


    }
}
