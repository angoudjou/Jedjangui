using JedjanguiWeb.Models;
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
            //Configuration.LazyLoadingEnabled = true;
            //Configuration.ProxyCreationEnabled = true;
            //Configuration.AutoDetectChangesEnabled = true;
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<JeDjanguiContext, Migrations.Configuration>());
          ///  Database.SetInitializer(new  MigrateDatabaseToLatestVersion<SchoolDBContext, EF6Console.Migrations.Configuration>());


        }

        public DbSet<Association> Associations { get; set; }

        public DbSet<Membre> Membres { get; set; }

        public DbSet<Fond> Fonds { get; set; }
        public DbSet<FondMembre> FondMembres { get; set; }
        public DbSet<Exercice> Exercices { get; set; }
        public DbSet <InscrisExercice> Inscrisexercices { get; set; }

        public DbSet<Seance> Seances { get; set; }

    }
}