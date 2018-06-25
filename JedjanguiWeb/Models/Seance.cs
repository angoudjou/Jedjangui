using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public class Seance
    {
        [Key]
        [Display(Name = "ID", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CODESEANCE { get; set; }
        public long CODEEXO { get; set; }

        [Display(Name = "Date", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? DATESEANCE { get; set; }

        [Display(Name = "DebutExo", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        public DateTime? DEBUTSEANCE { get; set; }

        [Display(Name = "FinExo", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]

        public DateTime? FINSEANCE { get; set; }
        [Display(Name = "Statut", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public string STATUTSEANCE { get; set; } = "o";
        [Display(Name = "Nom", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string NOMSEANCE { get; set; }

        [Display(Name = "LieuRencontre", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string LIEUSEANCE { get; set; }
        public string COMPTERENDUSEANCE { get; set; }

        public virtual Exercice Exercices { get; set; }
        public ICollection<Remboursementpret> remboursementprets { get; set; }
        public ICollection<FondSeance> fondseances { get; set; }

        public Seance()
        {
            remboursementprets = new List<Remboursementpret>();
            //generation de la liste des fondseance
            fondseances = new List<FondSeance>();
        }
    }
}