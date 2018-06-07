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
        public long CODEFONDSEANCE { get; set; }
        public long? CODEFOND { get; set; }
        //public long? CODEFONDMEMEBRE { get; set; }
        public long CODESEANCE { get; set; }
        public decimal?  MONTANTCOTISATION { get; set; }
        public decimal? INTERETSEANCE { get; set; }
        public decimal? MONTANTCOTISATIONAVANT { get; set; }
        public decimal? INTERETSEANCEAVANT { get; set; }
        public decimal? CREDITFONDSEANCE { get; set; }
        public decimal? DEBITFONDSEANCE { get; set; }

         public virtual ICollection<MouvementFond> MOUVEMENTFOND { get; set; }
        public virtual Fond FOND { get; set; }
       // public virtual FondMembre FONDMEMBRE { get; set; }
        public virtual Seance SEANCEREUNION { get; set; }

        public FondSeance()
        {
            // this.COTISATIONMEMBRE = new HashSet<COTISATIONMEMBRE>();
        }
    }
}