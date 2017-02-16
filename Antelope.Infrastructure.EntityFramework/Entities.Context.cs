﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Antelope.Infrastructure.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    // Ajout manuel dans le fichier TT.
    using Antelope.Domain.Models;
    
    public partial class AntelopeEntities : DbContext
    {
        public AntelopeEntities()
            : base("name=AntelopeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActionQSE> ActionQSEs { get; set; }
        public virtual DbSet<ActionSecurite> ActionSecurites { get; set; }
        public virtual DbSet<ADRole> ADRoles { get; set; }
        public virtual DbSet<CauseQSE> CauseQSEs { get; set; }
        public virtual DbSet<CorpsHumainZone> CorpsHumainZones { get; set; }
        public virtual DbSet<Danger> Dangers { get; set; }
        public virtual DbSet<FicheSecurite> FicheSecurites { get; set; }
        public virtual DbSet<FicheSecuriteType> FicheSecuriteTypes { get; set; }
        public virtual DbSet<Intervention> Interventions { get; set; }
        public virtual DbSet<Lieu> Lieux { get; set; }
        public virtual DbSet<Personne> Personnes { get; set; }
        public virtual DbSet<PlageHoraire> PlageHoraires { get; set; }
        public virtual DbSet<PosteDeTravail> PosteDeTravails { get; set; }
        public virtual DbSet<Projet> Projets { get; set; }
        public virtual DbSet<Risque> Risques { get; set; }
        public virtual DbSet<RisqueType> RisqueTypes { get; set; }
        public virtual DbSet<Sauvegarde> Sauvegardes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }
        public virtual DbSet<ZoneType> ZoneTypes { get; set; }
        public virtual DbSet<ParametrageHSE> ParametrageHSEs { get; set; }
        public virtual DbSet<NonConformiteDomaine> NonConformiteDomaines { get; set; }
        public virtual DbSet<NonConformiteGravite> NonConformiteGravites { get; set; }
        public virtual DbSet<NonConformiteOrigine> NonConformiteOrigines { get; set; }
        public virtual DbSet<NonConformite> NonConformites { get; set; }
        public virtual DbSet<ParametrageQSE> ParametrageQSEs { get; set; }
        public virtual DbSet<ImportAction> ImportActions { get; set; }
        public virtual DbSet<ImportNonConformite> ImportNonConformites { get; set; }
        public virtual DbSet<FilePath> FilePaths { get; set; }
        public virtual DbSet<DialogueSecurite> DialogueSecurites { get; set; }
        public virtual DbSet<Thematique> Thematiques { get; set; }
    }
}