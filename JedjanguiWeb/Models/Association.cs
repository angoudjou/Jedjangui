using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JedjanguiWeb.Models
{
   // [Authorize]
    public class Association
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Display(Name = "ID", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public long CODEASSO { get; set; }


        [Display(Name = "Nom", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        [Required]

        public string NOMASSO { get; set; }
        [Required]
        [Display(Name = "But", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string BUTASSO { get; set; }

        public string EMAIL { get; set; }
        [Required]
        [Display(Name = "Sigle", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string SIGLEASSO { get; set; }

        [Display(Name = "Date", ResourceType =typeof(JedjanguiWeb.Resources.Model.Traduction ))]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DATECREATIONASS { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "DateAjouter", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public DateTime? DATEAJOUTER { get; set; } = DateTime.Now;
        [Display(Name = "Statut", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public Boolean STATUTASSO { get; set; } =true;
        [Display(Name = "CompteBanque", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string COMPTABANKASSO { get; set; }

        [Display(Name = "Banque", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string BANQUEASSO { get; set; }

        [Display(Name = "Slogan", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string SLOGANASSO { get; set; }

        [Display(Name = "Addresse", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public string ADDRESSEASSO { get; set; }
        public string MOTPASSEASSO { get; set; }

        [Display(Name = "LieuRencontre", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public string LIEURENCONTRE { get; set; }
        public string CODEUTILISATEUR { get; set; }

     public   virtual ICollection<Membre> Membre { get; set; }
     public virtual   List<Fond> Fond { get; set; }
     public virtual ICollection<Exercice> Exercice { get; set; }

        public Association ()
        {
         
                    
           Membre = new List<Membre>();
            Fond = new List<Fond>();
            Exercice = new List<Exercice>();

        }


    }
}