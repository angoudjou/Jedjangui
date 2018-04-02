using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public class Exercice
    {
        [Key]
        public long CODEEXO { get; set; }
        public long? CODEASSO { get; set; }
        public DateTime? DEBUTEXO { get; set; }
        public DateTime? FINEXO { get; set; }
        public Boolean STATUTEXO { get; set; } = true;
        public string NOMEXO { get; set; }
        public DateTime? FINSAISIE { get; set; }

        public virtual Association ASSOCIATION { get; set; }
        //public virtual ICollection<FONDEXERCICE> FONDEXERCICE { get; set; }
        public virtual ICollection<FondMembre> FONDMEMBRE { get; set; }
         public virtual ICollection<InscrisExercice> InscrisExercices { get; set; }
        public virtual ICollection<Seance> SEANCE { get; set; }

        public Exercice()
        {

        }
    }
}