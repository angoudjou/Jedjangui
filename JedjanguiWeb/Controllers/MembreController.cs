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
using PagedList;

namespace JedjanguiWeb.Controllers
{
    public class MembreController : Controller
    {
        private JeDjanguiContext db = new JeDjanguiContext();
        int pageSize;
        int codeasso;
        // GET: Membre
        public ActionResult Index( int page=1, string SearchString="")
         {
            if(Session["CODEASSO"] !=null)
             codeasso  = int.Parse(Session["CODEASSO"].ToString());

            pageSize = int.Parse(Session["PageSize"].ToString());
            // = db.Membres.Include(m => m.association);
            List<Membre> membres = db.Membres.OrderBy(h => h.NOMMEMBRE).ToList();

           // membres = membres.Where(g => g.CODEASSO.Equals(codeasso));

            if (codeasso!=null)
                membres = membres.Where(g => g.CODEASSO.Equals(codeasso)).ToList();

            if (!string.IsNullOrEmpty(SearchString))
                membres = membres.Where(f => f.NOMMEMBRE.Contains(SearchString)).ToList();

            
            return View(membres.ToPagedList(page, pageSize));
           
           
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
        public ActionResult Create([Bind(Include = "NOMMEMBRE,DATEADEHSIONMEMEBRE,DATEDEMISSION,DATENAISSANCEMEMBRE,STATUTMEMBRE,FONCTIONMEMBRE,TELMEMBRE,RESIDENCEMEMEBRE,ADRESSEMEMEBRE,SEXEMEMBRE,STATUTMATRIMONIALE,EMAILMEMBRE,NOMBREENFANT,NOTEMEMBRE,TITREMEMBRE,TYPEMEMBRE,ELOGE,MATRICULE")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                membre.CODEASSO = int.Parse(Session["CODEASSO"].ToString());

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
