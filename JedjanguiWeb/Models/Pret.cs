using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public partial class Pret
    {
          public Pret()
        {
         REMBOURSEMENTPRETS = new List<Remboursementpret>();
          //  this.COMITEPRET = new HashSet<COMITEPRET>();
            //this.TABLEAUAMORT = new HashSet<TABLEAUAMORT>();
        }
        [Key]
        [Display(Name = "ID", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public long CODEPRET { get; set; }
        public long CODEMEMBRE { get; set; }
        public long CODEASSO { get; set; }
        public string EMAIL { get; set; }
        public long CODEFOND { get; set; }

        [Display(Name = "Montant", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal  MONTANTPRET { get; set; }
        [Display(Name = "MontantARembourser", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal MONTANTAREMBOURSER { get; set; }
        [Display(Name = "MontantRembourser", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal MONTANTREMBOURSER { get; set; }

        [Display(Name = "Date", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime  DATEMISEENPLACE { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}")]
        [Display(Name = "Solde", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal SOLDEPRET { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "DateFin", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public DateTime DATEFINPRET { get; set; }
        [Display(Name = "Duree", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public long DUREEPRET { get; set; }
        [Display(Name = "Statut", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public string STATUTPRET { get; set; }
        [Display(Name = "Valider", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public Boolean VALIDERPRET { get; set; } = false;
        [Display(Name = "Interet", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public decimal INTERETPRET { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "DateDebut", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public DateTime? DATEDEBUTPRET { get; set; }

        public virtual Association ASSOCIATION { get; set; }
        //public virtual ICollection<COMITEPRET> COMITEPRET { get; set; }
        public virtual Fond FOND { get; set; }
        public virtual Membre MEMBRE { get; set; }
        public virtual ICollection<Remboursementpret> REMBOURSEMENTPRETS { get; set; }
    }
}