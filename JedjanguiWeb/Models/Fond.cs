using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public class Fond
    {
        [Key]
        public long CODEFOND { get; set; }
        public long CODEASSO { get; set; }
        public string NOMFOND { get; set; }
        public string COMPTEBANQUEFOND { get; set; }
        public string BANQUE { get; set; }
        public string OBJECTIFFOND { get; set; }
        public bool? OBLIGATOIRE { get; set; }
        public string TYPEFOND { get; set; }

        public Association ASSOCIATION { get; set; }

        public Fond()
        {

        }
    }
}