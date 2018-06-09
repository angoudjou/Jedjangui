using JedjanguiWeb.DAL;
using JedjanguiWeb.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JedjanguiWeb.DesignPattern
{
    public  class Factory 
    {
        private   JeDjanguiContext db = new JeDjanguiContext();
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
            HttpContext.Current. Session["CODEASSO"] = asso.CODEASSO;// id.ToString();
            HttpContext.Current.Session["NOMASSO"] = id + " - "+ asso.SIGLEASSO + "- " +asso.NOMASSO;
            HttpContext.Current.Session["ASSOCIATION"] = asso;
            Singleton.CodeAsso = id;

            //exercices, we take the last if the 
               Exercice exo = db.Exercices.Where(g => g.CODEASSO == id ).OrderByDescending(h => h.CODEEXO).FirstOrDefault();
            if (exo != null)
            {
             return   OuvrirExercice(exo.CODEEXO);
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
        public   void CalculerInteretFond( int id)
        {

        }

    }
}