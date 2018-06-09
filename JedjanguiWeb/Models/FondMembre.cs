using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public class FondMembre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      
        public long CODEFONDMEMBRE { get; set; } 
        public long CODEINSCRIPTIONEXERCICE { get; set; }
        public long CODEFOND  { get; set; }

        public double?  DEBITFONDMEMBRE { get; set; }  
        public double?  CREDITFONDMEMBRE { get; set; }
        public double SOLDEFONDMEMBRE { get; set; } = 0;
        public Boolean EstMembre { get; set; }

 
        public virtual InscrisExercice  INSCRISEXERCICE{ get; set; }
        public virtual Fond FOND { get; set; }
        public virtual ICollection<MouvementFond> MOUVEMENTFOND { get; set; }
        public FondMembre()
        {
           // CODEFONDMEMBRE = 0;
        }
    }
}