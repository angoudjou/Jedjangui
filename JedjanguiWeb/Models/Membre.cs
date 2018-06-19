using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public class Membre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public long CODEMEMBRE { get; set; }
        //public long? MEM_CODEMEMBRE { get; set; }
        public long CODEASSO { get; set; }
        [Display(Name = "Nom", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string NOMMEMBRE { get; set; }

        [Display(Name = "DateAdhession", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DATEADEHSIONMEMEBRE { get; set; }

        [Display(Name = "Date", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? DATEDEMISSION { get; set; }

        [Display(Name = "DateNaissance", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? DATENAISSANCEMEMBRE { get; set; }
        [Display(Name = "Statut", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public Boolean? STATUTMEMBRE { get; set; } = true;
        [Display(Name = "Fonction", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string FONCTIONMEMBRE { get; set; }

        [Display(Name = "Telephone", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string TELMEMBRE { get; set; }

        [Display(Name = "Residence", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string RESIDENCEMEMEBRE { get; set; }

        [Display(Name = "Addresse", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string ADRESSEMEMEBRE { get; set; }

        [Display(Name = "Sexe", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string SEXEMEMBRE { get; set; }

        [Display(Name = "StatutMatrimoniale", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string STATUTMATRIMONIALE { get; set; }

        [Display(Name = "Email", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string EMAILMEMBRE { get; set; }
        [Display(Name = "NbEnfant", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public long? NOMBREENFANT { get; set; }
        [Display(Name = "Note", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public string NOTEMEMBRE { get; set; }
        [Display(Name = "Titre", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public string TITREMEMBRE { get; set; }
        public string TYPEMEMBRE { get; set; }
        [Display(Name = "Eloge", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string ELOGE { get; set; }
        [Display(Name = "Matricule", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string MATRICULE { get; set; }

        public virtual ICollection<InscrisExercice> InscrisExercices { get; set; }
       // public virtual ICollection< InscrisExercice> FondMembres { get; set; }
         

        public Association  association {get; set;}

        public Membre()
        {
            InscrisExercices = new List< InscrisExercice>();
            //FondMembres = new List<FondMembre>();
        }
    }
}