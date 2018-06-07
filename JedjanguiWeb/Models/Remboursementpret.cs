using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public class Remboursementpret
    {
   
        [Key]
            public long CODEREMBOURSEMENT { get; set; }

        public long CODEPRET { get; set; }

        public long CODESEANCE { get; set; }

        public string EMAIL { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DATEREMBOURSEMENT { get; set; }
        public decimal CAPITALREMBOURSEMENT { get; set; } = 0;
        public decimal INTERETREMBOURSEMENT { get; set; } = 0;

        public virtual Pret PRET { get; set; }

        public virtual Seance SEANCE { get; set; }
        public virtual ICollection<MouvementFond> MOUVEMENTFOND { get; set; }
        public Remboursementpret()
        {
                
        }
    }
}