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
        [Display(Name = "ID", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public long CODEINSCRIPTIONEXERCICE { get; set; }
        public long CODEMEMBRE { get; set; }
        public long CODEEXO { get; set; }

        [Display(Name = "PosteExercice", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string POSTEMEMBREEXO { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DATEINSCRIPTION { get; set; } = DateTime.Now;

        public virtual Exercice EXERCICE { get; set; }
        public virtual Membre MEMBRE { get; set; }
        public  virtual List<FondMembre> FondMembres  { get; set; }

    public InscrisExercice()
        {
            FondMembres = new List<FondMembre>();
        }
    }
}