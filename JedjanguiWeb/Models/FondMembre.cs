using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public class FondMembre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CODEFONDMEMEBRE { get; set; }
        public long CODEMEMBRE { get; set; }
        public long CODEFOND { get; set; }
        public long CODEEXO { get; set; }

        public ICollection< Membre> membre { get; set; }
        public virtual ICollection< Fond> fond { get; set; }
        public virtual ICollection<Exercice> Exercice { get; set; }
        public FondMembre()
        {

        }
    }
}