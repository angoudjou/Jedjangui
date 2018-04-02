﻿using System;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CODESEANCE { get; set; }
        public long CODEEXO { get; set; }
        public DateTime? DATESEANCE { get; set; }
        public DateTime? DEBUTSEANCE { get; set; }
        public DateTime? FINSEANCE { get; set; }
        public string STATUTSEANCE { get; set; } = "o";
        public string NOMSEANCE { get; set; }
        public string LIEUSEANCE { get; set; }
        public string COMPTERENDUSEANCE { get; set; }

        public virtual Exercice Exercices { get; set; }

        public Seance()
        {
                
        }
    }
}