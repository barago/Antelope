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

            ServiceType ServiceType1 = new ServiceType() { Nom = "Production" };
            ServiceType ServiceType2 = new ServiceType() { Nom = "Maintenance/TN" };
            ServiceType ServiceType3 = new ServiceType() { Nom = "Qualité" };
            ServiceType ServiceType4 = new ServiceType() { Nom = "Sécurité/Environnement" };
            ServiceType ServiceType5 = new ServiceType() { Nom = "Amélioration continue" };
            ServiceType ServiceType6 = new ServiceType() { Nom = "Ressources humaines" };
            ServiceType ServiceType7 = new ServiceType() { Nom = "Supply chain" };
            ServiceType ServiceType8 = new ServiceType() { Nom = "Master data" };
            ServiceType ServiceType9 = new ServiceType() { Nom = "Logistique" };
            ServiceType ServiceType10 = new ServiceType() { Nom = "Appro/ordo" };
            ServiceType ServiceType11 = new ServiceType() { Nom = "Qualité" };
            ServiceType ServiceType12 = new ServiceType() { Nom = "Comptabilité" };
            ServiceType ServiceType13 = new ServiceType() { Nom = "Standard" };
            ServiceType ServiceType14 = new ServiceType() { Nom = "Recherche et développement" };
            ServiceType ServiceType15 = new ServiceType() { Nom = "Communication" };
            ServiceType ServiceType16 = new ServiceType() { Nom = "Service client" };
            ServiceType ServiceType17 = new ServiceType() { Nom = "Packaging" };
            ServiceType ServiceType18 = new ServiceType() { Nom = "Informatique" };

            context.ServiceTypes.Add(ServiceType1);
            context.ServiceTypes.Add(ServiceType2);
            context.ServiceTypes.Add(ServiceType3);
            context.ServiceTypes.Add(ServiceType4);
            context.ServiceTypes.Add(ServiceType5);
            context.ServiceTypes.Add(ServiceType6);
            context.ServiceTypes.Add(ServiceType7);
            context.ServiceTypes.Add(ServiceType8);
            context.ServiceTypes.Add(ServiceType9);
            context.ServiceTypes.Add(ServiceType10);
            context.ServiceTypes.Add(ServiceType11);
            context.ServiceTypes.Add(ServiceType12);
            context.ServiceTypes.Add(ServiceType13);
            context.ServiceTypes.Add(ServiceType14);
            context.ServiceTypes.Add(ServiceType15);
            context.ServiceTypes.Add(ServiceType16);
            context.ServiceTypes.Add(ServiceType17);
            context.ServiceTypes.Add(ServiceType18);


            //------------------AJOUT DES SERVICES POUR CHAQUE SITE----------------------------

            // -------------------------RFS---------------------------------------------

            Service ServiceRFS1 = new Service() { Site = siteRFS, ServiceType = ServiceType3 };
            Service ServiceRFS2 = new Service() { Site = siteRFS, ServiceType = ServiceType4 };
            Service ServiceRFS3 = new Service() { Site = siteRFS, ServiceType = ServiceType6 };
            Service ServiceRFS4 = new Service() { Site = siteRFS, ServiceType = ServiceType8 };
            Service ServiceRFS5 = new Service() { Site = siteRFS, ServiceType = ServiceType9 };
            Service ServiceRFS6 = new Service() { Site = siteRFS, ServiceType = ServiceType10 };
            Service ServiceRFS7 = new Service() { Site = siteRFS, ServiceType = ServiceType11 };
            Service ServiceRFS8 = new Service() { Site = siteRFS, ServiceType = ServiceType12 };
            Service ServiceRFS9 = new Service() { Site = siteRFS, ServiceType = ServiceType13 };
            Service ServiceRFS10 = new Service() { Site = siteRFS, ServiceType = ServiceType14 };
            Service ServiceRFS11 = new Service() { Site = siteRFS, ServiceType = ServiceType15 };
            Service ServiceRFS12 = new Service() { Site = siteRFS, ServiceType = ServiceType16 };
            Service ServiceRFS13 = new Service() { Site = siteRFS, ServiceType = ServiceType17 };
            Service ServiceRFS14 = new Service() { Site = siteRFS, ServiceType = ServiceType18 };

            context.Services.Add(ServiceRFS1);
            context.Services.Add(ServiceRFS2);
            context.Services.Add(ServiceRFS3);
            context.Services.Add(ServiceRFS4);
            context.Services.Add(ServiceRFS5);
            context.Services.Add(ServiceRFS6);
            context.Services.Add(ServiceRFS7);
            context.Services.Add(ServiceRFS8);
            context.Services.Add(ServiceRFS9);
            context.Services.Add(ServiceRFS10);
            context.Services.Add(ServiceRFS11);
            context.Services.Add(ServiceRFS12);
            context.Services.Add(ServiceRFS13);
            context.Services.Add(ServiceRFS14);

            // -------------------------DLF---------------------------------------------

            Service ServiceDLF1 = new Service() { Site = siteDLF, ServiceType = ServiceType1 };
            Service ServiceDLF2 = new Service() { Site = siteDLF, ServiceType = ServiceType2 };
            Service ServiceDLF3 = new Service() { Site = siteDLF, ServiceType = ServiceType3 };
            Service ServiceDLF4 = new Service() { Site = siteDLF, ServiceType = ServiceType4 };
            Service ServiceDLF5 = new Service() { Site = siteDLF, ServiceType = ServiceType5 };
            Service ServiceDLF6 = new Service() { Site = siteDLF, ServiceType = ServiceType6 };
            Service ServiceDLF7 = new Service() { Site = siteDLF, ServiceType = ServiceType7 };

            context.Services.Add(ServiceDLF1);
            context.Services.Add(ServiceDLF2);
            context.Services.Add(ServiceDLF3);
            context.Services.Add(ServiceDLF4);
            context.Services.Add(ServiceDLF5);
            context.Services.Add(ServiceDLF6);
            context.Services.Add(ServiceDLF7);


            // -------------------------STA---------------------------------------------

            Service ServiceSTA1 = new Service() { Site = siteSTA, ServiceType = ServiceType1 };
            Service ServiceSTA2 = new Service() { Site = siteSTA, ServiceType = ServiceType2 };
            Service ServiceSTA3 = new Service() { Site = siteSTA, ServiceType = ServiceType3 };
            Service ServiceSTA4 = new Service() { Site = siteSTA, ServiceType = ServiceType4 };
            Service ServiceSTA5 = new Service() { Site = siteSTA, ServiceType = ServiceType5 };
            Service ServiceSTA6 = new Service() { Site = siteSTA, ServiceType = ServiceType6 };
            Service ServiceSTA7 = new Service() { Site = siteSTA, ServiceType = ServiceType7 };

            context.Services.Add(ServiceSTA1);
            context.Services.Add(ServiceSTA2);
            context.Services.Add(ServiceSTA3);
            context.Services.Add(ServiceSTA4);
            context.Services.Add(ServiceSTA5);
            context.Services.Add(ServiceSTA6);
            context.Services.Add(ServiceSTA7);

            // -------------------------NSG---------------------------------------------

            Service ServiceNSG1 = new Service() { Site = siteNSG, ServiceType = ServiceType1 };
            Service ServiceNSG2 = new Service() { Site = siteNSG, ServiceType = ServiceType2 };
            Service ServiceNSG3 = new Service() { Site = siteNSG, ServiceType = ServiceType3 };
            Service ServiceNSG4 = new Service() { Site = siteNSG, ServiceType = ServiceType4 };
            Service ServiceNSG5 = new Service() { Site = siteNSG, ServiceType = ServiceType5 };
            Service ServiceNSG6 = new Service() { Site = siteNSG, ServiceType = ServiceType6 };
            Service ServiceNSG7 = new Service() { Site = siteNSG, ServiceType = ServiceType7 };

            context.Services.Add(ServiceNSG1);
            context.Services.Add(ServiceNSG2);
            context.Services.Add(ServiceNSG3);
            context.Services.Add(ServiceNSG4);
            context.Services.Add(ServiceNSG5);
            context.Services.Add(ServiceNSG6);
            context.Services.Add(ServiceNSG7);

            // -------------------------LQN---------------------------------------------

            Service ServiceLQN1 = new Service() { Site = siteLQN, ServiceType = ServiceType1 };
            Service ServiceLQN2 = new Service() { Site = siteLQN, ServiceType = ServiceType2 };
            Service ServiceLQN3 = new Service() { Site = siteLQN, ServiceType = ServiceType3 };
            Service ServiceLQN4 = new Service() { Site = siteLQN, ServiceType = ServiceType4 };
            Service ServiceLQN5 = new Service() { Site = siteLQN, ServiceType = ServiceType5 };
            Service ServiceLQN6 = new Service() { Site = siteLQN, ServiceType = ServiceType6 };
            Service ServiceLQN7 = new Service() { Site = siteLQN, ServiceType = ServiceType7 };

            context.Services.Add(ServiceLQN1);
            context.Services.Add(ServiceLQN2);
            context.Services.Add(ServiceLQN3);
            context.Services.Add(ServiceLQN4);
            context.Services.Add(ServiceLQN5);
            context.Services.Add(ServiceLQN6);
            context.Services.Add(ServiceLQN7);






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


            //------------------------POSTE DE TRAVAIL TYPES-----------------------------


            PosteDeTravailType PosteDeTravailType1 = new PosteDeTravailType() { Nom = "Pilote process" };               
            PosteDeTravailType PosteDeTravailType2 = new PosteDeTravailType() { Nom = "Opérateur salle blanche" };
            PosteDeTravailType PosteDeTravailType3 = new PosteDeTravailType() { Nom = "Souffleur" };
            PosteDeTravailType PosteDeTravailType4 = new PosteDeTravailType() { Nom = "Polyvalent process" };
            PosteDeTravailType PosteDeTravailType5 = new PosteDeTravailType() { Nom = "Polyvalent conditionnement" };
            PosteDeTravailType PosteDeTravailType6 = new PosteDeTravailType() { Nom = "Pilote R3" };
            PosteDeTravailType PosteDeTravailType7 = new PosteDeTravailType() { Nom = "Pilote R4" };
            PosteDeTravailType PosteDeTravailType8 = new PosteDeTravailType() { Nom = "Régleur" };
            PosteDeTravailType PosteDeTravailType9 = new PosteDeTravailType() { Nom = "Etiqueteur 1, 2, 3" };
            PosteDeTravailType PosteDeTravailType10 = new PosteDeTravailType() { Nom = "Etiqueteur 4" };
            PosteDeTravailType PosteDeTravailType11 = new PosteDeTravailType() { Nom = "Fardeleur 1, 2, 3" };
            PosteDeTravailType PosteDeTravailType12 = new PosteDeTravailType() { Nom = "Fardeleur 4" };
            PosteDeTravailType PosteDeTravailType13 = new PosteDeTravailType() { Nom = "Etiqueteur 5" };
            PosteDeTravailType PosteDeTravailType14 = new PosteDeTravailType() { Nom = "Pilote combi" };
            PosteDeTravailType PosteDeTravailType15 = new PosteDeTravailType() { Nom = "Bout de ligne" };
            PosteDeTravailType PosteDeTravailType16 = new PosteDeTravailType() { Nom = "Polyvalent conditionnement" };
            PosteDeTravailType PosteDeTravailType17 = new PosteDeTravailType() { Nom = "Responsable d'équipe" };
            PosteDeTravailType PosteDeTravailType18 = new PosteDeTravailType() { Nom = "Responsable production" };
            PosteDeTravailType PosteDeTravailType19 = new PosteDeTravailType() { Nom = "Electroposté" };
            PosteDeTravailType PosteDeTravailType20 = new PosteDeTravailType() { Nom = "Technicien de maintenance" };
            PosteDeTravailType PosteDeTravailType21 = new PosteDeTravailType() { Nom = "Maitrise maintenance" };
            PosteDeTravailType PosteDeTravailType22 = new PosteDeTravailType() { Nom = "Responsable maintenance/TN" };
            PosteDeTravailType PosteDeTravailType23 = new PosteDeTravailType() { Nom = "Laborantin process" };
            PosteDeTravailType PosteDeTravailType24 = new PosteDeTravailType() { Nom = "Laborantin microbio" };
            PosteDeTravailType PosteDeTravailType25 = new PosteDeTravailType() { Nom = "Responsable labo microbio" };
            PosteDeTravailType PosteDeTravailType26 = new PosteDeTravailType() { Nom = "Responsable qualité" };
            PosteDeTravailType PosteDeTravailType27 = new PosteDeTravailType() { Nom = "Assistant qualité" };
            PosteDeTravailType PosteDeTravailType55 = new PosteDeTravailType() { Nom = "Pilote prépa" };
            PosteDeTravailType PosteDeTravailType28 = new PosteDeTravailType() { Nom = "Préparateur" };
            PosteDeTravailType PosteDeTravailType29 = new PosteDeTravailType() { Nom = "Aide préparateur" };
            PosteDeTravailType PosteDeTravailType30 = new PosteDeTravailType() { Nom = "Opérateur crusher" };
            PosteDeTravailType PosteDeTravailType31 = new PosteDeTravailType() { Nom = "Responsable préparation" };
            PosteDeTravailType PosteDeTravailType32 = new PosteDeTravailType() { Nom = "Technicien services généraux" };
            PosteDeTravailType PosteDeTravailType33 = new PosteDeTravailType() { Nom = "Directeur Site" };
            PosteDeTravailType PosteDeTravailType34 = new PosteDeTravailType() { Nom = "Personnel administratif" };
            PosteDeTravailType PosteDeTravailType35 = new PosteDeTravailType() { Nom = "Responsable zone process" };
            PosteDeTravailType PosteDeTravailType36 = new PosteDeTravailType() { Nom = "Responsable zone conditionnement" };
            PosteDeTravailType PosteDeTravailType37 = new PosteDeTravailType() { Nom = "Animateur S/E" };
            PosteDeTravailType PosteDeTravailType38 = new PosteDeTravailType() { Nom = "Agriculteur" };
            PosteDeTravailType PosteDeTravailType39 = new PosteDeTravailType() { Nom = "Chauffeur" };
            PosteDeTravailType PosteDeTravailType40 = new PosteDeTravailType() { Nom = "CHSCT" };
            PosteDeTravailType PosteDeTravailType41 = new PosteDeTravailType() { Nom = "Responsable RH" };
            PosteDeTravailType PosteDeTravailType42 = new PosteDeTravailType() { Nom = "Responsable amélioration continue" };
            PosteDeTravailType PosteDeTravailType43 = new PosteDeTravailType() { Nom = "Cariste de ligne" };
            PosteDeTravailType PosteDeTravailType44 = new PosteDeTravailType() { Nom = "Cariste expédition" };
            PosteDeTravailType PosteDeTravailType45 = new PosteDeTravailType() { Nom = "Magasinier MP" };
            PosteDeTravailType PosteDeTravailType46 = new PosteDeTravailType() { Nom = "Magasinier soufflage" };
            PosteDeTravailType PosteDeTravailType47 = new PosteDeTravailType() { Nom = "Magasinier soufflerie" };
            PosteDeTravailType PosteDeTravailType48 = new PosteDeTravailType() { Nom = "Chef d'équipe cariste" };
            PosteDeTravailType PosteDeTravailType49 = new PosteDeTravailType() { Nom = "Responsable d'exploitation PF" };
            PosteDeTravailType PosteDeTravailType50 = new PosteDeTravailType() { Nom = "Responsable d'exploitation MP" };
            PosteDeTravailType PosteDeTravailType51 = new PosteDeTravailType() { Nom = "Gestionnaire de stock" };
            PosteDeTravailType PosteDeTravailType52 = new PosteDeTravailType() { Nom = "Hôtesse d'accueil PF" };
            PosteDeTravailType PosteDeTravailType53 = new PosteDeTravailType() { Nom = "Responsable appro/ordo" };
            PosteDeTravailType PosteDeTravailType54 = new PosteDeTravailType() { Nom = "Responsable supply Chain" };



            context.PosteDeTravailTypes.Add(PosteDeTravailType1);
            context.PosteDeTravailTypes.Add(PosteDeTravailType2);
            context.PosteDeTravailTypes.Add(PosteDeTravailType3);
            context.PosteDeTravailTypes.Add(PosteDeTravailType4);
            context.PosteDeTravailTypes.Add(PosteDeTravailType5);
            context.PosteDeTravailTypes.Add(PosteDeTravailType6);
            context.PosteDeTravailTypes.Add(PosteDeTravailType7);
            context.PosteDeTravailTypes.Add(PosteDeTravailType8);
            context.PosteDeTravailTypes.Add(PosteDeTravailType9);
            context.PosteDeTravailTypes.Add(PosteDeTravailType10);
            context.PosteDeTravailTypes.Add(PosteDeTravailType11);
            context.PosteDeTravailTypes.Add(PosteDeTravailType12);
            context.PosteDeTravailTypes.Add(PosteDeTravailType13);
            context.PosteDeTravailTypes.Add(PosteDeTravailType14);
            context.PosteDeTravailTypes.Add(PosteDeTravailType15);
            context.PosteDeTravailTypes.Add(PosteDeTravailType16);
            context.PosteDeTravailTypes.Add(PosteDeTravailType17);
            context.PosteDeTravailTypes.Add(PosteDeTravailType18);
            context.PosteDeTravailTypes.Add(PosteDeTravailType19);
            context.PosteDeTravailTypes.Add(PosteDeTravailType20);
            context.PosteDeTravailTypes.Add(PosteDeTravailType21);
            context.PosteDeTravailTypes.Add(PosteDeTravailType22);
            context.PosteDeTravailTypes.Add(PosteDeTravailType23);
            context.PosteDeTravailTypes.Add(PosteDeTravailType24);
            context.PosteDeTravailTypes.Add(PosteDeTravailType25);
            context.PosteDeTravailTypes.Add(PosteDeTravailType26);
            context.PosteDeTravailTypes.Add(PosteDeTravailType27);
            context.PosteDeTravailTypes.Add(PosteDeTravailType28);
            context.PosteDeTravailTypes.Add(PosteDeTravailType29);
            context.PosteDeTravailTypes.Add(PosteDeTravailType30);
            context.PosteDeTravailTypes.Add(PosteDeTravailType31);
            context.PosteDeTravailTypes.Add(PosteDeTravailType32);
            context.PosteDeTravailTypes.Add(PosteDeTravailType33);
            context.PosteDeTravailTypes.Add(PosteDeTravailType34);
            context.PosteDeTravailTypes.Add(PosteDeTravailType35);
            context.PosteDeTravailTypes.Add(PosteDeTravailType36);
            context.PosteDeTravailTypes.Add(PosteDeTravailType37);
            context.PosteDeTravailTypes.Add(PosteDeTravailType38);
            context.PosteDeTravailTypes.Add(PosteDeTravailType39);
            context.PosteDeTravailTypes.Add(PosteDeTravailType40);
            context.PosteDeTravailTypes.Add(PosteDeTravailType41);
            context.PosteDeTravailTypes.Add(PosteDeTravailType42);
            context.PosteDeTravailTypes.Add(PosteDeTravailType43);
            context.PosteDeTravailTypes.Add(PosteDeTravailType44);
            context.PosteDeTravailTypes.Add(PosteDeTravailType45);
            context.PosteDeTravailTypes.Add(PosteDeTravailType46);
            context.PosteDeTravailTypes.Add(PosteDeTravailType47);
            context.PosteDeTravailTypes.Add(PosteDeTravailType48);
            context.PosteDeTravailTypes.Add(PosteDeTravailType49);
            context.PosteDeTravailTypes.Add(PosteDeTravailType50);
            context.PosteDeTravailTypes.Add(PosteDeTravailType51);
            context.PosteDeTravailTypes.Add(PosteDeTravailType52);
            context.PosteDeTravailTypes.Add(PosteDeTravailType53);
            context.PosteDeTravailTypes.Add(PosteDeTravailType54);
            context.PosteDeTravailTypes.Add(PosteDeTravailType55);


            // -------------------------DLF---------------------------------------------

            PosteDeTravail PosteDeTravailDLFZone3_1 = new PosteDeTravail() { Zone = ZoneDLF3, PosteDeTravailType = PosteDeTravailType1 };
            PosteDeTravail PosteDeTravailDLFZone3_2 = new PosteDeTravail() { Zone = ZoneDLF3, PosteDeTravailType = PosteDeTravailType2 };
            PosteDeTravail PosteDeTravailDLFZone3_3 = new PosteDeTravail() { Zone = ZoneDLF3, PosteDeTravailType = PosteDeTravailType3 };
            PosteDeTravail PosteDeTravailDLFZone3_4 = new PosteDeTravail() { Zone = ZoneDLF3, PosteDeTravailType = PosteDeTravailType4 };
            PosteDeTravail PosteDeTravailDLFZone3_5 = new PosteDeTravail() { Zone = ZoneDLF3, PosteDeTravailType = PosteDeTravailType5 };
            PosteDeTravail PosteDeTravailDLFZone3_6 = new PosteDeTravail() { Zone = ZoneDLF3, PosteDeTravailType = PosteDeTravailType6 };
            PosteDeTravail PosteDeTravailDLFZone3_7 = new PosteDeTravail() { Zone = ZoneDLF3, PosteDeTravailType = PosteDeTravailType7 };
            PosteDeTravail PosteDeTravailDLFZone3_8 = new PosteDeTravail() { Zone = ZoneDLF3, PosteDeTravailType = PosteDeTravailType8 };

            PosteDeTravail PosteDeTravailDLFZone4_1 = new PosteDeTravail() { Zone = ZoneDLF4, PosteDeTravailType = PosteDeTravailType9 };
            PosteDeTravail PosteDeTravailDLFZone4_2 = new PosteDeTravail() { Zone = ZoneDLF4, PosteDeTravailType = PosteDeTravailType10 };
            PosteDeTravail PosteDeTravailDLFZone4_3 = new PosteDeTravail() { Zone = ZoneDLF4, PosteDeTravailType = PosteDeTravailType11 };
            PosteDeTravail PosteDeTravailDLFZone4_4 = new PosteDeTravail() { Zone = ZoneDLF4, PosteDeTravailType = PosteDeTravailType12 };
            PosteDeTravail PosteDeTravailDLFZone4_5 = new PosteDeTravail() { Zone = ZoneDLF4, PosteDeTravailType = PosteDeTravailType13 };
            PosteDeTravail PosteDeTravailDLFZone4_6 = new PosteDeTravail() { Zone = ZoneDLF4, PosteDeTravailType = PosteDeTravailType14 };
            PosteDeTravail PosteDeTravailDLFZone4_7 = new PosteDeTravail() { Zone = ZoneDLF4, PosteDeTravailType = PosteDeTravailType15 };
            PosteDeTravail PosteDeTravailDLFZone4_8 = new PosteDeTravail() { Zone = ZoneDLF4, PosteDeTravailType = PosteDeTravailType16 };
            PosteDeTravail PosteDeTravailDLFZone4_9 = new PosteDeTravail() { Zone = ZoneDLF4, PosteDeTravailType = PosteDeTravailType17 };
            PosteDeTravail PosteDeTravailDLFZone4_10 = new PosteDeTravail() { Zone = ZoneDLF4, PosteDeTravailType = PosteDeTravailType18 };

            PosteDeTravail PosteDeTravailDLFZone5_0 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType43 };
            PosteDeTravail PosteDeTravailDLFZone5_1 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType44 };
            PosteDeTravail PosteDeTravailDLFZone5_2 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType45 };
            PosteDeTravail PosteDeTravailDLFZone5_3 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType46 };
            PosteDeTravail PosteDeTravailDLFZone5_4 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType47 };
            PosteDeTravail PosteDeTravailDLFZone5_5 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType48 };
            PosteDeTravail PosteDeTravailDLFZone5_6 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType49 };
            PosteDeTravail PosteDeTravailDLFZone5_7 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType50 };
            PosteDeTravail PosteDeTravailDLFZone5_8 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType51 };
            PosteDeTravail PosteDeTravailDLFZone5_9 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType52 };
            PosteDeTravail PosteDeTravailDLFZone5_10 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType53 };
            PosteDeTravail PosteDeTravailDLFZone5_11 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType54 };
            PosteDeTravail PosteDeTravailDLFZone5_12 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType55 };
            PosteDeTravail PosteDeTravailDLFZone5_13 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType28 };
            PosteDeTravail PosteDeTravailDLFZone5_14 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType29 };
            PosteDeTravail PosteDeTravailDLFZone5_15 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType30 };
            PosteDeTravail PosteDeTravailDLFZone5_16 = new PosteDeTravail() { Zone = ZoneDLF5, PosteDeTravailType = PosteDeTravailType31 };

            PosteDeTravail PosteDeTravailDLFZone6_1 = new PosteDeTravail() { Zone = ZoneDLF6, PosteDeTravailType = PosteDeTravailType19 };
            PosteDeTravail PosteDeTravailDLFZone6_2 = new PosteDeTravail() { Zone = ZoneDLF6, PosteDeTravailType = PosteDeTravailType20 };
            PosteDeTravail PosteDeTravailDLFZone6_3 = new PosteDeTravail() { Zone = ZoneDLF6, PosteDeTravailType = PosteDeTravailType21 };
            PosteDeTravail PosteDeTravailDLFZone6_4 = new PosteDeTravail() { Zone = ZoneDLF6, PosteDeTravailType = PosteDeTravailType22 };

            PosteDeTravail PosteDeTravailDLFZone7_1 = new PosteDeTravail() { Zone = ZoneDLF7, PosteDeTravailType = PosteDeTravailType23 };
            PosteDeTravail PosteDeTravailDLFZone7_2 = new PosteDeTravail() { Zone = ZoneDLF7, PosteDeTravailType = PosteDeTravailType24 };
            PosteDeTravail PosteDeTravailDLFZone7_3 = new PosteDeTravail() { Zone = ZoneDLF7, PosteDeTravailType = PosteDeTravailType25 };
            PosteDeTravail PosteDeTravailDLFZone7_4 = new PosteDeTravail() { Zone = ZoneDLF7, PosteDeTravailType = PosteDeTravailType26 };
            PosteDeTravail PosteDeTravailDLFZone7_5 = new PosteDeTravail() { Zone = ZoneDLF7, PosteDeTravailType = PosteDeTravailType27 };

            PosteDeTravail PosteDeTravailDLFZone9_1 = new PosteDeTravail() { Zone = ZoneDLF9, PosteDeTravailType = PosteDeTravailType32 };
            PosteDeTravail PosteDeTravailDLFZone9_2 = new PosteDeTravail() { Zone = ZoneDLF9, PosteDeTravailType = PosteDeTravailType33 };
            PosteDeTravail PosteDeTravailDLFZone9_3 = new PosteDeTravail() { Zone = ZoneDLF9, PosteDeTravailType = PosteDeTravailType34 };
            PosteDeTravail PosteDeTravailDLFZone9_4 = new PosteDeTravail() { Zone = ZoneDLF9, PosteDeTravailType = PosteDeTravailType35 };
            PosteDeTravail PosteDeTravailDLFZone9_5 = new PosteDeTravail() { Zone = ZoneDLF9, PosteDeTravailType = PosteDeTravailType36 };
            PosteDeTravail PosteDeTravailDLFZone9_6 = new PosteDeTravail() { Zone = ZoneDLF9, PosteDeTravailType = PosteDeTravailType37 };
            PosteDeTravail PosteDeTravailDLFZone9_7 = new PosteDeTravail() { Zone = ZoneDLF9, PosteDeTravailType = PosteDeTravailType38 };
            PosteDeTravail PosteDeTravailDLFZone9_8 = new PosteDeTravail() { Zone = ZoneDLF9, PosteDeTravailType = PosteDeTravailType39 };
            PosteDeTravail PosteDeTravailDLFZone9_9 = new PosteDeTravail() { Zone = ZoneDLF9, PosteDeTravailType = PosteDeTravailType40 };
            PosteDeTravail PosteDeTravailDLFZone9_10 = new PosteDeTravail() { Zone = ZoneDLF9, PosteDeTravailType = PosteDeTravailType41 };
            PosteDeTravail PosteDeTravailDLFZone9_11 = new PosteDeTravail() { Zone = ZoneDLF9, PosteDeTravailType = PosteDeTravailType42 };


             context.PosteDeTravails.Add(PosteDeTravailDLFZone3_1);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone3_2);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone3_3);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone3_4);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone3_5);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone3_6);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone3_7);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone3_8);

             context.PosteDeTravails.Add(PosteDeTravailDLFZone4_1);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone4_2);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone4_3);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone4_4);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone4_5);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone4_6);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone4_7);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone4_8);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone4_9);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone4_10);

             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_0);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_1);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_2);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_3);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_4);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_5);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_6);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_7);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_8);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_9);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_10);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_11);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_12);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_13);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_14);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_15);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone5_16);

             context.PosteDeTravails.Add(PosteDeTravailDLFZone6_1);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone6_2);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone6_3);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone6_4);

             context.PosteDeTravails.Add(PosteDeTravailDLFZone7_1);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone7_2);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone7_3);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone7_4);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone7_5);

             context.PosteDeTravails.Add(PosteDeTravailDLFZone9_1);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone9_2);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone9_3);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone9_4);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone9_5);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone9_6);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone9_7);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone9_8);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone9_9);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone9_10);
             context.PosteDeTravails.Add(PosteDeTravailDLFZone9_11);

             // -------------------------STA---------------------------------------------

             PosteDeTravail PosteDeTravailSTAZone3_1 = new PosteDeTravail() { Zone = ZoneSTA3, PosteDeTravailType = PosteDeTravailType1 };
             PosteDeTravail PosteDeTravailSTAZone3_2 = new PosteDeTravail() { Zone = ZoneSTA3, PosteDeTravailType = PosteDeTravailType2 };
             PosteDeTravail PosteDeTravailSTAZone3_3 = new PosteDeTravail() { Zone = ZoneSTA3, PosteDeTravailType = PosteDeTravailType3 };
             PosteDeTravail PosteDeTravailSTAZone3_4 = new PosteDeTravail() { Zone = ZoneSTA3, PosteDeTravailType = PosteDeTravailType4 };
             PosteDeTravail PosteDeTravailSTAZone3_5 = new PosteDeTravail() { Zone = ZoneSTA3, PosteDeTravailType = PosteDeTravailType5 };
             PosteDeTravail PosteDeTravailSTAZone3_6 = new PosteDeTravail() { Zone = ZoneSTA3, PosteDeTravailType = PosteDeTravailType6 };
             PosteDeTravail PosteDeTravailSTAZone3_7 = new PosteDeTravail() { Zone = ZoneSTA3, PosteDeTravailType = PosteDeTravailType7 };
             PosteDeTravail PosteDeTravailSTAZone3_8 = new PosteDeTravail() { Zone = ZoneSTA3, PosteDeTravailType = PosteDeTravailType8 };

             PosteDeTravail PosteDeTravailSTAZone4_1 = new PosteDeTravail() { Zone = ZoneSTA4, PosteDeTravailType = PosteDeTravailType9 };
             PosteDeTravail PosteDeTravailSTAZone4_2 = new PosteDeTravail() { Zone = ZoneSTA4, PosteDeTravailType = PosteDeTravailType10 };
             PosteDeTravail PosteDeTravailSTAZone4_3 = new PosteDeTravail() { Zone = ZoneSTA4, PosteDeTravailType = PosteDeTravailType11 };
             PosteDeTravail PosteDeTravailSTAZone4_4 = new PosteDeTravail() { Zone = ZoneSTA4, PosteDeTravailType = PosteDeTravailType12 };
             PosteDeTravail PosteDeTravailSTAZone4_5 = new PosteDeTravail() { Zone = ZoneSTA4, PosteDeTravailType = PosteDeTravailType13 };
             PosteDeTravail PosteDeTravailSTAZone4_6 = new PosteDeTravail() { Zone = ZoneSTA4, PosteDeTravailType = PosteDeTravailType14 };
             PosteDeTravail PosteDeTravailSTAZone4_7 = new PosteDeTravail() { Zone = ZoneSTA4, PosteDeTravailType = PosteDeTravailType15 };
             PosteDeTravail PosteDeTravailSTAZone4_8 = new PosteDeTravail() { Zone = ZoneSTA4, PosteDeTravailType = PosteDeTravailType16 };
             PosteDeTravail PosteDeTravailSTAZone4_9 = new PosteDeTravail() { Zone = ZoneSTA4, PosteDeTravailType = PosteDeTravailType17 };
             PosteDeTravail PosteDeTravailSTAZone4_10 = new PosteDeTravail() { Zone = ZoneSTA4, PosteDeTravailType = PosteDeTravailType18 };

             PosteDeTravail PosteDeTravailSTAZone5_0 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType43 };
             PosteDeTravail PosteDeTravailSTAZone5_1 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType44 };
             PosteDeTravail PosteDeTravailSTAZone5_2 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType45 };
             PosteDeTravail PosteDeTravailSTAZone5_3 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType46 };
             PosteDeTravail PosteDeTravailSTAZone5_4 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType47 };
             PosteDeTravail PosteDeTravailSTAZone5_5 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType48 };
             PosteDeTravail PosteDeTravailSTAZone5_6 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType49 };
             PosteDeTravail PosteDeTravailSTAZone5_7 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType50 };
             PosteDeTravail PosteDeTravailSTAZone5_8 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType51 };
             PosteDeTravail PosteDeTravailSTAZone5_9 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType52 };
             PosteDeTravail PosteDeTravailSTAZone5_10 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType53 };
             PosteDeTravail PosteDeTravailSTAZone5_11 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType54 };
             PosteDeTravail PosteDeTravailSTAZone5_12 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType55 };
             PosteDeTravail PosteDeTravailSTAZone5_13 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType28 };
             PosteDeTravail PosteDeTravailSTAZone5_14 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType29 };
             PosteDeTravail PosteDeTravailSTAZone5_15 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType30 };
             PosteDeTravail PosteDeTravailSTAZone5_16 = new PosteDeTravail() { Zone = ZoneSTA5, PosteDeTravailType = PosteDeTravailType31 };

             PosteDeTravail PosteDeTravailSTAZone6_1 = new PosteDeTravail() { Zone = ZoneSTA6, PosteDeTravailType = PosteDeTravailType19 };
             PosteDeTravail PosteDeTravailSTAZone6_2 = new PosteDeTravail() { Zone = ZoneSTA6, PosteDeTravailType = PosteDeTravailType20 };
             PosteDeTravail PosteDeTravailSTAZone6_3 = new PosteDeTravail() { Zone = ZoneSTA6, PosteDeTravailType = PosteDeTravailType21 };
             PosteDeTravail PosteDeTravailSTAZone6_4 = new PosteDeTravail() { Zone = ZoneSTA6, PosteDeTravailType = PosteDeTravailType22 };

             PosteDeTravail PosteDeTravailSTAZone7_1 = new PosteDeTravail() { Zone = ZoneSTA7, PosteDeTravailType = PosteDeTravailType23 };
             PosteDeTravail PosteDeTravailSTAZone7_2 = new PosteDeTravail() { Zone = ZoneSTA7, PosteDeTravailType = PosteDeTravailType24 };
             PosteDeTravail PosteDeTravailSTAZone7_3 = new PosteDeTravail() { Zone = ZoneSTA7, PosteDeTravailType = PosteDeTravailType25 };
             PosteDeTravail PosteDeTravailSTAZone7_4 = new PosteDeTravail() { Zone = ZoneSTA7, PosteDeTravailType = PosteDeTravailType26 };
             PosteDeTravail PosteDeTravailSTAZone7_5 = new PosteDeTravail() { Zone = ZoneSTA7, PosteDeTravailType = PosteDeTravailType27 };

             PosteDeTravail PosteDeTravailSTAZone9_1 = new PosteDeTravail() { Zone = ZoneSTA9, PosteDeTravailType = PosteDeTravailType32 };
             PosteDeTravail PosteDeTravailSTAZone9_2 = new PosteDeTravail() { Zone = ZoneSTA9, PosteDeTravailType = PosteDeTravailType33 };
             PosteDeTravail PosteDeTravailSTAZone9_3 = new PosteDeTravail() { Zone = ZoneSTA9, PosteDeTravailType = PosteDeTravailType34 };
             PosteDeTravail PosteDeTravailSTAZone9_4 = new PosteDeTravail() { Zone = ZoneSTA9, PosteDeTravailType = PosteDeTravailType35 };
             PosteDeTravail PosteDeTravailSTAZone9_5 = new PosteDeTravail() { Zone = ZoneSTA9, PosteDeTravailType = PosteDeTravailType36 };
             PosteDeTravail PosteDeTravailSTAZone9_6 = new PosteDeTravail() { Zone = ZoneSTA9, PosteDeTravailType = PosteDeTravailType37 };
             PosteDeTravail PosteDeTravailSTAZone9_7 = new PosteDeTravail() { Zone = ZoneSTA9, PosteDeTravailType = PosteDeTravailType38 };
             PosteDeTravail PosteDeTravailSTAZone9_8 = new PosteDeTravail() { Zone = ZoneSTA9, PosteDeTravailType = PosteDeTravailType39 };
             PosteDeTravail PosteDeTravailSTAZone9_9 = new PosteDeTravail() { Zone = ZoneSTA9, PosteDeTravailType = PosteDeTravailType40 };
             PosteDeTravail PosteDeTravailSTAZone9_10 = new PosteDeTravail() { Zone = ZoneSTA9, PosteDeTravailType = PosteDeTravailType41 };
             PosteDeTravail PosteDeTravailSTAZone9_11 = new PosteDeTravail() { Zone = ZoneSTA9, PosteDeTravailType = PosteDeTravailType42 };


             context.PosteDeTravails.Add(PosteDeTravailSTAZone3_1);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone3_2);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone3_3);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone3_4);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone3_5);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone3_6);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone3_7);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone3_8);

             context.PosteDeTravails.Add(PosteDeTravailSTAZone4_1);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone4_2);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone4_3);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone4_4);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone4_5);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone4_6);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone4_7);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone4_8);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone4_9);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone4_10);

             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_0);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_1);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_2);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_3);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_4);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_5);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_6);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_7);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_8);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_9);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_10);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_11);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_12);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_13);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_14);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_15);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone5_16);

             context.PosteDeTravails.Add(PosteDeTravailSTAZone6_1);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone6_2);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone6_3);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone6_4);

             context.PosteDeTravails.Add(PosteDeTravailSTAZone7_1);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone7_2);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone7_3);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone7_4);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone7_5);

             context.PosteDeTravails.Add(PosteDeTravailSTAZone9_1);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone9_2);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone9_3);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone9_4);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone9_5);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone9_6);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone9_7);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone9_8);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone9_9);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone9_10);
             context.PosteDeTravails.Add(PosteDeTravailSTAZone9_11);


             // -------------------------NSG---------------------------------------------

             PosteDeTravail PosteDeTravailNSGZone3_1 = new PosteDeTravail() { Zone = ZoneNSG3, PosteDeTravailType = PosteDeTravailType1 };
             PosteDeTravail PosteDeTravailNSGZone3_2 = new PosteDeTravail() { Zone = ZoneNSG3, PosteDeTravailType = PosteDeTravailType2 };
             PosteDeTravail PosteDeTravailNSGZone3_3 = new PosteDeTravail() { Zone = ZoneNSG3, PosteDeTravailType = PosteDeTravailType3 };
             PosteDeTravail PosteDeTravailNSGZone3_4 = new PosteDeTravail() { Zone = ZoneNSG3, PosteDeTravailType = PosteDeTravailType4 };
             PosteDeTravail PosteDeTravailNSGZone3_5 = new PosteDeTravail() { Zone = ZoneNSG3, PosteDeTravailType = PosteDeTravailType5 };
             PosteDeTravail PosteDeTravailNSGZone3_6 = new PosteDeTravail() { Zone = ZoneNSG3, PosteDeTravailType = PosteDeTravailType6 };
             PosteDeTravail PosteDeTravailNSGZone3_7 = new PosteDeTravail() { Zone = ZoneNSG3, PosteDeTravailType = PosteDeTravailType7 };
             PosteDeTravail PosteDeTravailNSGZone3_8 = new PosteDeTravail() { Zone = ZoneNSG3, PosteDeTravailType = PosteDeTravailType8 };

             PosteDeTravail PosteDeTravailNSGZone4_1 = new PosteDeTravail() { Zone = ZoneNSG4, PosteDeTravailType = PosteDeTravailType9 };
             PosteDeTravail PosteDeTravailNSGZone4_2 = new PosteDeTravail() { Zone = ZoneNSG4, PosteDeTravailType = PosteDeTravailType10 };
             PosteDeTravail PosteDeTravailNSGZone4_3 = new PosteDeTravail() { Zone = ZoneNSG4, PosteDeTravailType = PosteDeTravailType11 };
             PosteDeTravail PosteDeTravailNSGZone4_4 = new PosteDeTravail() { Zone = ZoneNSG4, PosteDeTravailType = PosteDeTravailType12 };
             PosteDeTravail PosteDeTravailNSGZone4_5 = new PosteDeTravail() { Zone = ZoneNSG4, PosteDeTravailType = PosteDeTravailType13 };
             PosteDeTravail PosteDeTravailNSGZone4_6 = new PosteDeTravail() { Zone = ZoneNSG4, PosteDeTravailType = PosteDeTravailType14 };
             PosteDeTravail PosteDeTravailNSGZone4_7 = new PosteDeTravail() { Zone = ZoneNSG4, PosteDeTravailType = PosteDeTravailType15 };
             PosteDeTravail PosteDeTravailNSGZone4_8 = new PosteDeTravail() { Zone = ZoneNSG4, PosteDeTravailType = PosteDeTravailType16 };
             PosteDeTravail PosteDeTravailNSGZone4_9 = new PosteDeTravail() { Zone = ZoneNSG4, PosteDeTravailType = PosteDeTravailType17 };
             PosteDeTravail PosteDeTravailNSGZone4_10 = new PosteDeTravail() { Zone = ZoneNSG4, PosteDeTravailType = PosteDeTravailType18 };

             PosteDeTravail PosteDeTravailNSGZone5_0 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType43 };
             PosteDeTravail PosteDeTravailNSGZone5_1 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType44 };
             PosteDeTravail PosteDeTravailNSGZone5_2 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType45 };
             PosteDeTravail PosteDeTravailNSGZone5_3 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType46 };
             PosteDeTravail PosteDeTravailNSGZone5_4 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType47 };
             PosteDeTravail PosteDeTravailNSGZone5_5 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType48 };
             PosteDeTravail PosteDeTravailNSGZone5_6 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType49 };
             PosteDeTravail PosteDeTravailNSGZone5_7 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType50 };
             PosteDeTravail PosteDeTravailNSGZone5_8 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType51 };
             PosteDeTravail PosteDeTravailNSGZone5_9 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType52 };
             PosteDeTravail PosteDeTravailNSGZone5_10 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType53 };
             PosteDeTravail PosteDeTravailNSGZone5_11 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType54 };
             PosteDeTravail PosteDeTravailNSGZone5_12 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType55 };
             PosteDeTravail PosteDeTravailNSGZone5_13 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType28 };
             PosteDeTravail PosteDeTravailNSGZone5_14 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType29 };
             PosteDeTravail PosteDeTravailNSGZone5_15 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType30 };
             PosteDeTravail PosteDeTravailNSGZone5_16 = new PosteDeTravail() { Zone = ZoneNSG5, PosteDeTravailType = PosteDeTravailType31 };

             PosteDeTravail PosteDeTravailNSGZone6_1 = new PosteDeTravail() { Zone = ZoneNSG6, PosteDeTravailType = PosteDeTravailType19 };
             PosteDeTravail PosteDeTravailNSGZone6_2 = new PosteDeTravail() { Zone = ZoneNSG6, PosteDeTravailType = PosteDeTravailType20 };
             PosteDeTravail PosteDeTravailNSGZone6_3 = new PosteDeTravail() { Zone = ZoneNSG6, PosteDeTravailType = PosteDeTravailType21 };
             PosteDeTravail PosteDeTravailNSGZone6_4 = new PosteDeTravail() { Zone = ZoneNSG6, PosteDeTravailType = PosteDeTravailType22 };

             PosteDeTravail PosteDeTravailNSGZone7_1 = new PosteDeTravail() { Zone = ZoneNSG7, PosteDeTravailType = PosteDeTravailType23 };
             PosteDeTravail PosteDeTravailNSGZone7_2 = new PosteDeTravail() { Zone = ZoneNSG7, PosteDeTravailType = PosteDeTravailType24 };
             PosteDeTravail PosteDeTravailNSGZone7_3 = new PosteDeTravail() { Zone = ZoneNSG7, PosteDeTravailType = PosteDeTravailType25 };
             PosteDeTravail PosteDeTravailNSGZone7_4 = new PosteDeTravail() { Zone = ZoneNSG7, PosteDeTravailType = PosteDeTravailType26 };
             PosteDeTravail PosteDeTravailNSGZone7_5 = new PosteDeTravail() { Zone = ZoneNSG7, PosteDeTravailType = PosteDeTravailType27 };

             PosteDeTravail PosteDeTravailNSGZone9_1 = new PosteDeTravail() { Zone = ZoneNSG9, PosteDeTravailType = PosteDeTravailType32 };
             PosteDeTravail PosteDeTravailNSGZone9_2 = new PosteDeTravail() { Zone = ZoneNSG9, PosteDeTravailType = PosteDeTravailType33 };
             PosteDeTravail PosteDeTravailNSGZone9_3 = new PosteDeTravail() { Zone = ZoneNSG9, PosteDeTravailType = PosteDeTravailType34 };
             PosteDeTravail PosteDeTravailNSGZone9_4 = new PosteDeTravail() { Zone = ZoneNSG9, PosteDeTravailType = PosteDeTravailType35 };
             PosteDeTravail PosteDeTravailNSGZone9_5 = new PosteDeTravail() { Zone = ZoneNSG9, PosteDeTravailType = PosteDeTravailType36 };
             PosteDeTravail PosteDeTravailNSGZone9_6 = new PosteDeTravail() { Zone = ZoneNSG9, PosteDeTravailType = PosteDeTravailType37 };
             PosteDeTravail PosteDeTravailNSGZone9_7 = new PosteDeTravail() { Zone = ZoneNSG9, PosteDeTravailType = PosteDeTravailType38 };
             PosteDeTravail PosteDeTravailNSGZone9_8 = new PosteDeTravail() { Zone = ZoneNSG9, PosteDeTravailType = PosteDeTravailType39 };
             PosteDeTravail PosteDeTravailNSGZone9_9 = new PosteDeTravail() { Zone = ZoneNSG9, PosteDeTravailType = PosteDeTravailType40 };
             PosteDeTravail PosteDeTravailNSGZone9_10 = new PosteDeTravail() { Zone = ZoneNSG9, PosteDeTravailType = PosteDeTravailType41 };
             PosteDeTravail PosteDeTravailNSGZone9_11 = new PosteDeTravail() { Zone = ZoneNSG9, PosteDeTravailType = PosteDeTravailType42 };


             context.PosteDeTravails.Add(PosteDeTravailNSGZone3_1);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone3_2);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone3_3);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone3_4);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone3_5);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone3_6);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone3_7);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone3_8);

             context.PosteDeTravails.Add(PosteDeTravailNSGZone4_1);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone4_2);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone4_3);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone4_4);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone4_5);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone4_6);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone4_7);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone4_8);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone4_9);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone4_10);

             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_0);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_1);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_2);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_3);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_4);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_5);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_6);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_7);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_8);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_9);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_10);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_11);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_12);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_13);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_14);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_15);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone5_16);

             context.PosteDeTravails.Add(PosteDeTravailNSGZone6_1);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone6_2);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone6_3);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone6_4);

             context.PosteDeTravails.Add(PosteDeTravailNSGZone7_1);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone7_2);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone7_3);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone7_4);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone7_5);

             context.PosteDeTravails.Add(PosteDeTravailNSGZone9_1);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone9_2);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone9_3);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone9_4);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone9_5);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone9_6);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone9_7);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone9_8);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone9_9);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone9_10);
             context.PosteDeTravails.Add(PosteDeTravailNSGZone9_11);

             // -------------------------LQN---------------------------------------------

             PosteDeTravail PosteDeTravailLQNZone3_1 = new PosteDeTravail() { Zone = ZoneLQN3, PosteDeTravailType = PosteDeTravailType1 };
             PosteDeTravail PosteDeTravailLQNZone3_2 = new PosteDeTravail() { Zone = ZoneLQN3, PosteDeTravailType = PosteDeTravailType2 };
             PosteDeTravail PosteDeTravailLQNZone3_3 = new PosteDeTravail() { Zone = ZoneLQN3, PosteDeTravailType = PosteDeTravailType3 };
             PosteDeTravail PosteDeTravailLQNZone3_4 = new PosteDeTravail() { Zone = ZoneLQN3, PosteDeTravailType = PosteDeTravailType4 };
             PosteDeTravail PosteDeTravailLQNZone3_5 = new PosteDeTravail() { Zone = ZoneLQN3, PosteDeTravailType = PosteDeTravailType5 };
             PosteDeTravail PosteDeTravailLQNZone3_6 = new PosteDeTravail() { Zone = ZoneLQN3, PosteDeTravailType = PosteDeTravailType6 };
             PosteDeTravail PosteDeTravailLQNZone3_7 = new PosteDeTravail() { Zone = ZoneLQN3, PosteDeTravailType = PosteDeTravailType7 };
             PosteDeTravail PosteDeTravailLQNZone3_8 = new PosteDeTravail() { Zone = ZoneLQN3, PosteDeTravailType = PosteDeTravailType8 };

             PosteDeTravail PosteDeTravailLQNZone4_1 = new PosteDeTravail() { Zone = ZoneLQN4, PosteDeTravailType = PosteDeTravailType9 };
             PosteDeTravail PosteDeTravailLQNZone4_2 = new PosteDeTravail() { Zone = ZoneLQN4, PosteDeTravailType = PosteDeTravailType10 };
             PosteDeTravail PosteDeTravailLQNZone4_3 = new PosteDeTravail() { Zone = ZoneLQN4, PosteDeTravailType = PosteDeTravailType11 };
             PosteDeTravail PosteDeTravailLQNZone4_4 = new PosteDeTravail() { Zone = ZoneLQN4, PosteDeTravailType = PosteDeTravailType12 };
             PosteDeTravail PosteDeTravailLQNZone4_5 = new PosteDeTravail() { Zone = ZoneLQN4, PosteDeTravailType = PosteDeTravailType13 };
             PosteDeTravail PosteDeTravailLQNZone4_6 = new PosteDeTravail() { Zone = ZoneLQN4, PosteDeTravailType = PosteDeTravailType14 };
             PosteDeTravail PosteDeTravailLQNZone4_7 = new PosteDeTravail() { Zone = ZoneLQN4, PosteDeTravailType = PosteDeTravailType15 };
             PosteDeTravail PosteDeTravailLQNZone4_8 = new PosteDeTravail() { Zone = ZoneLQN4, PosteDeTravailType = PosteDeTravailType16 };
             PosteDeTravail PosteDeTravailLQNZone4_9 = new PosteDeTravail() { Zone = ZoneLQN4, PosteDeTravailType = PosteDeTravailType17 };
             PosteDeTravail PosteDeTravailLQNZone4_10 = new PosteDeTravail() { Zone = ZoneLQN4, PosteDeTravailType = PosteDeTravailType18 };

             PosteDeTravail PosteDeTravailLQNZone5_0 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType43 };
             PosteDeTravail PosteDeTravailLQNZone5_1 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType44 };
             PosteDeTravail PosteDeTravailLQNZone5_2 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType45 };
             PosteDeTravail PosteDeTravailLQNZone5_3 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType46 };
             PosteDeTravail PosteDeTravailLQNZone5_4 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType47 };
             PosteDeTravail PosteDeTravailLQNZone5_5 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType48 };
             PosteDeTravail PosteDeTravailLQNZone5_6 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType49 };
             PosteDeTravail PosteDeTravailLQNZone5_7 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType50 };
             PosteDeTravail PosteDeTravailLQNZone5_8 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType51 };
             PosteDeTravail PosteDeTravailLQNZone5_9 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType52 };
             PosteDeTravail PosteDeTravailLQNZone5_10 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType53 };
             PosteDeTravail PosteDeTravailLQNZone5_11 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType54 };
             PosteDeTravail PosteDeTravailLQNZone5_12 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType55 };
             PosteDeTravail PosteDeTravailLQNZone5_13 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType28 };
             PosteDeTravail PosteDeTravailLQNZone5_14 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType29 };
             PosteDeTravail PosteDeTravailLQNZone5_15 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType30 };
             PosteDeTravail PosteDeTravailLQNZone5_16 = new PosteDeTravail() { Zone = ZoneLQN5, PosteDeTravailType = PosteDeTravailType31 };

             PosteDeTravail PosteDeTravailLQNZone6_1 = new PosteDeTravail() { Zone = ZoneLQN6, PosteDeTravailType = PosteDeTravailType19 };
             PosteDeTravail PosteDeTravailLQNZone6_2 = new PosteDeTravail() { Zone = ZoneLQN6, PosteDeTravailType = PosteDeTravailType20 };
             PosteDeTravail PosteDeTravailLQNZone6_3 = new PosteDeTravail() { Zone = ZoneLQN6, PosteDeTravailType = PosteDeTravailType21 };
             PosteDeTravail PosteDeTravailLQNZone6_4 = new PosteDeTravail() { Zone = ZoneLQN6, PosteDeTravailType = PosteDeTravailType22 };

             PosteDeTravail PosteDeTravailLQNZone7_1 = new PosteDeTravail() { Zone = ZoneLQN7, PosteDeTravailType = PosteDeTravailType23 };
             PosteDeTravail PosteDeTravailLQNZone7_2 = new PosteDeTravail() { Zone = ZoneLQN7, PosteDeTravailType = PosteDeTravailType24 };
             PosteDeTravail PosteDeTravailLQNZone7_3 = new PosteDeTravail() { Zone = ZoneLQN7, PosteDeTravailType = PosteDeTravailType25 };
             PosteDeTravail PosteDeTravailLQNZone7_4 = new PosteDeTravail() { Zone = ZoneLQN7, PosteDeTravailType = PosteDeTravailType26 };
             PosteDeTravail PosteDeTravailLQNZone7_5 = new PosteDeTravail() { Zone = ZoneLQN7, PosteDeTravailType = PosteDeTravailType27 };

             PosteDeTravail PosteDeTravailLQNZone9_1 = new PosteDeTravail() { Zone = ZoneLQN9, PosteDeTravailType = PosteDeTravailType32 };
             PosteDeTravail PosteDeTravailLQNZone9_2 = new PosteDeTravail() { Zone = ZoneLQN9, PosteDeTravailType = PosteDeTravailType33 };
             PosteDeTravail PosteDeTravailLQNZone9_3 = new PosteDeTravail() { Zone = ZoneLQN9, PosteDeTravailType = PosteDeTravailType34 };
             PosteDeTravail PosteDeTravailLQNZone9_4 = new PosteDeTravail() { Zone = ZoneLQN9, PosteDeTravailType = PosteDeTravailType35 };
             PosteDeTravail PosteDeTravailLQNZone9_5 = new PosteDeTravail() { Zone = ZoneLQN9, PosteDeTravailType = PosteDeTravailType36 };
             PosteDeTravail PosteDeTravailLQNZone9_6 = new PosteDeTravail() { Zone = ZoneLQN9, PosteDeTravailType = PosteDeTravailType37 };
             PosteDeTravail PosteDeTravailLQNZone9_7 = new PosteDeTravail() { Zone = ZoneLQN9, PosteDeTravailType = PosteDeTravailType38 };
             PosteDeTravail PosteDeTravailLQNZone9_8 = new PosteDeTravail() { Zone = ZoneLQN9, PosteDeTravailType = PosteDeTravailType39 };
             PosteDeTravail PosteDeTravailLQNZone9_9 = new PosteDeTravail() { Zone = ZoneLQN9, PosteDeTravailType = PosteDeTravailType40 };
             PosteDeTravail PosteDeTravailLQNZone9_10 = new PosteDeTravail() { Zone = ZoneLQN9, PosteDeTravailType = PosteDeTravailType41 };
             PosteDeTravail PosteDeTravailLQNZone9_11 = new PosteDeTravail() { Zone = ZoneLQN9, PosteDeTravailType = PosteDeTravailType42 };


             context.PosteDeTravails.Add(PosteDeTravailLQNZone3_1);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone3_2);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone3_3);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone3_4);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone3_5);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone3_6);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone3_7);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone3_8);

             context.PosteDeTravails.Add(PosteDeTravailLQNZone4_1);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone4_2);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone4_3);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone4_4);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone4_5);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone4_6);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone4_7);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone4_8);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone4_9);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone4_10);

             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_0);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_1);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_2);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_3);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_4);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_5);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_6);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_7);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_8);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_9);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_10);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_11);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_12);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_13);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_14);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_15);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone5_16);

             context.PosteDeTravails.Add(PosteDeTravailLQNZone6_1);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone6_2);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone6_3);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone6_4);

             context.PosteDeTravails.Add(PosteDeTravailLQNZone7_1);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone7_2);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone7_3);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone7_4);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone7_5);

             context.PosteDeTravails.Add(PosteDeTravailLQNZone9_1);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone9_2);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone9_3);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone9_4);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone9_5);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone9_6);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone9_7);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone9_8);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone9_9);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone9_10);
             context.PosteDeTravails.Add(PosteDeTravailLQNZone9_11);

            //Lieu LieuRefectoireRFS = new Lieu()
            //{
            //    Nom = "Refectoire",
            //    Zone = ZoneRDCRFS
            //};

            //Lieu LieuSalleServeurRFS = new Lieu()
            //{
            //    Nom = "Salle des serveurs",
            //    Zone = ZoneRDCRFS
            //};

            //Lieu LieuBureauComptaRFS = new Lieu()
            //{
            //    Nom = "Bureau Comptabilite",
            //    Zone = ZoneEtage1RFS
            //};

            //Lieu LieuBureauMarketingRFS = new Lieu()
            //{
            //    Nom = "Bureau Marketing",
            //    Zone = ZoneEtage1RFS
            //};

            //Lieu LieuRemplisseuseL1DLF = new Lieu()
            //{
            //    Nom = "Remplisseuse",
            //    Zone = ZoneLigne1DLF
            //};

            //Lieu LieuEtiqueteuseL1DLF = new Lieu()
            //{
            //    Nom = "Etiqueteuse",
            //    Zone = ZoneLigne1DLF
            //};

            //Lieu LieuRemplisseuseL2DLF = new Lieu()
            //{
            //    Nom = "Remplisseuse",
            //    Zone = ZoneLigne2DLF
            //};

            //Lieu LieuEtiqueteuseL2DLF = new Lieu()
            //{
            //    Nom = "Etiqueteuse",
            //    Zone = ZoneLigne2DLF
            //};

            //context.Lieux.Add(LieuRefectoireRFS);
            //context.Lieux.Add(LieuSalleServeurRFS);
            //context.Lieux.Add(LieuBureauComptaRFS);
            //context.Lieux.Add(LieuBureauMarketingRFS);
            //context.Lieux.Add(LieuRemplisseuseL1DLF);
            //context.Lieux.Add(LieuEtiqueteuseL1DLF);
            //context.Lieux.Add(LieuRemplisseuseL2DLF);
            //context.Lieux.Add(LieuEtiqueteuseL2DLF);

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
                Code = "DLF-2014-1",
                Type = "FAS",
                PosteDeTravail = PosteDeTravailDLFZone4_2,
                Service = ServiceDLF1,
                Responsable = Responsable1,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF4,
                Lieu = LieuDLFZone4_2,
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
                Code = "DLF-2014-2",
                Type = "FAS",
                PosteDeTravail = PosteDeTravailDLFZone3_2,
                Service = ServiceDLF1,
                Responsable = Responsable2,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF3,
                Lieu = LieuDLFZone3_2,
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
                Code = "DLF-2014-3",
                Type = "FPA",
                PosteDeTravail = PosteDeTravailDLFZone3_2,
                Service = ServiceDLF1,
                Responsable = Responsable3,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF2,
                Lieu = LieuDLFZone2_2,
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
                Code = "DLF-2014-4",
                Type = "FPA",
                PosteDeTravail = PosteDeTravailDLFZone5_2,
                Service = ServiceDLF1,
                Responsable = Responsable4,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF5,
                Lieu = LieuDLFZone5_2,
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
