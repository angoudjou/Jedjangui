using JedjanguiWeb.DAL;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JedjanguiWeb.DAL;
using JedjanguiWeb.Models;
using System.Net;
using System.Data.Entity;

namespace JedjanguiWeb.Controllers
{
    public class PretController : Controller
    {
       

        private JeDjanguiContext db = new JeDjanguiContext();
        int pageSize;
        int codeasso=0;
        // GET: Pret
        public ActionResult Index(int page = 1, string SearchString = "")
        {
            if (Session["CODEASSO"] != null)
                codeasso = int.Parse(Session["CODEASSO"].ToString());

            pageSize = int.Parse(Session["PageSize"].ToString());
            // = db.Membres.Include(m => m.association);
            List<Pret> prets = new List<Pret>() ;// = db.Prets.Where(f=>f.CODEASSO == codeasso).OrderBy(h => h.NOMMEMBRE).ToList();

            // membres = membres.Where(g => g.CODEASSO.Equals(codeasso));

            if (codeasso != null)
                prets = db.Prets.Where(g => g.CODEASSO.Equals(codeasso)).ToList();

            if (!string.IsNullOrEmpty(SearchString))
                prets = prets.Where(f => f.MEMBRE.NOMMEMBRE.Contains(SearchString)).ToList();

            ViewBag.SearchString = SearchString;
            return View(prets.ToPagedList(page, pageSize));


        }

        [HttpGet]
        public ActionResult Create()
        {
            if( codeasso == 0 || codeasso == null)
            {
                if (Session["CODEASSO"] != null)
                {
                    codeasso = int.Parse(Session["CODEASSO"].ToString());
                   
                }
                  
                else return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           IEnumerable<Membre> membres = db.Membres.Where(d => d.CODEASSO == codeasso).ToList();
           IEnumerable <Fond> fonds = db.Fonds.Where(f => f.CODEASSO == codeasso);

            ViewBag.CODEMEMBRE  = new SelectList(membres, "CODEMEMBRE", "NOMMEMBRE");
            ViewBag.CODEFOND = new SelectList(fonds, "CODEFOND", "NOMFOND");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Pret pret)
        {
            if(pret!= null)
            {
                if (Session["CODEASSO"] != null)
                {
                    codeasso = int.Parse(Session["CODEASSO"].ToString());

                pret.CODEASSO = codeasso;
                    pret.EMAIL = Session["Email"].ToString();
                    pret.MONTANTAREMBOURSER = pret.MONTANTPRET + pret.INTERETPRET;
                db.Prets.Add(pret);
                db.SaveChanges();
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);



            }
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null) return new  HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Pret p = db.Prets.Find(id);
            
            IEnumerable<Membre> membres = db.Membres.Where(d => d.CODEASSO == p.CODEASSO).ToList();
            IEnumerable<Fond> fonds = db.Fonds.Where(f => f.CODEASSO == p.CODEASSO);

            ViewBag.CODEMEMBRE = new SelectList(membres, "CODEMEMBRE", "NOMMEMBRE", p.CODEMEMBRE);
            ViewBag.CODEFOND = new SelectList(fonds, "CODEFOND", "NOMFOND", p.CODEMEMBRE);


            return View(p);

        }
        [HttpPost]
        public ActionResult Edit(Pret pt)
        {

            Pret p = db.Prets.Find(pt.CODEPRET);
            p.CODEFOND = pt.CODEFOND;
            p.CODEMEMBRE = pt.CODEMEMBRE;
            p.DATEDEBUTPRET = pt.DATEDEBUTPRET;
            p.DATEFINPRET = pt.DATEFINPRET;
            p.DATEMISEENPLACE = pt.DATEMISEENPLACE;
            p.INTERETPRET = pt.INTERETPRET;
            p.MONTANTPRET = pt.MONTANTPRET;

            p.MONTANTAREMBOURSER = p.MONTANTPRET + p.INTERETPRET;

           // db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction ("Index");
        }
    }
}