using JedjanguiWeb.DAL;
using JedjanguiWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JedjanguiWeb.DesignPattern
{
    public class Factory
    {
        private JeDjanguiContext db = new JeDjanguiContext();
        private void init()
        {
            HttpContext.Current.Session["CODEASSO"] = null;
            HttpContext.Current.Session["NOMASSO"] = null;
            HttpContext.Current.Session["ASSOCIATION"] = null;

            HttpContext.Current.Session["EXERCICE"] = null;
            HttpContext.Current.Session["CODEEXO"] = null;

            HttpContext.Current.Session["SEANCE"] = null;
            HttpContext.Current.Session["CODESEANCE"] = null;

            Singleton.CodeAsso = 0;
            Singleton.CodeExo = 0;
            Singleton.CodeSeance = 0;
        }
        public Boolean OuvrirAssociation(long id)
        {
            init();
            Association asso = db.Associations.Find(id);
            HttpContext.Current.Session["CODEASSO"] = asso.CODEASSO;// id.ToString();
            HttpContext.Current.Session["NOMASSO"] = id + " - " + asso.SIGLEASSO + "- " + asso.NOMASSO;
            HttpContext.Current.Session["ASSOCIATION"] = asso;
            Singleton.CodeAsso = id;

            //exercices, we take the last if the 
            Exercice exo = db.Exercices.Where(g => g.CODEASSO == id).OrderByDescending(h => h.CODEEXO).FirstOrDefault();
            if (exo != null)
            {
                return OuvrirExercice(exo.CODEEXO);
            }
            else
                return false;
        }
        public Boolean OuvrirExercice(long? id)
        {
            Exercice exercice = db.Exercices.Find(id);
            HttpContext.Current.Session["EXERCICE"] = exercice;
            HttpContext.Current.Session["CODEEXO"] = exercice.CODEEXO;
            Singleton.CodeExo = exercice.CODEEXO;
            //open the last seance
            Seance sc = db.Seances.Where(f => f.CODEEXO == Singleton.CodeExo).OrderByDescending(t => t.CODESEANCE).FirstOrDefault();
            if (sc != null)
                return OuvrirSeance(sc.CODESEANCE);
            else return false;

        }
        public Boolean OuvrirSeance(long id)
        {
            Seance sc = db.Seances.Find(id);
            HttpContext.Current.Session["SEANCE"] = sc;
            HttpContext.Current.Session["CODESEANCE"] = sc.CODESEANCE;
            return true;
        }
        public void CalculerSoldeFondSeance(long codeseance)
        {
            //sauf pour les comptes de cotisation
            var fond = db.FondSeances.Where(f => f.CODESEANCE == codeseance && f.FOND.TYPEFOND.ToLower() != "cotisation");
            //mouvements de la seance
            var mouvement = db.MouvementFonds.AsNoTracking().Where(r => r.FONDSEANCE.CODESEANCE == codeseance);
            foreach (var item in fond)
            {

                item.DEBITFONDSEANCE = mouvement.Where(r => r.CODEFONDSEANCE == item.CODEFONDSEANCE).Sum(u => u.DEBITMVT);
                item.CREDITFONDSEANCE = mouvement.Where(r => r.CODEFONDSEANCE == item.CODEFONDSEANCE).Sum(u => u.CREDITMVT);
                db.SaveChanges();
            }
            db.SaveChanges();
        }
        public void CalculerInteretFondSeance(int id)
        {
            //ceci a l'interet et la cotissation de la seance
            FondSeance fondseance = db.FondSeances.Find(id);
            // Toutes les cotisations de l'exercice de ce fond
            //decimal cumul_fond =  Convert.ToDecimal(Class_variable.bd.COTISATIONMEMBRE.Where(x => x.CODEFONDSEANCE < fs.CODEFONDSEANCE && x.FONDSEANCE.CODEFOND == fs.CODEFOND && x.FONDMEMBRE.CODEEXO == Class_variable.code_exercice).Sum(c => c.CREDITCOTISATION + c.INTERETCOTISATON));
            decimal cumul_fond = db.FondSeances.AsNoTracking().Where(t => t.FOND.CODEASSO == Singleton.CodeAsso && t.CODEFONDSEANCE < id).OrderByDescending(r => r.CODEFONDSEANCE).Sum(x => x.MONTANTCOTISATION + x.INTERETSEANCE).Value;
            //Convert.ToDecimal(Class_variable.bd.COTISATIONMEMBRE.Where(x => x.CODEFONDSEANCE < fs.CODEFONDSEANCE && x.FONDSEANCE.CODEFOND == fs.CODEFOND && x.FONDMEMBRE.CODEEXO == Class_variable.code_exercice).Sum(c => c.CREDITCOTISATION + c.INTERETCOTISATON));


            FondSeance fondseance_avant = db.FondSeances.Where(t => t.FOND.CODEASSO == Singleton.CodeAsso && t.CODEFONDSEANCE < id).OrderByDescending(r => r.CODEFONDSEANCE).FirstOrDefault();

            fondseance.MONTANTCOTISATIONAVANT = cumul_fond;

            //we add the amount of the seance
            cumul_fond += fondseance.MONTANTCOTISATION.Value;
            decimal taux_interet = fondseance.INTERETSEANCE.Value / cumul_fond;

            var mvt = db.MouvementFonds.Where(f => f.CODEFONDSEANCE == id);

            if (fondseance_avant != null)
            {
                List<MouvementFond> mvt_anc = db.MouvementFonds.AsNoTracking().Where(f => f.CODEFONDSEANCE == id).ToList();
                MouvementFond item_anc;

                foreach (var item in mvt)
                {
                    //item.INTERETMVT = (fondseance.INTERETSEANCE * item.MONTANTCOTISATIONMVT) / fondseance.MONTANTCOTISATION;
                    //last mouvement 
                    item_anc = mvt_anc.Where(g => g.CODEFONDMEMBRE == item.CODEFONDMEMBRE).FirstOrDefault();

                    item.INTERETSEANCEAVANT = item_anc.INTERETMVT;
                    item.MONTANTCOTISATIONAVANTMVT = item_anc.MONTANTCOTISATIONAVANTMVT + item_anc.MONTANTCOTISATIONMVT;

                    item.INTERETMVT = (item.MONTANTCOTISATIONAVANTMVT.GetValueOrDefault() + item.MONTANTCOTISATIONMVT) * taux_interet;
                    //fondseance.INTERETSEANCE * item.MONTANTCOTISATIONMVT / fondseance.MONTANTCOTISATION;

                }


            }
            else
            {
                foreach (var item in mvt)
                {
                    item.INTERETMVT = fondseance.INTERETSEANCE * item.MONTANTCOTISATIONMVT / fondseance.MONTANTCOTISATION;
                }

            }


            db.SaveChanges();

        }
    }
}