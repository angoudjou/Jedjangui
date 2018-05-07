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
          //  this.COMITEPRET = new HashSet<COMITEPRET>();
            //this.TABLEAUAMORT = new HashSet<TABLEAUAMORT>();
        }
        [Key]
        public long CODEPRET { get; set; }
        public long CODEMEMBRE { get; set; }
        public long CODEASSO { get; set; }

        public long CODEFOND { get; set; }

        public decimal  MONTANTPRET { get; set; }
        public decimal MONTANTAREMBOURSER { get; set; }
        public decimal MONTANTREMBOURSER { get; set; }
        public DateTime  DATEMISEENPLACE { get; set; }
        public decimal SOLDEPRET { get; set; }
        public DateTime DATEFINPRET { get; set; }
        public long DUREEPRET { get; set; }
        public string STATUTPRET { get; set; }
        public decimal INTERETPRET { get; set; }
        public DateTime? DATEDEBUTPRET { get; set; }

        public virtual Association ASSOCIATION { get; set; }
        //public virtual ICollection<COMITEPRET> COMITEPRET { get; set; }
        public virtual Fond FOND { get; set; }
        public virtual Membre MEMBRE { get; set; }
        //public virtual ICollection<TABLEAUAMORT> TABLEAUAMORT { get; set; }
    }
}