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
        [Display(Name = "ID", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public long CODEEXO { get; set; }
        public long? CODEASSO { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}" , ApplyFormatInEditMode =true)]
        [Display(Name = "DebutExo", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public DateTime? DEBUTEXO { get; set; }

        [Display(Name = "FinExo", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        [DisplayFormat(DataFormatString = "{0:d}" , ApplyFormatInEditMode =true)]
        public DateTime? FINEXO { get; set; }
        [Display(Name = "Statut", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public Boolean STATUTEXO { get; set; } = true;
        [Display(Name = "NomExo", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public string NOMEXO { get; set; }

        [Display(Name = "FinSaisie", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        [DisplayFormat(DataFormatString = "{0:d}" , ApplyFormatInEditMode =true)]
        public DateTime? FINSAISIE { get; set; }

        public virtual Association ASSOCIATION { get; set; }
        //public virtual ICollection<FONDEXERCICE> FONDEXERCICE { get; set; }
       // public virtual ICollection<FondMembre> FONDMEMBRE { get; set; }
         public virtual ICollection<InscrisExercice> InscrisExercices { get; set; }
        public virtual ICollection<Seance> SEANCE { get; set; }

        public Exercice()
        {
            InscrisExercices = new List<InscrisExercice>();
            SEANCE = new List<Seance>();
        }
    }
}