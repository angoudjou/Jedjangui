using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public partial class FondSeance
    {

      
        [Key]
        [Display(Name = "ID", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public long CODEFONDSEANCE { get; set; }
        public long? CODEFOND { get; set; }
        //public long? CODEFONDMEMEBRE { get; set; }
        public long CODESEANCE { get; set; }
        [Display(Name = "Montant", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal?  MONTANTCOTISATION { get; set; }
        [Display(Name = "Interet", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal? INTERETSEANCE { get; set; }
        [Display(Name = "MontantAvant", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal? MONTANTCOTISATIONAVANT { get; set; }
        [Display(Name = "InteretAvant", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal? INTERETSEANCEAVANT { get; set; }
        [Display(Name = "Credit", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal? CREDITFONDSEANCE { get; set; }
        [Display(Name = "Debit", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal? DEBITFONDSEANCE { get; set; }

         public virtual ICollection<MouvementFond> MOUVEMENTFOND { get; set; }
        public virtual Fond FOND { get; set; }
       // public virtual FondMembre FONDMEMBRE { get; set; }
        public virtual Seance SEANCEREUNION { get; set; }

        public FondSeance()
        {
            MOUVEMENTFOND = new List<MouvementFond>();            // this.COTISATIONMEMBRE = new HashSet<COTISATIONMEMBRE>();
        }
    }
}