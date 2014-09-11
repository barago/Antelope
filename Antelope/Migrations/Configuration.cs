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
                Nom = "Saint-Alban",
                Trigramme = "STA",
                Arouperr = "Site STA"
            };

            Site siteNSG = new Site()
            {
                Nom = "Nuits-Saint-Georges",
                Trigramme = "NSG",
                Arouperr = "Site NSG"
            };

            Site siteLQN = new Site()
            {
                Nom = "Le Quesnoys",
                Trigramme = "LQN",
                Arouperr = "Site LQN"
            };

            context.Sites.Add(siteRFS);
            context.Sites.Add(siteDLF);
            context.Sites.Add(siteSTA);
            context.Sites.Add(siteNSG);
            context.Sites.Add(siteLQN);

            List<string> AllPosteDeTravailNom = new List<string>() { "Administratif", "Agriculteur", "Cariste", "Chauffeurs", "Encadrement intermédiaire", "Etiqueteur", "Fardeleur", "Laborentin Process / MP", "Laborentin R&D / Microbio", "Magasinier MP", "Magasinier soufflage", "Opérateur SB / R3 / R4", "Palettiseur", "Personne extérieure", "Personnel maintenance", "Pilote process", "Préparateur", "Régleur", "Souffleur", "Technicien terrain" };

            List<PosteDeTravail> AllPosteDeTravail = new List<PosteDeTravail>();

            foreach (string PosteDeTravailNom in AllPosteDeTravailNom)
            {
                PosteDeTravail PosteDeTravail = new PosteDeTravail()
                {
                    Nom = PosteDeTravailNom
                };

                AllPosteDeTravail.Add(PosteDeTravail);
                context.PosteDeTravails.Add(PosteDeTravail);
            };

            //ZoneType ZoneRDCRFS = new ZoneType()
            //{
            //    Nom = "Rez-de-chaussée",
            //    Site = siteRFS
            //};

            //ZoneType ZoneEtage1RFS = new ZoneType()
            //{
            //    Nom = "1er étage",
            //    Site = siteRFS
            //};

            //ZoneType ZoneLigne1DLF = new ZoneType()
            //{
            //    Nom = "Ligne 1",
            //    Site = siteDLF
            //};

            //ZoneType ZoneLigne2DLF = new ZoneType()
            //{
            //    Nom = "Ligne 2",
            //    Site = siteDLF
            //};

            //context.Zones.Add(ZoneRDCRFS);
            //context.Zones.Add(ZoneEtage1RFS);
            //context.Zones.Add(ZoneLigne1DLF);
            //context.Zones.Add(ZoneLigne2DLF


            ZoneType ZoneType1 = new ZoneType() { Nom = "Tout le site" };
            ZoneType ZoneType2 = new ZoneType() { Nom = "Soufflage" };
            ZoneType ZoneType3 = new ZoneType() { Nom = "Process" };
            ZoneType ZoneType4 = new ZoneType() { Nom = "Conditionnement" };
            ZoneType ZoneType5 = new ZoneType() { Nom = "Dépôts" };
            ZoneType ZoneType6 = new ZoneType() { Nom = "Maintenance" };
            ZoneType ZoneType7 = new ZoneType() { Nom = "Qualité" };
            ZoneType ZoneType8 = new ZoneType() { Nom = "Extérieur" };
            ZoneType ZoneType9 = new ZoneType() { Nom = "Autre" };

            context.ZoneTypes.Add(ZoneType1);
            context.ZoneTypes.Add(ZoneType2);
            context.ZoneTypes.Add(ZoneType3);
            context.ZoneTypes.Add(ZoneType4);
            context.ZoneTypes.Add(ZoneType5);
            context.ZoneTypes.Add(ZoneType6);
            context.ZoneTypes.Add(ZoneType7);
            context.ZoneTypes.Add(ZoneType8);
            context.ZoneTypes.Add(ZoneType9);


            //------------------AJOUT DES ZONES POUR CHAQUE SITE----------------------------

            // -------------------------RFS---------------------------------------------



            // -------------------------DLF---------------------------------------------


            Zone ZoneDLF1 = new Zone() { Site = siteDLF, ZoneType = ZoneType1 };
            Zone ZoneDLF2 = new Zone() { Site = siteDLF, ZoneType = ZoneType2 };
            Zone ZoneDLF3 = new Zone() { Site = siteDLF, ZoneType = ZoneType3 };
            Zone ZoneDLF4 = new Zone() { Site = siteDLF, ZoneType = ZoneType4 };
            Zone ZoneDLF5 = new Zone() { Site = siteDLF, ZoneType = ZoneType5 };
            Zone ZoneDLF6 = new Zone() { Site = siteDLF, ZoneType = ZoneType6 };
            Zone ZoneDLF7 = new Zone() { Site = siteDLF, ZoneType = ZoneType7 };
            Zone ZoneDLF8 = new Zone() { Site = siteDLF, ZoneType = ZoneType8 };
            Zone ZoneDLF9 = new Zone() { Site = siteDLF, ZoneType = ZoneType9 };

            context.Zones.Add(ZoneDLF1);
            context.Zones.Add(ZoneDLF2);
            context.Zones.Add(ZoneDLF3);
            context.Zones.Add(ZoneDLF4);
            context.Zones.Add(ZoneDLF5);
            context.Zones.Add(ZoneDLF6);
            context.Zones.Add(ZoneDLF7);
            context.Zones.Add(ZoneDLF8);
            context.Zones.Add(ZoneDLF9);

            // -------------------------STA---------------------------------------------

            Zone ZoneSTA1 = new Zone() { Site = siteSTA, ZoneType = ZoneType1 };
            Zone ZoneSTA2 = new Zone() { Site = siteSTA, ZoneType = ZoneType2 };
            Zone ZoneSTA3 = new Zone() { Site = siteSTA, ZoneType = ZoneType3 };
            Zone ZoneSTA4 = new Zone() { Site = siteSTA, ZoneType = ZoneType4 };
            Zone ZoneSTA5 = new Zone() { Site = siteSTA, ZoneType = ZoneType5 };
            Zone ZoneSTA6 = new Zone() { Site = siteSTA, ZoneType = ZoneType6 };
            Zone ZoneSTA7 = new Zone() { Site = siteSTA, ZoneType = ZoneType7 };
            Zone ZoneSTA8 = new Zone() { Site = siteSTA, ZoneType = ZoneType8 };
            Zone ZoneSTA9 = new Zone() { Site = siteSTA, ZoneType = ZoneType9 };

            context.Zones.Add(ZoneSTA1);
            context.Zones.Add(ZoneSTA2);
            context.Zones.Add(ZoneSTA3);
            context.Zones.Add(ZoneSTA4);
            context.Zones.Add(ZoneSTA5);
            context.Zones.Add(ZoneSTA6);
            context.Zones.Add(ZoneSTA7);
            context.Zones.Add(ZoneSTA8);
            context.Zones.Add(ZoneSTA9);

            // -------------------------NSG---------------------------------------------
            Zone ZoneNSG1 = new Zone() { Site = siteNSG, ZoneType = ZoneType1 };
            Zone ZoneNSG2 = new Zone() { Site = siteNSG, ZoneType = ZoneType2 };
            Zone ZoneNSG3 = new Zone() { Site = siteNSG, ZoneType = ZoneType3 };
            Zone ZoneNSG4 = new Zone() { Site = siteNSG, ZoneType = ZoneType4 };
            Zone ZoneNSG5 = new Zone() { Site = siteNSG, ZoneType = ZoneType5 };
            Zone ZoneNSG6 = new Zone() { Site = siteNSG, ZoneType = ZoneType6 };
            Zone ZoneNSG7 = new Zone() { Site = siteNSG, ZoneType = ZoneType7 };
            Zone ZoneNSG8 = new Zone() { Site = siteNSG, ZoneType = ZoneType8 };
            Zone ZoneNSG9 = new Zone() { Site = siteNSG, ZoneType = ZoneType9 };

            context.Zones.Add(ZoneNSG1);
            context.Zones.Add(ZoneNSG2);
            context.Zones.Add(ZoneNSG3);
            context.Zones.Add(ZoneNSG4);
            context.Zones.Add(ZoneNSG5);
            context.Zones.Add(ZoneNSG6);
            context.Zones.Add(ZoneNSG7);
            context.Zones.Add(ZoneNSG8);
            context.Zones.Add(ZoneNSG9);

            // -------------------------LQN---------------------------------------------
            Zone ZoneLQN1 = new Zone() { Site = siteLQN, ZoneType = ZoneType1 };
            Zone ZoneLQN2 = new Zone() { Site = siteLQN, ZoneType = ZoneType2 };
            Zone ZoneLQN3 = new Zone() { Site = siteLQN, ZoneType = ZoneType3 };
            Zone ZoneLQN4 = new Zone() { Site = siteLQN, ZoneType = ZoneType4 };
            Zone ZoneLQN5 = new Zone() { Site = siteLQN, ZoneType = ZoneType5 };
            Zone ZoneLQN6 = new Zone() { Site = siteLQN, ZoneType = ZoneType6 };
            Zone ZoneLQN7 = new Zone() { Site = siteLQN, ZoneType = ZoneType7 };
            Zone ZoneLQN8 = new Zone() { Site = siteLQN, ZoneType = ZoneType8 };
            Zone ZoneLQN9 = new Zone() { Site = siteLQN, ZoneType = ZoneType9 };

            context.Zones.Add(ZoneLQN1);
            context.Zones.Add(ZoneLQN2);
            context.Zones.Add(ZoneLQN3);
            context.Zones.Add(ZoneLQN4);
            context.Zones.Add(ZoneLQN5);
            context.Zones.Add(ZoneLQN6);
            context.Zones.Add(ZoneLQN7);
            context.Zones.Add(ZoneLQN8);
            context.Zones.Add(ZoneLQN9);

            //--------------------------------------------------------------

            //------------------------LIEUX-----------------------------


            LieuType LieuType1 = new LieuType() { Nom = "Toute la zone" };
            LieuType LieuType2 = new LieuType() { Nom = "DépôtB/P" };
            LieuType LieuType3 = new LieuType() { Nom = "DépôtMP" };
            LieuType LieuType4 = new LieuType() { Nom = "Préparation / Pré-pesée" };
            LieuType LieuType5 = new LieuType() { Nom = "Zone NEP / Dépotage" };
            LieuType LieuType6 = new LieuType() { Nom = "SB 1/2" };
            LieuType LieuType7 = new LieuType() { Nom = "R 3" };
            LieuType LieuType8 = new LieuType() { Nom = "R 4" };
            LieuType LieuType9 = new LieuType() { Nom = "Etiqueteuse" };
            LieuType LieuType10 = new LieuType() { Nom = "Fardeleuse" };
            LieuType LieuType11 = new LieuType() { Nom = "BdL" };
            LieuType LieuType12 = new LieuType() { Nom = "AGV" };
            LieuType LieuType13 = new LieuType() { Nom = "Dépôt PF" };
            LieuType LieuType14 = new LieuType() { Nom = "Energies" };
            LieuType LieuType15 = new LieuType() { Nom = "Travaux" };
            LieuType LieuType16 = new LieuType() { Nom = "Labo microbiologie" };
            LieuType LieuType17 = new LieuType() { Nom = "Zone déchets" };
            LieuType LieuType18 = new LieuType() { Nom = "Forage" };
            LieuType LieuType19 = new LieuType() { Nom = "Epandage" };
            LieuType LieuType20 = new LieuType() { Nom = "Bât. Adm" };
            //LieuType LieuType21 = new LieuType() { Nom = "Global usine" };
            LieuType LieuType22 = new LieuType() { Nom = "Autre" };

            context.LieuTypes.Add(LieuType1);
            context.LieuTypes.Add(LieuType2);
            context.LieuTypes.Add(LieuType3);
            context.LieuTypes.Add(LieuType4);
            context.LieuTypes.Add(LieuType5);
            context.LieuTypes.Add(LieuType6);
            context.LieuTypes.Add(LieuType7);
            context.LieuTypes.Add(LieuType8);
            context.LieuTypes.Add(LieuType9);
            context.LieuTypes.Add(LieuType10);
            context.LieuTypes.Add(LieuType11);
            context.LieuTypes.Add(LieuType12);
            context.LieuTypes.Add(LieuType13);
            context.LieuTypes.Add(LieuType14);
            context.LieuTypes.Add(LieuType15);
            context.LieuTypes.Add(LieuType16);
            context.LieuTypes.Add(LieuType17);
            context.LieuTypes.Add(LieuType18);
            context.LieuTypes.Add(LieuType19);
            context.LieuTypes.Add(LieuType20);
            context.LieuTypes.Add(LieuType22);


            //------------------AJOUT DES LIEUX POUR CHAQUE ZONE----------------------------

            // -------------------------RFS---------------------------------------------



            // -------------------------DLF---------------------------------------------

            Lieu LieuDLFZone2_1 = new Lieu() { Zone = ZoneDLF2, LieuType = LieuType1 };
            Lieu LieuDLFZone2_2 = new Lieu() { Zone = ZoneDLF2, LieuType = LieuType22 };

            Lieu LieuDLFZone3_0 = new Lieu() { Zone = ZoneDLF3, LieuType = LieuType1 };
            Lieu LieuDLFZone3_1 = new Lieu() { Zone = ZoneDLF3, LieuType = LieuType4 };
            Lieu LieuDLFZone3_2 = new Lieu() { Zone = ZoneDLF3, LieuType = LieuType5 };
            Lieu LieuDLFZone3_3 = new Lieu() { Zone = ZoneDLF3, LieuType = LieuType6 };
            Lieu LieuDLFZone3_4 = new Lieu() { Zone = ZoneDLF3, LieuType = LieuType7 };
            Lieu LieuDLFZone3_5 = new Lieu() { Zone = ZoneDLF3, LieuType = LieuType8 };
            Lieu LieuDLFZone3_6 = new Lieu() { Zone = ZoneDLF3, LieuType = LieuType22 };

            Lieu LieuDLFZone4_0 = new Lieu() { Zone = ZoneDLF4, LieuType = LieuType1 };
            Lieu LieuDLFZone4_1 = new Lieu() { Zone = ZoneDLF4, LieuType = LieuType9 };
            Lieu LieuDLFZone4_2 = new Lieu() { Zone = ZoneDLF4, LieuType = LieuType10 };
            Lieu LieuDLFZone4_3 = new Lieu() { Zone = ZoneDLF4, LieuType = LieuType11 };
            Lieu LieuDLFZone4_4 = new Lieu() { Zone = ZoneDLF4, LieuType = LieuType12 };
            Lieu LieuDLFZone4_5 = new Lieu() { Zone = ZoneDLF4, LieuType = LieuType22 };

            Lieu LieuDLFZone5_0 = new Lieu() { Zone = ZoneDLF5, LieuType = LieuType1 };
            Lieu LieuDLFZone5_1 = new Lieu() { Zone = ZoneDLF5, LieuType = LieuType2 };
            Lieu LieuDLFZone5_2 = new Lieu() { Zone = ZoneDLF5, LieuType = LieuType3 };
            Lieu LieuDLFZone5_3 = new Lieu() { Zone = ZoneDLF5, LieuType = LieuType13 };
            Lieu LieuDLFZone5_4 = new Lieu() { Zone = ZoneDLF5, LieuType = LieuType22 };

            Lieu LieuDLFZone6_0 = new Lieu() { Zone = ZoneDLF6, LieuType = LieuType1 };
            Lieu LieuDLFZone6_1 = new Lieu() { Zone = ZoneDLF6, LieuType = LieuType14 };
            Lieu LieuDLFZone6_2 = new Lieu() { Zone = ZoneDLF6, LieuType = LieuType15 };
            Lieu LieuDLFZone6_3 = new Lieu() { Zone = ZoneDLF6, LieuType = LieuType18 };
            Lieu LieuDLFZone6_4 = new Lieu() { Zone = ZoneDLF6, LieuType = LieuType22 };

            Lieu LieuDLFZone7_0 = new Lieu() { Zone = ZoneDLF7, LieuType = LieuType1 };
            Lieu LieuDLFZone7_1 = new Lieu() { Zone = ZoneDLF7, LieuType = LieuType16 };
            Lieu LieuDLFZone7_2 = new Lieu() { Zone = ZoneDLF7, LieuType = LieuType22 };

            Lieu LieuDLFZone8_0 = new Lieu() { Zone = ZoneDLF8, LieuType = LieuType1 };
            Lieu LieuDLFZone8_1 = new Lieu() { Zone = ZoneDLF8, LieuType = LieuType17 };
            Lieu LieuDLFZone8_2 = new Lieu() { Zone = ZoneDLF8, LieuType = LieuType19 };
            Lieu LieuDLFZone8_3 = new Lieu() { Zone = ZoneDLF8, LieuType = LieuType22 };

            Lieu LieuDLFZone9_0 = new Lieu() { Zone = ZoneDLF9, LieuType = LieuType1 };
            Lieu LieuDLFZone9_1 = new Lieu() { Zone = ZoneDLF9, LieuType = LieuType20 };
            Lieu LieuDLFZone9_2 = new Lieu() { Zone = ZoneDLF9, LieuType = LieuType22 };

            context.Lieux.Add(LieuDLFZone2_1);
            context.Lieux.Add(LieuDLFZone2_2);

            context.Lieux.Add(LieuDLFZone3_0);
            context.Lieux.Add(LieuDLFZone3_1);
            context.Lieux.Add(LieuDLFZone3_2);
            context.Lieux.Add(LieuDLFZone3_3);
            context.Lieux.Add(LieuDLFZone3_4);
            context.Lieux.Add(LieuDLFZone3_5);
            context.Lieux.Add(LieuDLFZone3_6);

            context.Lieux.Add(LieuDLFZone4_0);
            context.Lieux.Add(LieuDLFZone4_1);
            context.Lieux.Add(LieuDLFZone4_2);
            context.Lieux.Add(LieuDLFZone4_3);
            context.Lieux.Add(LieuDLFZone4_4);
            context.Lieux.Add(LieuDLFZone4_5);

            context.Lieux.Add(LieuDLFZone5_0);
            context.Lieux.Add(LieuDLFZone5_1);
            context.Lieux.Add(LieuDLFZone5_2);
            context.Lieux.Add(LieuDLFZone5_3);
            context.Lieux.Add(LieuDLFZone5_4);

            context.Lieux.Add(LieuDLFZone6_0);
            context.Lieux.Add(LieuDLFZone6_1);
            context.Lieux.Add(LieuDLFZone6_2);
            context.Lieux.Add(LieuDLFZone6_3);
            context.Lieux.Add(LieuDLFZone6_4);

            context.Lieux.Add(LieuDLFZone7_0);
            context.Lieux.Add(LieuDLFZone7_1);
            context.Lieux.Add(LieuDLFZone7_2);

            context.Lieux.Add(LieuDLFZone8_0);
            context.Lieux.Add(LieuDLFZone8_1);
            context.Lieux.Add(LieuDLFZone8_2);
            context.Lieux.Add(LieuDLFZone8_3);

            context.Lieux.Add(LieuDLFZone9_0);
            context.Lieux.Add(LieuDLFZone9_1);
            context.Lieux.Add(LieuDLFZone9_2);


            // -------------------------STA---------------------------------------------

            Lieu LieuSTAZone2_1 = new Lieu() { Zone = ZoneSTA2, LieuType = LieuType1 };
            Lieu LieuSTAZone2_2 = new Lieu() { Zone = ZoneSTA2, LieuType = LieuType22 };

            Lieu LieuSTAZone3_0 = new Lieu() { Zone = ZoneSTA3, LieuType = LieuType1 };
            Lieu LieuSTAZone3_1 = new Lieu() { Zone = ZoneSTA3, LieuType = LieuType4 };
            Lieu LieuSTAZone3_2 = new Lieu() { Zone = ZoneSTA3, LieuType = LieuType5 };
            Lieu LieuSTAZone3_3 = new Lieu() { Zone = ZoneSTA3, LieuType = LieuType6 };
            Lieu LieuSTAZone3_4 = new Lieu() { Zone = ZoneSTA3, LieuType = LieuType7 };
            Lieu LieuSTAZone3_5 = new Lieu() { Zone = ZoneSTA3, LieuType = LieuType8 };
            Lieu LieuSTAZone3_6 = new Lieu() { Zone = ZoneSTA3, LieuType = LieuType22 };

            Lieu LieuSTAZone4_0 = new Lieu() { Zone = ZoneSTA4, LieuType = LieuType1 };
            Lieu LieuSTAZone4_1 = new Lieu() { Zone = ZoneSTA4, LieuType = LieuType9 };
            Lieu LieuSTAZone4_2 = new Lieu() { Zone = ZoneSTA4, LieuType = LieuType10 };
            Lieu LieuSTAZone4_3 = new Lieu() { Zone = ZoneSTA4, LieuType = LieuType11 };
            Lieu LieuSTAZone4_4 = new Lieu() { Zone = ZoneSTA4, LieuType = LieuType12 };
            Lieu LieuSTAZone4_5 = new Lieu() { Zone = ZoneSTA4, LieuType = LieuType22 };

            Lieu LieuSTAZone5_0 = new Lieu() { Zone = ZoneSTA5, LieuType = LieuType1 };
            Lieu LieuSTAZone5_1 = new Lieu() { Zone = ZoneSTA5, LieuType = LieuType2 };
            Lieu LieuSTAZone5_2 = new Lieu() { Zone = ZoneSTA5, LieuType = LieuType3 };
            Lieu LieuSTAZone5_3 = new Lieu() { Zone = ZoneSTA5, LieuType = LieuType13 };
            Lieu LieuSTAZone5_4 = new Lieu() { Zone = ZoneSTA5, LieuType = LieuType22 };

            Lieu LieuSTAZone6_0 = new Lieu() { Zone = ZoneSTA6, LieuType = LieuType1 };
            Lieu LieuSTAZone6_1 = new Lieu() { Zone = ZoneSTA6, LieuType = LieuType14 };
            Lieu LieuSTAZone6_2 = new Lieu() { Zone = ZoneSTA6, LieuType = LieuType15 };
            Lieu LieuSTAZone6_3 = new Lieu() { Zone = ZoneSTA6, LieuType = LieuType18 };
            Lieu LieuSTAZone6_4 = new Lieu() { Zone = ZoneSTA6, LieuType = LieuType22 };

            Lieu LieuSTAZone7_0 = new Lieu() { Zone = ZoneSTA7, LieuType = LieuType1 };
            Lieu LieuSTAZone7_1 = new Lieu() { Zone = ZoneSTA7, LieuType = LieuType16 };
            Lieu LieuSTAZone7_2 = new Lieu() { Zone = ZoneSTA7, LieuType = LieuType22 };

            Lieu LieuSTAZone8_0 = new Lieu() { Zone = ZoneSTA8, LieuType = LieuType1 };
            Lieu LieuSTAZone8_1 = new Lieu() { Zone = ZoneSTA8, LieuType = LieuType17 };
            Lieu LieuSTAZone8_2 = new Lieu() { Zone = ZoneSTA8, LieuType = LieuType19 };
            Lieu LieuSTAZone8_3 = new Lieu() { Zone = ZoneSTA8, LieuType = LieuType22 };

            Lieu LieuSTAZone9_0 = new Lieu() { Zone = ZoneSTA9, LieuType = LieuType1 };
            Lieu LieuSTAZone9_1 = new Lieu() { Zone = ZoneSTA9, LieuType = LieuType20 };
            Lieu LieuSTAZone9_2 = new Lieu() { Zone = ZoneSTA9, LieuType = LieuType22 };

            context.Lieux.Add(LieuSTAZone2_1);
            context.Lieux.Add(LieuSTAZone2_2);

            context.Lieux.Add(LieuSTAZone3_0);
            context.Lieux.Add(LieuSTAZone3_1);
            context.Lieux.Add(LieuSTAZone3_2);
            context.Lieux.Add(LieuSTAZone3_3);
            context.Lieux.Add(LieuSTAZone3_4);
            context.Lieux.Add(LieuSTAZone3_5);
            context.Lieux.Add(LieuSTAZone3_6);

            context.Lieux.Add(LieuSTAZone4_0);
            context.Lieux.Add(LieuSTAZone4_1);
            context.Lieux.Add(LieuSTAZone4_2);
            context.Lieux.Add(LieuSTAZone4_3);
            context.Lieux.Add(LieuSTAZone4_4);
            context.Lieux.Add(LieuSTAZone4_5);

            context.Lieux.Add(LieuSTAZone5_0);
            context.Lieux.Add(LieuSTAZone5_1);
            context.Lieux.Add(LieuSTAZone5_2);
            context.Lieux.Add(LieuSTAZone5_3);
            context.Lieux.Add(LieuSTAZone5_4);

            context.Lieux.Add(LieuSTAZone6_0);
            context.Lieux.Add(LieuSTAZone6_1);
            context.Lieux.Add(LieuSTAZone6_2);
            context.Lieux.Add(LieuSTAZone6_3);
            context.Lieux.Add(LieuSTAZone6_4);

            context.Lieux.Add(LieuSTAZone7_0);
            context.Lieux.Add(LieuSTAZone7_1);
            context.Lieux.Add(LieuSTAZone7_2);

            context.Lieux.Add(LieuSTAZone8_0);
            context.Lieux.Add(LieuSTAZone8_1);
            context.Lieux.Add(LieuSTAZone8_2);
            context.Lieux.Add(LieuSTAZone8_3);

            context.Lieux.Add(LieuSTAZone9_0);
            context.Lieux.Add(LieuSTAZone9_1);
            context.Lieux.Add(LieuSTAZone9_2);

            // -------------------------NSG---------------------------------------------

            Lieu LieuNSGZone2_1 = new Lieu() { Zone = ZoneNSG2, LieuType = LieuType1 };
            Lieu LieuNSGZone2_2 = new Lieu() { Zone = ZoneNSG2, LieuType = LieuType22 };

            Lieu LieuNSGZone3_0 = new Lieu() { Zone = ZoneNSG3, LieuType = LieuType1 };
            Lieu LieuNSGZone3_1 = new Lieu() { Zone = ZoneNSG3, LieuType = LieuType4 };
            Lieu LieuNSGZone3_2 = new Lieu() { Zone = ZoneNSG3, LieuType = LieuType5 };
            Lieu LieuNSGZone3_3 = new Lieu() { Zone = ZoneNSG3, LieuType = LieuType6 };
            Lieu LieuNSGZone3_4 = new Lieu() { Zone = ZoneNSG3, LieuType = LieuType7 };
            Lieu LieuNSGZone3_5 = new Lieu() { Zone = ZoneNSG3, LieuType = LieuType8 };
            Lieu LieuNSGZone3_6 = new Lieu() { Zone = ZoneNSG3, LieuType = LieuType22 };

            Lieu LieuNSGZone4_0 = new Lieu() { Zone = ZoneNSG4, LieuType = LieuType1 };
            Lieu LieuNSGZone4_1 = new Lieu() { Zone = ZoneNSG4, LieuType = LieuType9 };
            Lieu LieuNSGZone4_2 = new Lieu() { Zone = ZoneNSG4, LieuType = LieuType10 };
            Lieu LieuNSGZone4_3 = new Lieu() { Zone = ZoneNSG4, LieuType = LieuType11 };
            Lieu LieuNSGZone4_4 = new Lieu() { Zone = ZoneNSG4, LieuType = LieuType12 };
            Lieu LieuNSGZone4_5 = new Lieu() { Zone = ZoneNSG4, LieuType = LieuType22 };

            Lieu LieuNSGZone5_0 = new Lieu() { Zone = ZoneNSG5, LieuType = LieuType1 };
            Lieu LieuNSGZone5_1 = new Lieu() { Zone = ZoneNSG5, LieuType = LieuType2 };
            Lieu LieuNSGZone5_2 = new Lieu() { Zone = ZoneNSG5, LieuType = LieuType3 };
            Lieu LieuNSGZone5_3 = new Lieu() { Zone = ZoneNSG5, LieuType = LieuType13 };
            Lieu LieuNSGZone5_4 = new Lieu() { Zone = ZoneNSG5, LieuType = LieuType22 };

            Lieu LieuNSGZone6_0 = new Lieu() { Zone = ZoneNSG6, LieuType = LieuType1 };
            Lieu LieuNSGZone6_1 = new Lieu() { Zone = ZoneNSG6, LieuType = LieuType14 };
            Lieu LieuNSGZone6_2 = new Lieu() { Zone = ZoneNSG6, LieuType = LieuType15 };
            Lieu LieuNSGZone6_3 = new Lieu() { Zone = ZoneNSG6, LieuType = LieuType18 };
            Lieu LieuNSGZone6_4 = new Lieu() { Zone = ZoneNSG6, LieuType = LieuType22 };

            Lieu LieuNSGZone7_0 = new Lieu() { Zone = ZoneNSG7, LieuType = LieuType1 };
            Lieu LieuNSGZone7_1 = new Lieu() { Zone = ZoneNSG7, LieuType = LieuType16 };
            Lieu LieuNSGZone7_2 = new Lieu() { Zone = ZoneNSG7, LieuType = LieuType22 };

            Lieu LieuNSGZone8_0 = new Lieu() { Zone = ZoneNSG8, LieuType = LieuType1 };
            Lieu LieuNSGZone8_1 = new Lieu() { Zone = ZoneNSG8, LieuType = LieuType17 };
            Lieu LieuNSGZone8_2 = new Lieu() { Zone = ZoneNSG8, LieuType = LieuType19 };
            Lieu LieuNSGZone8_3 = new Lieu() { Zone = ZoneNSG8, LieuType = LieuType22 };

            Lieu LieuNSGZone9_0 = new Lieu() { Zone = ZoneNSG9, LieuType = LieuType1 };
            Lieu LieuNSGZone9_1 = new Lieu() { Zone = ZoneNSG9, LieuType = LieuType20 };
            Lieu LieuNSGZone9_2 = new Lieu() { Zone = ZoneNSG9, LieuType = LieuType22 };

            context.Lieux.Add(LieuNSGZone2_1);
            context.Lieux.Add(LieuNSGZone2_2);

            context.Lieux.Add(LieuNSGZone3_0);
            context.Lieux.Add(LieuNSGZone3_1);
            context.Lieux.Add(LieuNSGZone3_2);
            context.Lieux.Add(LieuNSGZone3_3);
            context.Lieux.Add(LieuNSGZone3_4);
            context.Lieux.Add(LieuNSGZone3_5);
            context.Lieux.Add(LieuNSGZone3_6);

            context.Lieux.Add(LieuNSGZone4_0);
            context.Lieux.Add(LieuNSGZone4_1);
            context.Lieux.Add(LieuNSGZone4_2);
            context.Lieux.Add(LieuNSGZone4_3);
            context.Lieux.Add(LieuNSGZone4_4);
            context.Lieux.Add(LieuNSGZone4_5);

            context.Lieux.Add(LieuNSGZone5_0);
            context.Lieux.Add(LieuNSGZone5_1);
            context.Lieux.Add(LieuNSGZone5_2);
            context.Lieux.Add(LieuNSGZone5_3);
            context.Lieux.Add(LieuNSGZone5_4);

            context.Lieux.Add(LieuNSGZone6_0);
            context.Lieux.Add(LieuNSGZone6_1);
            context.Lieux.Add(LieuNSGZone6_2);
            context.Lieux.Add(LieuNSGZone6_3);
            context.Lieux.Add(LieuNSGZone6_4);

            context.Lieux.Add(LieuNSGZone7_0);
            context.Lieux.Add(LieuNSGZone7_1);
            context.Lieux.Add(LieuNSGZone7_2);

            context.Lieux.Add(LieuNSGZone8_0);
            context.Lieux.Add(LieuNSGZone8_1);
            context.Lieux.Add(LieuNSGZone8_2);
            context.Lieux.Add(LieuNSGZone8_3);

            context.Lieux.Add(LieuNSGZone9_0);
            context.Lieux.Add(LieuNSGZone9_1);
            context.Lieux.Add(LieuNSGZone9_2);

            // -------------------------LQN---------------------------------------------

            Lieu LieuLQNZone2_1 = new Lieu() { Zone = ZoneLQN2, LieuType = LieuType1 };
            Lieu LieuLQNZone2_2 = new Lieu() { Zone = ZoneLQN2, LieuType = LieuType22 };

            Lieu LieuLQNZone3_0 = new Lieu() { Zone = ZoneLQN3, LieuType = LieuType1 };
            Lieu LieuLQNZone3_1 = new Lieu() { Zone = ZoneLQN3, LieuType = LieuType4 };
            Lieu LieuLQNZone3_2 = new Lieu() { Zone = ZoneLQN3, LieuType = LieuType5 };
            Lieu LieuLQNZone3_3 = new Lieu() { Zone = ZoneLQN3, LieuType = LieuType6 };
            Lieu LieuLQNZone3_4 = new Lieu() { Zone = ZoneLQN3, LieuType = LieuType7 };
            Lieu LieuLQNZone3_5 = new Lieu() { Zone = ZoneLQN3, LieuType = LieuType8 };
            Lieu LieuLQNZone3_6 = new Lieu() { Zone = ZoneLQN3, LieuType = LieuType22 };

            Lieu LieuLQNZone4_0 = new Lieu() { Zone = ZoneLQN4, LieuType = LieuType1 };
            Lieu LieuLQNZone4_1 = new Lieu() { Zone = ZoneLQN4, LieuType = LieuType9 };
            Lieu LieuLQNZone4_2 = new Lieu() { Zone = ZoneLQN4, LieuType = LieuType10 };
            Lieu LieuLQNZone4_3 = new Lieu() { Zone = ZoneLQN4, LieuType = LieuType11 };
            Lieu LieuLQNZone4_4 = new Lieu() { Zone = ZoneLQN4, LieuType = LieuType12 };
            Lieu LieuLQNZone4_5 = new Lieu() { Zone = ZoneLQN4, LieuType = LieuType22 };

            Lieu LieuLQNZone5_0 = new Lieu() { Zone = ZoneLQN5, LieuType = LieuType1 };
            Lieu LieuLQNZone5_1 = new Lieu() { Zone = ZoneLQN5, LieuType = LieuType2 };
            Lieu LieuLQNZone5_2 = new Lieu() { Zone = ZoneLQN5, LieuType = LieuType3 };
            Lieu LieuLQNZone5_3 = new Lieu() { Zone = ZoneLQN5, LieuType = LieuType13 };
            Lieu LieuLQNZone5_4 = new Lieu() { Zone = ZoneLQN5, LieuType = LieuType22 };

            Lieu LieuLQNZone6_0 = new Lieu() { Zone = ZoneLQN6, LieuType = LieuType1 };
            Lieu LieuLQNZone6_1 = new Lieu() { Zone = ZoneLQN6, LieuType = LieuType14 };
            Lieu LieuLQNZone6_2 = new Lieu() { Zone = ZoneLQN6, LieuType = LieuType15 };
            Lieu LieuLQNZone6_3 = new Lieu() { Zone = ZoneLQN6, LieuType = LieuType18 };
            Lieu LieuLQNZone6_4 = new Lieu() { Zone = ZoneLQN6, LieuType = LieuType22 };

            Lieu LieuLQNZone7_0 = new Lieu() { Zone = ZoneLQN7, LieuType = LieuType1 };
            Lieu LieuLQNZone7_1 = new Lieu() { Zone = ZoneLQN7, LieuType = LieuType16 };
            Lieu LieuLQNZone7_2 = new Lieu() { Zone = ZoneLQN7, LieuType = LieuType22 };

            Lieu LieuLQNZone8_0 = new Lieu() { Zone = ZoneLQN8, LieuType = LieuType1 };
            Lieu LieuLQNZone8_1 = new Lieu() { Zone = ZoneLQN8, LieuType = LieuType17 };
            Lieu LieuLQNZone8_2 = new Lieu() { Zone = ZoneLQN8, LieuType = LieuType19 };
            Lieu LieuLQNZone8_3 = new Lieu() { Zone = ZoneLQN8, LieuType = LieuType22 };

            Lieu LieuLQNZone9_0 = new Lieu() { Zone = ZoneLQN9, LieuType = LieuType1 };
            Lieu LieuLQNZone9_1 = new Lieu() { Zone = ZoneLQN9, LieuType = LieuType20 };
            Lieu LieuLQNZone9_2 = new Lieu() { Zone = ZoneLQN9, LieuType = LieuType22 };

            context.Lieux.Add(LieuLQNZone2_1);
            context.Lieux.Add(LieuLQNZone2_2);

            context.Lieux.Add(LieuLQNZone3_0);
            context.Lieux.Add(LieuLQNZone3_1);
            context.Lieux.Add(LieuLQNZone3_2);
            context.Lieux.Add(LieuLQNZone3_3);
            context.Lieux.Add(LieuLQNZone3_4);
            context.Lieux.Add(LieuLQNZone3_5);
            context.Lieux.Add(LieuLQNZone3_6);

            context.Lieux.Add(LieuLQNZone4_0);
            context.Lieux.Add(LieuLQNZone4_1);
            context.Lieux.Add(LieuLQNZone4_2);
            context.Lieux.Add(LieuLQNZone4_3);
            context.Lieux.Add(LieuLQNZone4_4);
            context.Lieux.Add(LieuLQNZone4_5);

            context.Lieux.Add(LieuLQNZone5_0);
            context.Lieux.Add(LieuLQNZone5_1);
            context.Lieux.Add(LieuLQNZone5_2);
            context.Lieux.Add(LieuLQNZone5_3);
            context.Lieux.Add(LieuLQNZone5_4);

            context.Lieux.Add(LieuLQNZone6_0);
            context.Lieux.Add(LieuLQNZone6_1);
            context.Lieux.Add(LieuLQNZone6_2);
            context.Lieux.Add(LieuLQNZone6_3);
            context.Lieux.Add(LieuLQNZone6_4);

            context.Lieux.Add(LieuLQNZone7_0);
            context.Lieux.Add(LieuLQNZone7_1);
            context.Lieux.Add(LieuLQNZone7_2);

            context.Lieux.Add(LieuLQNZone8_0);
            context.Lieux.Add(LieuLQNZone8_1);
            context.Lieux.Add(LieuLQNZone8_2);
            context.Lieux.Add(LieuLQNZone8_3);

            context.Lieux.Add(LieuLQNZone9_0);
            context.Lieux.Add(LieuLQNZone9_1);
            context.Lieux.Add(LieuLQNZone9_2);





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

            List<string> AllDangerNom = new List<string>() { "Agents biologiques et infectieux", "Ambiance de travail (thermique, éclairage, aération)", 
                "Bruit", "Chute d'objets", "Circulation de piétons", "Circulation d'engins", "Co activité", "Comportement", "Déplacements extérieurs", 
                "Electricité", "Engins de levage ou mobiles", "Equipement sous pression", "Evènement extérieur (pluie, neige, vent, animaux, malveillance)", 
                "Geste et posture", "Machine ou outil dangereux", "Manutention ou port de charge", "Non Classé", "Produit chimique", "Produit gazeux", 
                "Projection (poussière, copeaux…)", "Psychosocial", "Rayonnement dangereux (laser, magnétique, radiation…)", "Stockage", 
                "Travail en hauteur", "Travail isolé", "Travail par point chaud", "Travail sur écran", "Vibration" };

            List<Danger> AllDanger = new List<Danger>();

            for (var i = 0; i < AllDangerNom.Count; i++ )
            {
                Danger Danger = new Danger()
                {
                    Nom = AllDangerNom[i]
                };

                AllDanger.Add(Danger);
                context.Dangers.Add(Danger);
            }

            RisqueType RisqueType1 = new RisqueType() { Nom = "Santé sécurité" };
            RisqueType RisqueType2 = new RisqueType() { Nom = "Sûreté" };
            RisqueType RisqueType3 = new RisqueType() { Nom = "Autre" };

            context.RisqueTypes.Add(RisqueType1);
            context.RisqueTypes.Add(RisqueType2);
            context.RisqueTypes.Add(RisqueType3);

            List<string> AllRisqueNom = new List<string>() { "Asphyxie", "Brûlure/Irritation", "Choc", "Chute de hauteur", "Chute de plain-pied", 
                "Collision d'engins", "Collision engin/piéton", "Coupure", "Electrisation / Electrocution", "Entorse / luxation", 
                "Entrainement / Ecrasement / Coincement", "Fatigue visuelle", "Fatigue, stress, agressivité", "Fracture", 
                "Infection / Intoxication / Allergie / Irradiation", "Lésions oculaires", "Malaise", "Noyade", "Perte d'audition", "Plaie", "TMS / Lombalgie",
                "Explosion", "Foudre", "Incendie", "Inondation", "Intempérie violent", "Intrusion", "Non classé"};

            List<RisqueType> AllRisqueType = new List<RisqueType>() { RisqueType1, RisqueType1, RisqueType1, RisqueType1, RisqueType1, 
                RisqueType1, RisqueType1, RisqueType1, RisqueType1, RisqueType1, 
                RisqueType1, RisqueType1, RisqueType1, RisqueType1, 
                RisqueType1, RisqueType1, RisqueType1, RisqueType1, RisqueType1, RisqueType1, RisqueType1,
                RisqueType2, RisqueType2, RisqueType2, RisqueType2, RisqueType2, RisqueType2, RisqueType3};

            List<Risque> AllRisque = new List<Risque>();

            for (var i = 0; i < AllRisqueNom.Count; i++)
            {
                Risque Risque = new Risque()
                {
                    Nom = AllRisqueNom[i],
                    RisqueType = AllRisqueType[i]
                };

                AllRisque.Add(Risque);
                context.Risques.Add(Risque);
            }

            List<string> AllCorpsHumainZoneNom = new List<string>() { "Yeux", "Tête", "Bras", "Main", "Tronc", "Jambe", "Pied", "Tout le corps", "Multiples lésions", "Dos" };
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
            PlageHoraire plagehoraire2 = new PlageHoraire() { Nom = "Journée" };
            PlageHoraire plagehoraire3 = new PlageHoraire() { Nom = "Matin" };
            PlageHoraire plagehoraire4 = new PlageHoraire() { Nom = "Après-Midi" };


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
                Description = "L'opérateur a pris une charge trop lourde avec son chariot et il s'est renversé",
                CotationFrequence = 1,
                CotationGravite = 2,
                FicheSecuriteType = FicheSecuriteType1,
                Danger = AllDanger[1],
                PlageHoraire = plagehoraire1,
                ActionImmediate1 = "Rappel à tous les caristes de ne prendre les palettes que deux par deux",
                CorpsHumainZone = AllCorpsHumainZone[1],
                PersonneConcernee = PersonneConcernee1,
                Risque = AllRisque[1]
                
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
                Description = "Pour ouvrir les fûts, l'opérateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du fût avec laquelle il s'est coupé",
                CotationFrequence = 0,
                CotationGravite = 4,
                FicheSecuriteType = FicheSecuriteType2,
                Danger = AllDanger[2],
                PlageHoraire = plagehoraire2,
                CorpsHumainZone = AllCorpsHumainZone[2],
                PersonneConcernee = PersonneConcernee2,
                Risque = AllRisque[2]
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
                Description = "L'opérateur a pris une charge trop lourde avec son chariot et il s'est renversé",
                CotationFrequence = 1,
                CotationGravite = 2,
                FicheSecuriteType = FicheSecuriteType3,
                Danger = AllDanger[3],
                PlageHoraire = plagehoraire3,
                ActionImmediate1 = "Rappel à tous les caristes de ne prendre les palettes que deux par deux",
                CorpsHumainZone = AllCorpsHumainZone[3],
                PersonneConcernee = PersonneConcernee3,
                Risque = AllRisque[3]
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
                Description = "Pour ouvrir les fûts, l'opérateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du fût avec laquelle il s'est coupé",
                CotationFrequence = 0,
                CotationGravite = 4,
                FicheSecuriteType = FicheSecuriteType4,
                Danger = AllDanger[3],
                PlageHoraire = plagehoraire4,
                CorpsHumainZone = AllCorpsHumainZone[4],
                PersonneConcernee = PersonneConcernee4,
                Risque = AllRisque[4]
            };


            ActionSecurite action = new ActionSecurite()
            {
                FicheSecurite = FicheSecurite1,
                Code = "OPQR",
                Description = "Des musolières ont été achetées pour les datacores",
                FaitPar = "Nicolas Bouhet"
            };

            ActionSecurite action2 = new ActionSecurite()
            {
                FicheSecurite = FicheSecurite1,
                Code = "STUV",
                Description = "Les racks serveurs ont été renforcés",
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
                    Description = "Règles non respectées",
                    FicheSecurite = FicheSecurite1
                };

                CauseQSE Cause3 = new CauseQSE()
                {
                    Description = "Port d'une protection non respecté",
                    FicheSecurite = FicheSecurite2
                };

                CauseQSE Cause4 = new CauseQSE()
                {
                    Description = "Remplacement de l'opérateur habituel à la volée",
                    FicheSecurite = FicheSecurite2
                };

            context.Causes.Add(Cause1);
            context.Causes.Add(Cause2);
            context.Causes.Add(Cause3);
            context.Causes.Add(Cause4);

            ActionQSE Action1 = new ActionQSE()
            {
                Description = "Prévoir une nouvelle formation cariste",
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
