namespace Antelope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _04092014FirstMigration4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionQSEs",
                c => new
                    {
                        ActionQSEId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateButoireInitiale = c.DateTime(nullable: false),
                        DateButoireNouvelle = c.DateTime(nullable: false),
                        Avancement = c.String(),
                        CotationHumain = c.Short(nullable: false),
                        CotationOrganisationnel = c.Short(nullable: false),
                        CotationTechnique = c.Short(nullable: false),
                        CotationEfficacite = c.Short(nullable: false),
                        PreuveVerification = c.String(),
                        CommentaireEfficaciteVerification = c.String(),
                        Realise = c.Boolean(nullable: false),
                        RealiseDate = c.DateTime(nullable: false),
                        Verifie = c.Boolean(nullable: false),
                        VerifieDate = c.DateTime(nullable: false),
                        Cloture = c.Boolean(nullable: false),
                        ClotureDate = c.DateTime(nullable: false),
                        CauseQSEId = c.Int(nullable: false),
                        Responsable_PersonneId = c.Int(),
                        Verificateur_PersonneId = c.Int(),
                    })
                .PrimaryKey(t => t.ActionQSEId)
                .ForeignKey("dbo.CauseQSEs", t => t.CauseQSEId, cascadeDelete: true)
                .ForeignKey("dbo.Personnes", t => t.Responsable_PersonneId)
                .ForeignKey("dbo.Personnes", t => t.Verificateur_PersonneId)
                .Index(t => t.CauseQSEId)
                .Index(t => t.Responsable_PersonneId)
                .Index(t => t.Verificateur_PersonneId);
            
            CreateTable(
                "dbo.CauseQSEs",
                c => new
                    {
                        CauseQSEId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        FicheSecuriteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CauseQSEId)
                .ForeignKey("dbo.FicheSecurites", t => t.FicheSecuriteId, cascadeDelete: true)
                .Index(t => t.FicheSecuriteId);
            
            CreateTable(
                "dbo.FicheSecurites",
                c => new
                    {
                        FicheSecuriteID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Type = c.String(),
                        Age = c.String(),
                        PosteDeTravail = c.String(),
                        Service = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateEvenement = c.DateTime(nullable: false),
                        PersonnesConcernees = c.String(),
                        Description = c.String(nullable: false),
                        ActionImmediate1 = c.String(),
                        ActionImmediate2 = c.String(),
                        Temoins = c.String(),
                        CotationFrequence = c.Short(nullable: false),
                        CotationGravite = c.Short(nullable: false),
                        Risque = c.String(),
                        FicheSecuriteTypeId = c.Int(nullable: false),
                        DangerId = c.Int(nullable: false),
                        CorpsHumainZoneId = c.Int(nullable: false),
                        PlageHoraireId = c.Int(),
                        SiteId = c.Int(nullable: false),
                        ZoneId = c.Int(),
                        LieuId = c.Int(),
                        EnqueteRealisee = c.Boolean(nullable: false),
                        EnqueteDate = c.DateTime(),
                        EnqueteProtagoniste = c.String(),
                        CHSCTMembre = c.String(),
                        PersonneConcerneeId = c.Int(),
                        ResponsableId = c.Int(),
                        Personne_PersonneId = c.Int(),
                    })
                .PrimaryKey(t => t.FicheSecuriteID)
                .ForeignKey("dbo.CorpsHumainZones", t => t.CorpsHumainZoneId, cascadeDelete: true)
                .ForeignKey("dbo.Dangers", t => t.DangerId, cascadeDelete: true)
                .ForeignKey("dbo.FicheSecuriteTypes", t => t.FicheSecuriteTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Lieux", t => t.LieuId)
                .ForeignKey("dbo.Zones", t => t.ZoneId)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .ForeignKey("dbo.Personnes", t => t.Personne_PersonneId)
                .ForeignKey("dbo.Personnes", t => t.PersonneConcerneeId)
                .ForeignKey("dbo.PlageHoraires", t => t.PlageHoraireId)
                .ForeignKey("dbo.Personnes", t => t.ResponsableId)
                .Index(t => t.CorpsHumainZoneId)
                .Index(t => t.DangerId)
                .Index(t => t.FicheSecuriteTypeId)
                .Index(t => t.LieuId)
                .Index(t => t.ZoneId)
                .Index(t => t.SiteId)
                .Index(t => t.Personne_PersonneId)
                .Index(t => t.PersonneConcerneeId)
                .Index(t => t.PlageHoraireId)
                .Index(t => t.ResponsableId);
            
            CreateTable(
                "dbo.CorpsHumainZones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dangers",
                c => new
                    {
                        DangerID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.DangerID);
            
            CreateTable(
                "dbo.FicheSecuriteTypes",
                c => new
                    {
                        FicheSecuriteTypeID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.FicheSecuriteTypeID);
            
            CreateTable(
                "dbo.Lieux",
                c => new
                    {
                        LieuID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        ZoneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LieuID)
                .ForeignKey("dbo.Zones", t => t.ZoneId, cascadeDelete: true)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        ZoneID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        SiteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZoneID)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        SiteID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Trigramme = c.String(),
                        Arouperr = c.String(),
                    })
                .PrimaryKey(t => t.SiteID);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        PersonneId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        GUID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PersonneId);
            
            CreateTable(
                "dbo.PlageHoraires",
                c => new
                    {
                        PlageHoraireID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.PlageHoraireID);
            
            CreateTable(
                "dbo.ActionSecurites",
                c => new
                    {
                        ActionSecuriteId = c.Int(nullable: false, identity: true),
                        FicheSecuriteId = c.Int(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        FaitPar = c.String(),
                    })
                .PrimaryKey(t => t.ActionSecuriteId)
                .ForeignKey("dbo.FicheSecurites", t => t.FicheSecuriteId, cascadeDelete: true)
                .Index(t => t.FicheSecuriteId);
            
            CreateTable(
                "dbo.ADRoles",
                c => new
                    {
                        ADRoleID = c.Int(nullable: false, identity: true),
                        RoleCode = c.String(),
                        RoleType = c.String(),
                        Name = c.String(),
                        GUID = c.String(),
                    })
                .PrimaryKey(t => t.ADRoleID);
            
            CreateTable(
                "dbo.Interventions",
                c => new
                    {
                        InterventionID = c.Int(nullable: false, identity: true),
                        Intervenant = c.String(),
                        DateIntervention = c.String(),
                        Planifie = c.Boolean(nullable: false),
                        Demandeur = c.String(),
                        Motif = c.String(),
                        DureeIntervention = c.Int(nullable: false),
                        NoteFrais = c.Boolean(nullable: false),
                        PrimeIntervention = c.Single(nullable: false),
                        PrimeDimanche = c.Single(nullable: false),
                        Valide = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InterventionID);
            
            CreateTable(
                "dbo.Projets",
                c => new
                    {
                        ProjetID = c.Int(nullable: false, identity: true),
                        NomProjet = c.String(),
                        StatutCouleur = c.Int(nullable: false),
                        StatutVisage = c.Int(nullable: false),
                        Commentaire = c.String(),
                        ProchaineEtape = c.String(),
                        DateOuverture = c.String(),
                        DateCloture = c.String(),
                        Service = c.String(),
                    })
                .PrimaryKey(t => t.ProjetID);
            
            CreateTable(
                "dbo.Sauvegardes",
                c => new
                    {
                        SauvegardeID = c.Int(nullable: false, identity: true),
                        Site = c.String(),
                        Date = c.Double(nullable: false),
                        Volume = c.Single(nullable: false),
                        Taux = c.Single(nullable: false),
                        Duree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SauvegardeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActionSecurites", "FicheSecuriteId", "dbo.FicheSecurites");
            DropForeignKey("dbo.ActionQSEs", "Verificateur_PersonneId", "dbo.Personnes");
            DropForeignKey("dbo.ActionQSEs", "Responsable_PersonneId", "dbo.Personnes");
            DropForeignKey("dbo.FicheSecurites", "ResponsableId", "dbo.Personnes");
            DropForeignKey("dbo.FicheSecurites", "PlageHoraireId", "dbo.PlageHoraires");
            DropForeignKey("dbo.FicheSecurites", "PersonneConcerneeId", "dbo.Personnes");
            DropForeignKey("dbo.FicheSecurites", "Personne_PersonneId", "dbo.Personnes");
            DropForeignKey("dbo.Lieux", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.Zones", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.FicheSecurites", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.FicheSecurites", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.FicheSecurites", "LieuId", "dbo.Lieux");
            DropForeignKey("dbo.FicheSecurites", "FicheSecuriteTypeId", "dbo.FicheSecuriteTypes");
            DropForeignKey("dbo.FicheSecurites", "DangerId", "dbo.Dangers");
            DropForeignKey("dbo.FicheSecurites", "CorpsHumainZoneId", "dbo.CorpsHumainZones");
            DropForeignKey("dbo.CauseQSEs", "FicheSecuriteId", "dbo.FicheSecurites");
            DropForeignKey("dbo.ActionQSEs", "CauseQSEId", "dbo.CauseQSEs");
            DropIndex("dbo.ActionSecurites", new[] { "FicheSecuriteId" });
            DropIndex("dbo.ActionQSEs", new[] { "Verificateur_PersonneId" });
            DropIndex("dbo.ActionQSEs", new[] { "Responsable_PersonneId" });
            DropIndex("dbo.FicheSecurites", new[] { "ResponsableId" });
            DropIndex("dbo.FicheSecurites", new[] { "PlageHoraireId" });
            DropIndex("dbo.FicheSecurites", new[] { "PersonneConcerneeId" });
            DropIndex("dbo.FicheSecurites", new[] { "Personne_PersonneId" });
            DropIndex("dbo.Lieux", new[] { "ZoneId" });
            DropIndex("dbo.Zones", new[] { "SiteId" });
            DropIndex("dbo.FicheSecurites", new[] { "SiteId" });
            DropIndex("dbo.FicheSecurites", new[] { "ZoneId" });
            DropIndex("dbo.FicheSecurites", new[] { "LieuId" });
            DropIndex("dbo.FicheSecurites", new[] { "FicheSecuriteTypeId" });
            DropIndex("dbo.FicheSecurites", new[] { "DangerId" });
            DropIndex("dbo.FicheSecurites", new[] { "CorpsHumainZoneId" });
            DropIndex("dbo.CauseQSEs", new[] { "FicheSecuriteId" });
            DropIndex("dbo.ActionQSEs", new[] { "CauseQSEId" });
            DropTable("dbo.Sauvegardes");
            DropTable("dbo.Projets");
            DropTable("dbo.Interventions");
            DropTable("dbo.ADRoles");
            DropTable("dbo.ActionSecurites");
            DropTable("dbo.PlageHoraires");
            DropTable("dbo.Personnes");
            DropTable("dbo.Sites");
            DropTable("dbo.Zones");
            DropTable("dbo.Lieux");
            DropTable("dbo.FicheSecuriteTypes");
            DropTable("dbo.Dangers");
            DropTable("dbo.CorpsHumainZones");
            DropTable("dbo.FicheSecurites");
            DropTable("dbo.CauseQSEs");
            DropTable("dbo.ActionQSEs");
        }
    }
}
