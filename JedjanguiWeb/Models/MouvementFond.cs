using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public class MouvementFond
    {
        [Key]
        public long CODEMVT { get; set; }

        public long CODEFONDSEANCE { get; set; }
        public long? CODEFONDMEMBRE { get; set; }

        public long? CODEPRET { get; set; }
        public long? CODEREMBOURSEMENT { get; set; }
        public decimal? MONTANTCOTISATIONMVT { get; set; }
        public decimal? INTERETMVT { get; set; }
        public decimal? MONTANTCOTISATIONAVANTMVT { get; set; }
        public decimal? INTERETSEANCEAVANT { get; set; }
        public decimal? CREDITMVT { get; set; }
        public decimal? DEBITMVT { get; set; }
        public string MOTIFMVT { get; set; }

        public virtual FondSeance FONDSEANCE { get; set; }
        public virtual FondMembre FONDEMEMBRE { get; set; }
        public virtual Remboursementpret REMBOURSEMENTPRET { get; set; }

        public MouvementFond()
        {
        }
    }
}