namespace Antelope.Migrations
{
    using Antelope.Models.HSE;
    using Antelope.Models.Socle;
    using Antelope.Models.QSE;
    using Antelope.Models.SI.Indicateur;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Antelope.Models.AntelopeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Antelope.Models.AntelopeContext context)
        {


            Site siteRFS = new Site()
            {
                Nom = "Refresco",
                Trigramme = "RFS",
                Arouperr = "RFS-Batiment Administratif"
            };

            Site siteDLF = new Site()
            {
                Nom = "Delifruit",
                Trigramme = "DLF",
                Arouperr = "Site DLF"
            };

            Site siteSTA = new Site()
            {
                Nom = "Saint Alban",
                Trigramme = "STA",
                Arouperr = "Site STA"
            };

            Site siteNSG = new Site()
            {
                Nom = "Nuit Saint Georges",
                Trigramme = "NSG",
                Arouperr = "Site NSG"
            };

            Site siteLQN = new Site()
            {
                Nom = "Le Quesnois",
                Trigramme = "LQN",
                Arouperr = "Site LQN"
            };

            context.Sites.Add(siteRFS);
            context.Sites.Add(siteDLF);

            Zone ZoneRDCRFS = new Zone()
            {
                Nom = "Rez-de-chauss�e",
                Site = siteRFS
            };

            Zone ZoneEtage1RFS = new Zone()
            {
                Nom = "1er �tage",
                Site = siteRFS
            };

            Zone ZoneLigne1DLF = new Zone()
            {
                Nom = "Ligne 1",
                Site = siteDLF
            };

            Zone ZoneLigne2DLF = new Zone()
            {
                Nom = "Ligne 2",
                Site = siteDLF
            };

            context.Zones.Add(ZoneRDCRFS);
            context.Zones.Add(ZoneEtage1RFS);
            context.Zones.Add(ZoneLigne1DLF);
            context.Zones.Add(ZoneLigne2DLF);

            Lieu LieuRefectoireRFS = new Lieu()
            {
                Nom = "Refectoire",
                Zone = ZoneRDCRFS
            };

            Lieu LieuSalleServeurRFS = new Lieu()
            {
                Nom = "Salle des serveurs",
                Zone = ZoneRDCRFS
            };

            Lieu LieuBureauComptaRFS = new Lieu()
            {
                Nom = "Bureau Comptabilite",
                Zone = ZoneEtage1RFS
            };

            Lieu LieuBureauMarketingRFS = new Lieu()
            {
                Nom = "Bureau Marketing",
                Zone = ZoneEtage1RFS
            };

            Lieu LieuRemplisseuseL1DLF = new Lieu()
            {
                Nom = "Remplisseuse",
                Zone = ZoneLigne1DLF
            };

            Lieu LieuEtiqueteuseL1DLF = new Lieu()
            {
                Nom = "Etiqueteuse",
                Zone = ZoneLigne1DLF
            };

            Lieu LieuRemplisseuseL2DLF = new Lieu()
            {
                Nom = "Remplisseuse",
                Zone = ZoneLigne2DLF
            };

            Lieu LieuEtiqueteuseL2DLF = new Lieu()
            {
                Nom = "Etiqueteuse",
                Zone = ZoneLigne2DLF
            };

            context.Lieux.Add(LieuRefectoireRFS);
            context.Lieux.Add(LieuSalleServeurRFS);
            context.Lieux.Add(LieuBureauComptaRFS);
            context.Lieux.Add(LieuBureauMarketingRFS);
            context.Lieux.Add(LieuRemplisseuseL1DLF);
            context.Lieux.Add(LieuEtiqueteuseL1DLF);
            context.Lieux.Add(LieuRemplisseuseL2DLF);
            context.Lieux.Add(LieuEtiqueteuseL2DLF);

            Personne PersonneConcernee1 = new Personne()
            {
                Nom = "Dupont",
                Prenom = "Jean"
            };

            Personne PersonneConcernee2 = new Personne()
            {
                Nom = "Bodoin",
                Prenom = "Sandra"
            };

            Personne PersonneConcernee3 = new Personne()
            {
                Nom = "Bricard",
                Prenom = "Isabelle"
            };

            Personne PersonneConcernee4 = new Personne()
            {
                Nom = "Giovaneti",
                Prenom = "Carl"
            };

            context.Personnes.Add(PersonneConcernee1);
            context.Personnes.Add(PersonneConcernee2);
            context.Personnes.Add(PersonneConcernee3);
            context.Personnes.Add(PersonneConcernee4);

            Personne Responsable1 = new Personne()
            {
                Nom = "Valjean",
                Prenom = "Jean"
            };

            Personne Responsable2 = new Personne()
            {
                Nom = "Danton",
                Prenom = "Sylvie"
            };

            Personne Responsable3 = new Personne()
            {
                Nom = "Clement",
                Prenom = "Robert"
            };

            Personne Responsable4 = new Personne()
            {
                Nom = "Leloup",
                Prenom = "Sandrine"
            };

            context.Personnes.Add(Responsable1);
            context.Personnes.Add(Responsable2);
            context.Personnes.Add(Responsable3);
            context.Personnes.Add(Responsable4);

            FicheSecuriteType FicheSecuriteType1 = new FicheSecuriteType()
            {
                Nom = "ATAA"
            };

            FicheSecuriteType FicheSecuriteType2 = new FicheSecuriteType()
            {
                Nom = "ATSA"
            };

            FicheSecuriteType FicheSecuriteType3 = new FicheSecuriteType()
            {
                Nom = "Soins"
            };

            FicheSecuriteType FicheSecuriteType4 = new FicheSecuriteType()
            {
                Nom = "PA"
            };

            FicheSecuriteType FicheSecuriteType5 = new FicheSecuriteType()
            {
                Nom = "SD"
            };

            context.FicheSecuriteTypes.Add(FicheSecuriteType1);
            context.FicheSecuriteTypes.Add(FicheSecuriteType2);
            context.FicheSecuriteTypes.Add(FicheSecuriteType3);
            context.FicheSecuriteTypes.Add(FicheSecuriteType4);
            context.FicheSecuriteTypes.Add(FicheSecuriteType5);

            List<string> AllDangerNom = new List<string>() { "Air comprim�", "Appareil � pression", "Biologique", "Circulation d'engin" };

            List<Danger> AllDanger = new List<Danger>();
            
            foreach (string DangerNom in AllDangerNom)
            {
                Danger Danger = new Danger()
                {
                    Nom = DangerNom
                };

                AllDanger.Add(Danger);
            }

            List<string> AllCorpsHumainZoneNom = new List<string>() { "Yeux", "T�te", "Bras", "Main", "Tronc", "Jambe", "Pied", "Tout le corps", "Multiples l�sions", "Dos" };
            List<string> AllCorpsHumainZoneCode = new List<string>() { "YEUX", "TETE", "BRAS", "MAIN", "TRONC", "JAMBE", "PIED", "TOUTCORPS", "MULTILESIONS", "DOS" };

            List<CorpsHumainZone> AllCorpsHumainZone = new List<CorpsHumainZone>();

            for(var i = 0;i<AllCorpsHumainZoneNom.Count;i++)
            {
                CorpsHumainZone CorpsHumainZone = new CorpsHumainZone()
                {
                    Nom = AllCorpsHumainZoneNom[i],
                    Code = AllCorpsHumainZoneCode[i]
                };

                AllCorpsHumainZone.Add(CorpsHumainZone);
                context.CorpsHumainZones.Add(CorpsHumainZone);
            }



            PlageHoraire plagehoraire1 = new PlageHoraire() { Nom = "Nuit" };
            PlageHoraire plagehoraire2 = new PlageHoraire() { Nom = "Journ�e" };
            PlageHoraire plagehoraire3 = new PlageHoraire() { Nom = "Matin" };
            PlageHoraire plagehoraire4 = new PlageHoraire() { Nom = "Apr�s-Midi" };


            FicheSecurite FicheSecurite1 = new FicheSecurite()
            {
                Code = "ABCD",
                Type = "FAS",
                PosteDeTravail = "Carriste",
                Service = "Logistique",
                Responsable = Responsable1,
                Site = siteRFS,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneRDCRFS,
                Lieu = LieuSalleServeurRFS,
                PersonnesConcernees = "Jean Dupont",
                Description = "L'op�rateur a pris une charge trop lourde avec son chariot et il s'est renvers�",
                CotationFrequence = 1,
                CotationGravite = 2,
                FicheSecuriteType = FicheSecuriteType1,
                Danger = AllDanger[1],
                PlageHoraire = plagehoraire1,
                ActionImmediate1 = "Rappel � tous les caristes de ne prendre les palettes que deux par deux",
                CorpsHumainZone = AllCorpsHumainZone[1],
                PersonneConcernee = PersonneConcernee1
                
            };

            FicheSecurite FicheSecurite2 = new FicheSecurite()
            {
                Code = "EFGH",
                Type = "FAS",
                PosteDeTravail = "Bureau",
                Service = "Informatique",
                Responsable = Responsable2,
                Site = siteRFS,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneRDCRFS,
                Lieu = LieuSalleServeurRFS,
                PersonnesConcernees = "David Leloup, Cyril Clot",
                Description = "Pour ouvrir les f�ts, l'op�rateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du f�t avec laquelle il s'est coup�",
                CotationFrequence = 0,
                CotationGravite = 4,
                FicheSecuriteType = FicheSecuriteType2,
                Danger = AllDanger[2],
                PlageHoraire = plagehoraire2,
                CorpsHumainZone = AllCorpsHumainZone[2],
                PersonneConcernee = PersonneConcernee2
            };

            FicheSecurite FicheSecurite3 = new FicheSecurite()
            {
                Code = "ABCD",
                Type = "FPA",
                PosteDeTravail = "Carriste",
                Service = "Logistique",
                Responsable = Responsable3,
                Site = siteRFS,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneRDCRFS,
                Lieu = LieuSalleServeurRFS,
                PersonnesConcernees = "Jean Dupont",
                Description = "L'op�rateur a pris une charge trop lourde avec son chariot et il s'est renvers�",
                CotationFrequence = 1,
                CotationGravite = 2,
                FicheSecuriteType = FicheSecuriteType3,
                Danger = AllDanger[3],
                PlageHoraire = plagehoraire3,
                ActionImmediate1 = "Rappel � tous les caristes de ne prendre les palettes que deux par deux",
                CorpsHumainZone = AllCorpsHumainZone[3],
                PersonneConcernee = PersonneConcernee3
            };

            FicheSecurite FicheSecurite4 = new FicheSecurite()
            {
                Code = "EFGH",
                Type = "FPA",
                PosteDeTravail = "Bureau",
                Service = "Informatique",
                Responsable = Responsable4,
                Site = siteRFS,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneRDCRFS,
                Lieu = LieuSalleServeurRFS,
                PersonnesConcernees = "Jean Dupont",
                Description = "Pour ouvrir les f�ts, l'op�rateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du f�t avec laquelle il s'est coup�",
                CotationFrequence = 0,
                CotationGravite = 4,
                FicheSecuriteType = FicheSecuriteType4,
                Danger = AllDanger[3],
                PlageHoraire = plagehoraire4,
                CorpsHumainZone = AllCorpsHumainZone[4],
                PersonneConcernee = PersonneConcernee4
            };


            ActionSecurite action = new ActionSecurite()
            {
                FicheSecurite = FicheSecurite1,
                Code = "OPQR",
                Description = "Des musoli�res ont �t� achet�es pour les datacores",
                FaitPar = "Nicolas Bouhet"
            };

            ActionSecurite action2 = new ActionSecurite()
            {
                FicheSecurite = FicheSecurite1,
                Code = "STUV",
                Description = "Les racks serveurs ont �t� renforc�s",
                FaitPar = "Nicolas Bouhet"
            };

            //for (int i = 0; i < 10; i++)
            //{
                context.FicheSecurites.Add(FicheSecurite1);
                context.ActionSecurites.Add(action);
                context.ActionSecurites.Add(action2);
                context.FicheSecurites.Add(FicheSecurite2);
                context.FicheSecurites.Add(FicheSecurite3);
                context.FicheSecurites.Add(FicheSecurite4);
                //System.Diagnostics.Debug.WriteLine("Passage boucle"); 
                
            //}

                CauseQSE Cause1 = new CauseQSE()
                {
                    Description = "Manque de formation",
                    FicheSecurite = FicheSecurite1
                };

                CauseQSE Cause2 = new CauseQSE()
                {
                    Description = "R�gles non respect�es",
                    FicheSecurite = FicheSecurite1
                };

                CauseQSE Cause3 = new CauseQSE()
                {
                    Description = "Port d'une protection non respect�",
                    FicheSecurite = FicheSecurite2
                };

                CauseQSE Cause4 = new CauseQSE()
                {
                    Description = "Remplacement de l'op�rateur habituel � la vol�e",
                    FicheSecurite = FicheSecurite2
                };

            context.Causes.Add(Cause1);
            context.Causes.Add(Cause2);
            context.Causes.Add(Cause3);
            context.Causes.Add(Cause4);

            ActionQSE Action1 = new ActionQSE()
            {
                Description = "Pr�voir une nouvelle formation cariste",
                DateButoireInitiale = DateTime.Now,
                Responsable = PersonneConcernee4,
                Cloture = false,
                CauseQSE = Cause1,
                DateButoireNouvelle = DateTime.Now,
                RealiseDate = DateTime.Now,
                VerifieDate = DateTime.Now,
                ClotureDate = DateTime.Now
            };

            ActionQSE Action2 = new ActionQSE()
            {
                Description = "S'avertir les uns les autres",
                DateButoireInitiale = DateTime.Now,
                Responsable = PersonneConcernee3,
                Cloture = true,
                ClotureDate = DateTime.Now,
                CauseQSE = Cause1,
                DateButoireNouvelle = DateTime.Now,
                RealiseDate = DateTime.Now,
                VerifieDate = DateTime.Now
            };

            context.Actions.Add(Action1);
            context.Actions.Add(Action2);

            ADRole ADRoleHSEAdministrateur = new ADRole()
            {
                Name = "REFRESCO\\\\RFS-Service des Systemes d'Information-Responsable Logicielles",
                RoleType = "HSE",
                RoleCode = "100"

            };

            context.ADRoles.Add(ADRoleHSEAdministrateur);

            context.SaveChanges();
        }
    }
}
