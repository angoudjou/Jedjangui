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
      
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long CODEFONDMEMEBRE { get; set; }
        public long CODEINSCRIPTIONEXERCICE { get; set; }
        public long CODEFOND  { get; set; }

        public double  DEBIT { get; set; }  
        public double  CREDIT { get; set; } 
        public double  SOLDE { get; set; } 

 
        public virtual InscrisExercice  INSCRISEXERCICE{ get; set; }
        public virtual Fond FOND { get; set; }

        public FondMembre()
        {
                
        }
    }
}