using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.DesignPattern
{
    public static class Singleton
    {
        public enum typefond
        {
            [Display(Description = "TypeFond1", ResourceType = typeof(Resources.Layout.Layout))]
            Gestion,
            [Display(Description = "TypeFond2", ResourceType = typeof(Resources.Layout.Layout))]
            Cotisation,


        }

        public static long CodeExo { get; set; }
        public static long CodeAsso { get; set; }
        public static long CodeSeance { get; set; }
        //public static long CodeAsso { get; set; } 
        public static int pageSize { get; set; } = 3;

    }
}