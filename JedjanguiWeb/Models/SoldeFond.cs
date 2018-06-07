using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.Models
{
    public class SoldeFond
    {

        public    int? CODEEXERCICE { get; set; }
public string CODEMEMEBRE { get; set; }
        public long CODEFOND { get; set; }
        public string NOMFOND { get; set; }
        public double? DEBITSOLDEFOND { get; set; }
        public double? CREDITSODLEFOND { get; set; }
        public double? SOLDESOLDEFOND { get; set; }

        public SoldeFond()
        {
                
        }
    }
}