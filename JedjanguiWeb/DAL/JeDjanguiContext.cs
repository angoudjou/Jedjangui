using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JedjanguiWeb.DAL
{
    public class JeDjanguiContext: DbContext
    {

        public JeDjanguiContext() : base()
        {


        }

        public DbSet<Models.Association> Associations { get; set; }

        public DbSet<Models.Membre> Membres { get; set; }

        public DbSet<Models.Fond> Fonds { get; set; }
    }
}