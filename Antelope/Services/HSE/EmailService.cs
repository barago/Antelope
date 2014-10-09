using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Threading;
using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using System.Web.Mvc;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using Antelope.Services.Socle;
using Antelope.Repositories.Socle;


namespace Antelope.Services.HSE
{
    public class EmailService
    {

        private AntelopeEntities db = new AntelopeEntities();
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }


        private string GetEmailFor(string parametrage)
        {

            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
            string email = "";

            ParametrageHSE ParametrageHSE = db.ParametrageHSEs.FirstOrDefault();

            switch (parametrage)
            {
                case "DiffusionFicheSecurite" :
                    email = ParametrageHSE.EmailDiffusionFS;
                    break;
                case "RejetPlanActionFicheSecurite":
                    email = ParametrageHSE.EmailRejetPlanActionFS;
                    break;
            }
            
            if (ParametrageHSE.EmailDiffusionFS == "SELF")
            {
                email = _activeDirectoryUtilisateurRepository.GetCurrentUserEmail();
            }

            return email;
        }


        public void SendEmailDiffusionFicheSecurite (FicheSecurite FicheSecurite){

            MailMessage mail = new MailMessage();

            // TODO : Créer une classe pour construire des adresses ... ?
            UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string urlToFicheSecurite = url.Action("Edit", "FicheSecurite", new System.Web.Routing.RouteValueDictionary(new { id = FicheSecurite.FicheSecuriteID }), "http", HttpContext.Current.Request.Url.Host);


            string ActionImmediate2 = "";
            if(FicheSecurite.ActionImmediate2 != null && FicheSecurite.ActionImmediate2 != ""){
                ActionImmediate2 = "<div> Deuxième action immédiate : " + FicheSecurite.ActionImmediate2 + "</div>";
            }

            String body = "<H1>Alerte Sécurité</H1>" +
                "<div> Site : " + FicheSecurite.Site.Nom + "</div>" +
                "<div> Type d'alerte : " + db.FicheSecuriteTypes.Find(FicheSecurite.FicheSecuriteTypeId).Nom + "</div>" +
                "<div> Nom et Prénom : " + FicheSecurite.PersonneConcernee.Prenom + " " + FicheSecurite.PersonneConcernee.Nom + "</div>" +
                "<div> Zone : " + db.Zones.Find(FicheSecurite.ZoneId).ZoneType.Nom + "</div>" +
                "<div> Zone de la lésion : " + db.CorpsHumainZones.Find(FicheSecurite.CorpsHumainZoneId).Nom + "</div>" +
                "<div> Déscription : " + FicheSecurite.Description + "</div>" +
                "<div> Action immédiate : " + FicheSecurite.ActionImmediate1 + "</div>" +
                ActionImmediate2 +
                "<div> Lien vers la fiche  : " + urlToFicheSecurite + "</div>"
                ;

            MailAddress from = new MailAddress("Sezar@refresco.fr");
            string subject = "Alerte Sécurité";
            string to = GetEmailFor("DiffusionFicheSecurite");

            SendEmail(from, subject, body, to);
        }


        public void SendEmailRejetPlanActionFicheSecurite(FicheSecurite ficheSecurite)
        {

            MailAddress from = new MailAddress("Sezar@refresco.fr");
            string subject = "Rejet Plan d'action";
            string body = "<H4>Le plan d'action de la Fiche Securite vient d'être rejeté</H4> Voici la cause du rejet : </br>" + ficheSecurite.WorkFlowASERejeteeCause;
            string to = GetEmailFor("RejetPlanActionFicheSecurite");

            SendEmail(from, subject, body, to);

        }

        private void SendEmail(MailAddress from, String subject, string body, string to)
        {

            MailMessage mail = new MailMessage();

            mail.From = from;
            mail.Subject = subject;
            mail.Body = body;
            mail.To.Add(to);
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "dlf-sk8vm03.refresco.local";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = true; // si false, décommenter la ligne de dessous
            //smtp.Credentials = new System.Net.NetworkCredential("username", "password"); // Renseigner le nom d'utilisateur et le mot de passe
            smtp.EnableSsl = false;

            //On crée un nouveau Thread, afin de ne pas attendre l'authentification serveur Exchange pour envoyer le mail.
            Thread T1 = new Thread(delegate()
            {
                smtp.Send(mail);
            });
            T1.Start();

        }

    }
}