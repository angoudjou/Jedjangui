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
        [Display(Name = "ID", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public long CODEREMBOURSEMENT { get; set; }

        public long CODEPRET { get; set; }

        public long CODESEANCE { get; set; }
        [Display(Name = "Email", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public string EMAIL { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Date", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public DateTime DATEREMBOURSEMENT { get; set; }
        [Display(Name = "Montant", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal CAPITALREMBOURSEMENT { get; set; } = 0;
        [Display(Name = "Interet", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal INTERETREMBOURSEMENT { get; set; } = 0;

        public virtual Pret PRET { get; set; }

        public virtual Seance SEANCE { get; set; }
        public virtual ICollection<MouvementFond> MOUVEMENTFOND { get; set; }
        public Remboursementpret()
        {
                
        }
    }
}