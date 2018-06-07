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
    public class AssociationController : Controller
    {
        private JeDjanguiContext db = new JeDjanguiContext();
        int PageSize= 3 ;

        // GET: Association
        public ActionResult Index(int Page=1, string  SearchString="")
        {
            ViewBag.SearchString = SearchString;
            if(Session["PageSize"]!= null)
            PageSize =int.Parse( Session["PageSize"].ToString());
            List<Association> asso = db.Associations.ToList();

            //if logged, we select the list of his associations
            if (Session["Email"] != null)
            {
                asso = asso.Where(f => f.EMAIL == Session["Email"].ToString()).ToList();
  //if his has only 1 association then we open directly
            if (asso.Count() == 1)
                  return   RedirectToAction("Ouvrir", "Association", new { id = asso.First().CODEASSO });

            }
          
            if (string.IsNullOrEmpty(SearchString))
            return View(asso.OrderBy(l=>l.NOMASSO).ToPagedList(Page ,PageSize));
            else
                return View(asso.Where(f=>f.NOMASSO.Contains(SearchString) || f.SIGLEASSO.Contains(SearchString)).OrderBy(l => l.NOMASSO).ToPagedList(Page, PageSize));

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
                Association asso = db.Associations.Find(id);
           Session["CODEASSO"] = id;
                Session["NOMASSO"] = id + " - "+ asso.SIGLEASSO + "- " +asso.NOMASSO;

                //exercices, we take the last if the 
                Exercice exo = db.Exercices.Where(g => g.CODEASSO == id && g.STATUTEXO == true).OrderByDescending(h => h.CODEEXO).FirstOrDefault();
                if(exo == null)
                    exo = db.Exercices.Where(g => g.CODEASSO == id).OrderByDescending(t=>t.CODEEXO).FirstOrDefault();
                
                //seance, we take the last seance
                if (exo != null)
                {
                    Int64 codexo = exo.CODEEXO;
                    Session["CODEEXO"] = codexo;// exo.CODEEXO;
                    Seance sc = db.Seances.Where(f=>f.CODEEXO == codexo ).OrderByDescending(t => t.CODESEANCE).FirstOrDefault();
                    //if (sc == null )
                    //    sc = db.Seances.Where(g => g.CODEEXO == exo.CODEEXO).OrderByDescending(t => t.CODESEANCE).FirstOrDefault();
                    if(sc != null)
                        Session["CODESEANCE"] = sc.CODESEANCE;
                }

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
                if (Session["Email"] != null)

                  association. EMAIL = Session["Email"].ToString();

                db.Associations.Add(association);
                db.SaveChanges();
                // defaul =t exercice and
                Exercice exo = new Exercice();
                exo.CODEASSO = association.CODEASSO;
                exo.DEBUTEXO = DateTime.Now;
                exo.FINEXO = DateTime.Now.AddYears(1);

                db.Exercices.Add(exo);
                db.SaveChanges();
                // default seance
                Seance seance = new Seance();
                seance.CODEEXO = exo.CODEEXO;
                seance.DATESEANCE = DateTime.Now;
                seance.DEBUTSEANCE = DateTime.Now;
                seance.NOMSEANCE = "Meeting 1";

                db.Seances.Add(seance);
                db.SaveChanges();

                //default fund
                Fond f = new Fond();
                f.CODEASSO = association.CODEASSO;
                f.NOMFOND = "Sanctions";
                f.OBLIGATOIRE = true;
                f.OBJECTIFFOND = "Caisse des sanctions";

                db.Fonds.Add(f);
                db.SaveChanges();


                return RedirectToAction("Ouvrir", "Association", new { id = association.CODEASSO });
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
