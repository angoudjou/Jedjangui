using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public class Association
    {
        [Key]
        public long CODEASSO { get; set; }
        [Required]
        public string NOMASSO { get; set; }
        [Required]
        public string BUTASSO { get; set; }
        public string SIGLEASSO { get; set; }
        public DateTime? DATECREATIONASS { get; set; }
        public DateTime? DATEAJOUTER { get; set; } = DateTime.Now;
        public string STATUTASSO { get; set; } = "A";
        public string COMPTABANKASSO { get; set; }
        public string BANQUEASSO { get; set; }
        public string SLOGANASSO { get; set; }
        public string ADDRESSEASSO { get; set; }
        public string MOTPASSEASSO { get; set; }
        public string LIEURENCONTRE { get; set; }
        public string CODEUTILISATEUR { get; set; }

     public   virtual ICollection<Membre> Membres { get; set; }
     public virtual ICollection<Fond> Fonds { get; set; }
        public Association ()
        {
            Membres = new List<Membre>();
            Fonds = new List<Fond>();

        }


    }
}