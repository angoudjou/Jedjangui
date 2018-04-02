using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public class InscrisExercice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CODEINSCRIPTION { get; set; }
        public long CODEMEMBRE { get; set; }
        public long CODEEXO { get; set; }
        public string POSTEMEMBREEXO { get; set; }
        public DateTime DATEINSCRIPTION { get; set; } = DateTime.Now;

        public virtual Exercice EXERCICE { get; set; }
        public virtual Membre MEMBRE { get; set; }

        public InscrisExercice()
        {
                
        }
    }
}