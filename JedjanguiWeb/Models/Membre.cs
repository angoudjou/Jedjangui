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
        public long CODEMEMBRE { get; set; }
        //public long? MEM_CODEMEMBRE { get; set; }
        public long CODEASSO { get; set; }
        public string NOMMEMBRE { get; set; }
        public DateTime? DATEADEHSIONMEMEBRE { get; set; }
        public DateTime? DATEDEMISSION { get; set; }
        public DateTime? DATENAISSANCEMEMBRE { get; set; }
        public Boolean? STATUTMEMBRE { get; set; } = true;
        public string FONCTIONMEMBRE { get; set; }
        public string TELMEMBRE { get; set; }
        public string RESIDENCEMEMEBRE { get; set; }
        public string ADRESSEMEMEBRE { get; set; }
        public string SEXEMEMBRE { get; set; }
        public string STATUTMATRIMONIALE { get; set; }
        public string EMAILMEMBRE { get; set; }
        public long? NOMBREENFANT { get; set; }
        public string NOTEMEMBRE { get; set; }
        public string TITREMEMBRE { get; set; }
        public string TYPEMEMBRE { get; set; }
        public string ELOGE { get; set; }
        public string MATRICULE { get; set; }

        public virtual ICollection<InscrisExercice> InscrisExercices { get; set; }
         

        public Association  association {get; set;}

        public Membre()
        {
            InscrisExercices = new List< InscrisExercice>();
           // FondMembres = new List<FondMembre>();
        }
    }
}