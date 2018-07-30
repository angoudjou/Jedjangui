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
    public class RemboursementpretController : Controller
    {
        private JeDjanguiContext db = new JeDjanguiContext();
        int ipdpret;
        

        
        // GET: Remboursementpret
        public ActionResult Index(int? idpret, int? codeseance)
        {

            if (ipdpret == null && codeseance == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            List<Remboursementpret> lists = new List<Remboursementpret>();

                        //.Where(g => g.CODEPRET == id);

            if (idpret == null)
                lists = db.Remboursementprets.Where(g => g.CODEPRET == idpret).ToList();
if(codeseance != null)
                lists = db.Remboursementprets.Where(g => g.CODESEANCE == codeseance).ToList();





            return View(lists);


        }

        // GET: Remboursementpret/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remboursementpret remboursementpret = db.Remboursementprets.Find(id);
            if (remboursementpret == null)
            {
                return HttpNotFound();
            }
            return View(remboursementpret);
        }

        // GET: Remboursementpret/Create
        public ActionResult Create()
        {
            int codeasso;

            if (Session["CODEASSO"] != null)
                codeasso = int.Parse(Session["CODEASSO"].ToString());
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);



           // IEnumerable<Pret> CODEPRET = db.Prets.Where(t => t.CODEASSO == codeasso).ToList();
            Exercice ex = db.Exercices.FirstOrDefault(f => f.CODEASSO == codeasso);
            Int64 codeexo =int.Parse( Session["CODEEXO"].ToString());
           IEnumerable<SelectListItem> CODEPRET = (from elt in db.Prets 
                                                      where elt.CODEASSO == codeasso
                select new SelectListItem
                {

                    Text= elt.MEMBRE.NOMMEMBRE + " - " + elt.DATEMISEENPLACE.ToString(),
                    Value= elt.CODEPRET.ToString()
                }
                ).ToList();

            IEnumerable<SelectListItem> lists = (from elt in db.Seances
                                                where elt.CODEEXO == codeexo
                                                select new SelectListItem
                                                {
                                                    Text = elt.CODESEANCE.ToString() + " - " + elt.DATESEANCE.ToString(),
                                                    Value = elt.CODESEANCE.ToString()
                                                }
                                                ).ToList();
               
           //ViewBag.CODEPRET = new SelectList(CODEPRET, "CODEPRET","CODEPRET");

            ViewBag.CODEPRET = new SelectList(CODEPRET, "Value", "Text");

            ViewBag.CODESEANCE = new SelectList(lists, "Value", "Text");

             //ViewBag.CODESEANCE = new SelectList(CODESEANCE, "CODESEANCE", "CODESEANCE");
            return View();
        }

        // POST: Remboursementpret/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODEREMBOURSEMENT,CODEPRET,CODESEANCE,DATEREMBOURSEMENT,CAPITALREMBOURSEMENT,INTERETREMBOURSEMENT")] Remboursementpret remboursementpret)
        {

            if (ModelState.IsValid)
            {
                remboursementpret.EMAIL = Session["Email"].ToString();
                db.Remboursementprets.Add(remboursementpret);
                //adding as a mouvement of the seance
                MouvementFond mvt = new MouvementFond();
                mvt.CODEREMBOURSEMENT = remboursementpret.CODEREMBOURSEMENT;
                mvt.CREDITMVT = remboursementpret.CAPITALREMBOURSEMENT + remboursementpret.INTERETREMBOURSEMENT;
                mvt.INTERETMVT = remboursementpret.INTERETREMBOURSEMENT;
                mvt.MONTANTCOTISATIONMVT = remboursementpret.CAPITALREMBOURSEMENT;
                //  mvt.CODEFONDSEANCE = remboursementpret.CODESEANCE;
                //On doit chercher le codefondseance correspondant au fond 

                int? codeseance = null;
                if (Session["CODESEANCE"] != null)
                    codeseance = int.Parse(Session["CODESEANCE"].ToString());
                Pret pret = db.Prets.Find(remboursementpret.CODEPRET);

               // Int64 codefond = remboursementpret.PRET.CODEFOND;
                FondSeance fs = db.FondSeances.Where(f => f.CODEFOND == pret.CODEFOND && f.CODESEANCE == codeseance).FirstOrDefault();
                mvt.CODEFONDSEANCE = fs.CODEFONDSEANCE;
                //  mvt.CODEFONDMEMEBRE = remboursementpret.PRET.co
                db.MouvementFonds.Add(mvt);

                db.SaveChanges();
                return RedirectToAction("Index", new { idpret = remboursementpret.CODEPRET, codeseance = remboursementpret.CODESEANCE});
            }

            int codeasso;

            if (Session["CODEASSO"] != null)
                codeasso = int.Parse(Session["CODEASSO"].ToString());
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);



            IEnumerable<Pret> CODEPRET = db.Prets.Where(t => t.CODEASSO == codeasso).ToList();
            IEnumerable<Seance> CODESEANCE = db.Seances.Where(t => t.Exercices.CODEASSO == codeasso).ToList();

            ViewBag.CODEPRET = new SelectList(CODEPRET, "CODEPRET", "CODEPRET");
            ViewBag.CODESEANCE = new SelectList(CODESEANCE, "CODESEANCE", "CODESEANCE" );
            return View(remboursementpret);
        }

        // GET: Remboursementpret/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remboursementpret remboursementpret = db.Remboursementprets.Find(id);
            if (remboursementpret == null)
            {
                return HttpNotFound();
            }

            int codeasso;

            if (Session["CODEASSO"] != null)
                codeasso = int.Parse(Session["CODEASSO"].ToString());
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);



            IEnumerable<Pret> CODEPRET = db.Prets.Where(t => t.CODEASSO == codeasso).ToList();
            IEnumerable<Seance> CODESEANCE = db.Seances.Where(t => t.Exercices.CODEASSO == codeasso).ToList();

            ViewBag.CODEPRET = new SelectList(CODEPRET, "CODEPRET", "CODEPRET");
            ViewBag.CODESEANCE = new SelectList(CODESEANCE, "CODESEANCE", "CODESEANCE" );
            return View(remboursementpret);
        }

        // POST: Remboursementpret/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODEREMBOURSEMENT,CODEPRET,CODESEANCE,DATEREMBOURSEMENT,CAPITALREMBOURSEMENT,INTERETREMBOURSEEMT")] Remboursementpret remboursementpret)
        {
            if (ModelState.IsValid)
            {
                db.Entry(remboursementpret).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            int codeasso;

            if (Session["CODEASSO"] != null)
                codeasso = int.Parse(Session["CODEASSO"].ToString());
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);



            IEnumerable<Pret> CODEPRET = db.Prets.Where(t => t.CODEASSO == codeasso).ToList();
            IEnumerable<Seance> CODESEANCE = db.Seances.Where(t => t.Exercices.CODEASSO == codeasso).ToList();

            ViewBag.CODEPRET = new SelectList(CODEPRET, "CODEPRET", "EMAIL", remboursementpret.CODEPRET);
            ViewBag.CODESEANCE = new SelectList(CODEPRET, "CODESEANCE", "CODESEANCE", remboursementpret.CODESEANCE);
            return View(remboursementpret);
        }

        // GET: Remboursementpret/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Remboursementpret remboursementpret = db.Remboursementprets.Find(id);
            if (remboursementpret == null)
            {
                return HttpNotFound();
            }
            return View(remboursementpret);
        }

        // POST: Remboursementpret/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Remboursementpret remboursementpret = db.Remboursementprets.Find(id);
            db.Remboursementprets.Remove(remboursementpret);
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
