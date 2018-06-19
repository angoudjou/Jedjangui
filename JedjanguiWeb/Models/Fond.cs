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
        [Display(Name = "Nom", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string NOMFOND { get; set; }

        [Display(Name = "CompteBanque", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public string COMPTEBANQUEFOND { get; set; }
        [Display(Name = "Banque", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public string BANQUE { get; set; }
        [Display(Name = "But", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]

        public string OBJECTIFFOND { get; set; }
        public bool? OBLIGATOIRE { get; set; } = false;

        [Display(Name = "TypeFond", ResourceType = typeof(JedjanguiWeb.Resources.Model.Traduction))]
        public string TYPEFOND { get; set; }

        public Association ASSOCIATION { get; set; }
        public virtual ICollection<FondMembre> FondMembre { get; set; }

        public Fond()
        {
            FondMembre = new List<FondMembre>();
        }
    }
}