using Antelope.Models.HSE;
using Antelope.Models.Socle;
using Antelope.Models.SI.Indicateur;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Antelope.Models
{
    public class AntelopeContext : DbContext
    {

        public DbSet<FicheSecurite> FicheSecurites { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Lieu> Lieux { get; set; }
        public DbSet<ActionSecurite> ActionSecurites { get; set; }
        public DbSet<ADRole> ADRoles { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<Sauvegarde> Sauvegardes { get; set; }
        public DbSet<FicheSecuriteType> FicheSecuriteTypes { get; set; }
        public DbSet<Danger> Dangers { get; set; }
        public DbSet<PlageHoraire> PlageHoraires { get; set; }
        public DbSet<CorpsHumainZone> CorpsHumainZones { get; set; }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Cause> Causes { get; set; }

    }
}