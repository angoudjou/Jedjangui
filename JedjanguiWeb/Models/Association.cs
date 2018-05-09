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
        public long CODEASSO { get; set; }
        [Required]
        public string NOMASSO { get; set; }
        [Required]
        public string BUTASSO { get; set; }

        public string EMAIL { get; set; }
        [Required]
        public string SIGLEASSO { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DATECREATIONASS { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DATEAJOUTER { get; set; } = DateTime.Now;
        public Boolean STATUTASSO { get; set; } =true;
        public string COMPTABANKASSO { get; set; }
        public string BANQUEASSO { get; set; }
        public string SLOGANASSO { get; set; }
        public string ADDRESSEASSO { get; set; }
        public string MOTPASSEASSO { get; set; }
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