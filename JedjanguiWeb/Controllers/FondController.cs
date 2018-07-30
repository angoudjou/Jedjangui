using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JedjanguiWeb.DAL;
using JedjanguiWeb.DesignPattern;
using JedjanguiWeb.Models;
using PagedList;

namespace JedjanguiWeb.Controllers
{

    [Authorize]
    public class FondController : Controller
    {
        private JeDjanguiContext db = new JeDjanguiContext();
        int codeasso=0;
        

        // GET: Fond
        public ActionResult Index(int page=1)
        {
            if (Session["CODEASSO"] != null)
                codeasso = int.Parse(Session["CODEASSO"].ToString());

            var fonds = db.Fonds.Where(c => c.CODEASSO.Equals(codeasso));
                //.Include(f => f.ASSOCIATION);

            return View(fonds.OrderBy(u=>u.NOMFOND).ToPagedList(page, Singleton.pageSize));
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
           // var type_fond = (from elt in Enum.GetValues(typeof(typefond)).Cast<typefond>().Select(v=>v.ToString()) select new { value = elt}).ToList();
           var  type_fond = (from elt in Enum.GetValues(typeof( Singleton.typefond)).Cast<Singleton.typefond>() select new { value = elt.ToString() }).ToList();
         ViewBag.typefond = new  SelectList(type_fond, "value","value");

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
                fond.CODEASSO = int.Parse(Session["CODEASSO"].ToString());
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
            var type_fond = (from elt in Enum.GetValues(typeof(Singleton.typefond)).Cast<Singleton.typefond>() select new { value = elt.ToString() }).ToList();
            ViewBag.typefond = new SelectList(type_fond, "value", "value",fond.TYPEFOND);

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
        //lis of members of this found
        public ActionResult Incris(int codefond)
        {
          int   codeasso = int.Parse(Session["CODEEXO"].ToString());

         return View(db.FondMembres.Where(d => d.INSCRISEXERCICE.CODEEXO == codeasso && d.CODEFOND == codefond));

        }
        public ActionResult balance(int? codeexo)
        {
            if(codeasso == null)
            {
                codeasso = int.Parse(Session["CODEEXO"].ToString());
            }
            //List<FondMembre> balance = db.FondMembres.AsNoTracking().Where(c => c.INSCRISEXERCICE.CODEEXO == codeasso).ToList();
            var balance = (from elt in db.FondMembres.AsNoTracking().Where(c => c.INSCRISEXERCICE.CODEEXO == codeasso)
                           select new
                           {
                               elt.FOND.NOMFOND,
                                   elt.CODEFOND,
                                   DEBIT = db.FondMembres.Where(h => h.CODEFOND == elt.CODEFOND).Sum(s => s.DEBITFONDMEMBRE),
                                   CREDIT = db.FondMembres.Where(h => h.CODEFOND == elt.CODEFOND).Sum(s => s.CREDITFONDMEMBRE),
                                  
                               }).ToList();

            List < SoldeFond> Situation = new List<SoldeFond>();
            SoldeFond f;
            balance.ForEach(
                s=> {
                    f = new SoldeFond();
                    f.CODEFOND = s.CODEFOND;
                    f.NOMFOND = s.NOMFOND;
                    f.CODEEXERCICE = codeexo;
                    f.DEBITSOLDEFOND = s.DEBIT;
                    f.CREDITSODLEFOND = s.CREDIT;
                    f.SOLDESOLDEFOND = s.DEBIT - s.CREDIT;

                    Situation.Add(f);
                });
               

           
                     
            return View(Situation);
        }
        [HttpGet]
        public ActionResult InscrireMembre()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IncrireMembre(FondMembre fm)
        {

            return View("inscirs");
        }

    }
}
