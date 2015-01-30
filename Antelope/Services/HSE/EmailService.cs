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
using Antelope.DTOs.Socle;


namespace Antelope.Services.HSE
{
    public class EmailService
    {

        private AntelopeEntities db = new AntelopeEntities();
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }


        private string GetEmailFor(string parametrage, string trigramme)
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
                    email = ParametrageHSE.EmailValidationRejetPlanActionFS;
                    break;
                case "ValidationPlanActionFicheSecurite":
                    email = ParametrageHSE.EmailValidationRejetPlanActionFS;
                    break;
                case "DiffusionPlanActionFicheSecurite":
                    email = ParametrageHSE.EmailDiffusionPlanAction;
                    break;
            }
            
            if (email == "SELF")
            {
                email = _activeDirectoryUtilisateurRepository.GetCurrentUserEmail();
            }

            string emailWithoutSiteSpecialCaracters = SiteSpecialCaractersReplace(email, trigramme);

            return emailWithoutSiteSpecialCaracters;
        }

        private string SiteSpecialCaractersReplace(string emailString, string trigramme)
        {
            string emailWithSiteCaracters = emailString.Replace("&&&", trigramme);
            return emailWithSiteCaracters;
        }


        public void SendEmailDiffusionFicheSecurite (FicheSecurite FicheSecurite){

            MailMessage mail = new MailMessage();

            // TODO : Créer une classe pour construire des adresses ... ?
            UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string urlToFicheSecurite = url.Action("Edit", "FicheSecurite", new System.Web.Routing.RouteValueDictionary(new { id = FicheSecurite.FicheSecuriteID }), "http", HttpContext.Current.Request.Url.Host);


            string ActionImmediate2 = "";
            if(FicheSecurite.ActionImmediate2 != null && FicheSecurite.ActionImmediate2 != ""){
                ActionImmediate2 = "<div>&nbsp;&nbsp;-&nbsp;" + FicheSecurite.ActionImmediate2 + "</div>";
            }

            String body = "<div style='font-family: Verdana, sans-serif;'><H1 style='background-color:#C42031;color:#FFFFFF;text-align:center;border-radius: 25px;'>Nouvelle Fiche Sécurité à " + FicheSecurite.Site.Trigramme + "</H1>" +
                "<div><span style='font-weight: bold;text-decoration: underline;'>" + db.FicheSecuriteTypes.Find(FicheSecurite.FicheSecuriteTypeId).Nom + "</span>" +
                " de <span style='font-weight: bold;text-decoration: underline;'>" + FicheSecurite.PersonneConcernee.Prenom + " " + FicheSecurite.PersonneConcernee.Nom + "</span></div>" +
                "<br/>" +
                "<div style='font-weight: bold;text-decoration: underline;'>Déscription :</div>" +
                "<div>" + FicheSecurite.Description + "</div>" +
                "<br/>" +
                "<div style='font-weight: bold;text-decoration: underline;'>Action(s) immédiate(s) :</div>" +
                "<div>&nbsp;&nbsp;-&nbsp;" + FicheSecurite.ActionImmediate1 + "</div>" +
                ActionImmediate2 +
                "<br/>"+
                "<div> Lien vers la fiche  : " + urlToFicheSecurite + "</div></div>";

            MailAddress from = new MailAddress("Sezar@refresco.fr");
            string subject = "Nouvelle Fiche Sécurité à " + FicheSecurite.Site.Trigramme;


            string to = GetEmailFor("DiffusionFicheSecurite", FicheSecurite.Site.Trigramme); //db.Sites.Find(FicheSecurite.SiteId).Trigramme);

            to = addFicheSecuriteResponsableEmailToString(to, FicheSecurite);

            SendEmail(from, subject, body, to);
        }

        public void SendEmailDiffusionPlanActionFicheSecurite(FicheSecurite ficheSecurite)
        {

            Site site = db.Sites.First(s => s.SiteID == ficheSecurite.SiteId);

            string to = GetEmailFor("DiffusionPlanActionFicheSecurite", db.Sites.Find(ficheSecurite.SiteId).Trigramme );

            to = addFicheSecuriteResponsableEmailToString(to, ficheSecurite);

            to = addActionResponsableEmailToString(to, ficheSecurite);

            MailAddress from = new MailAddress("Sezar@refresco.fr");
            string subject = "Diffusion Plan d'action";
            string body = "<H4>Le plan d'action de la Fiche Securite " + ficheSecurite.Code + " vient d'être diffusé</H4> </br>";

            SendEmail(from, subject, body, to);

        }

        public void SendEmailValidationPlanActionFicheSecurite(FicheSecurite ficheSecurite)
        {

            Site site = db.Sites.First(s => s.SiteID == ficheSecurite.SiteId);

            string to = GetEmailFor("ValidationPlanActionFicheSecurite", db.Sites.Find(ficheSecurite.SiteId).Trigramme);

            to = addFicheSecuriteResponsableEmailToString(to, ficheSecurite);

            to = addActionResponsableEmailToString(to, ficheSecurite);

            MailAddress from = new MailAddress("Sezar@refresco.fr");
            string subject = "Validation Plan d'action";
            string body = "<H4>Le plan d'action de la Fiche Securite " + ficheSecurite.Code + " vient d'être validé</H4> </br>";

            SendEmail(from, subject, body, to);

        }

        public void SendEmailRejetPlanActionFicheSecurite(FicheSecurite ficheSecurite)
        {

            Site site = db.Sites.First(s => s.SiteID == ficheSecurite.SiteId);

            string to = GetEmailFor("RejetPlanActionFicheSecurite", db.Sites.Find(ficheSecurite.SiteId).Trigramme);

            to = addFicheSecuriteResponsableEmailToString(to, ficheSecurite);

            to = addActionResponsableEmailToString(to, ficheSecurite);

            MailAddress from = new MailAddress("Sezar@refresco.fr");
            string subject = "Rejet Plan d'action";
            string body = "<H4>Le plan d'action de la Fiche Securite "+ ficheSecurite.Code +" vient d'être rejeté</H4> Voici la cause du rejet : </br>" + ficheSecurite.WorkFlowASERejeteeCause; 

            SendEmail(from, subject, body, to);

        }

        private string addFicheSecuriteResponsableEmailToString(String to, FicheSecurite ficheSecurite)
        {
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();

            ActiveDirectoryUtilisateurDTO ResponsableActiveDirectoryUtilisateurDTO;

            ResponsableActiveDirectoryUtilisateurDTO = _activeDirectoryUtilisateurRepository.GetActiveDirectoryUtilisateurByNomPrenom(ficheSecurite.Responsable.Nom, ficheSecurite.Responsable.Prenom);


            String toResponsable = "";

            if (ResponsableActiveDirectoryUtilisateurDTO != null)
            {
               toResponsable = ResponsableActiveDirectoryUtilisateurDTO.email;
            }
            
            if (toResponsable != "" && toResponsable != null)
            {
                if(to != "" && toResponsable != null){
                    to += ",";
                }
                to += toResponsable;
            }

            return to;
        }

        private string addActionResponsableEmailToString(String to, FicheSecurite ficheSecurite)
        {
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();

            ActiveDirectoryUtilisateurDTO ResponsableActiveDirectoryUtilisateurDTO;

            List<Personne> allActionResponsable = new List<Personne>();

            foreach (CauseQSE cause in ficheSecurite.CauseQSEs)
            {
                foreach (ActionQSE action in cause.ActionQSEs)
                {
                    allActionResponsable.Add(action.Responsable);
                }
            }

            for (int i = 0; i < allActionResponsable.Count(); i++)
            {
                to += (to == "") ? "" : ",";

                ResponsableActiveDirectoryUtilisateurDTO = _activeDirectoryUtilisateurRepository.GetActiveDirectoryUtilisateurByNomPrenom(allActionResponsable[i].Nom, allActionResponsable[i].Prenom);

                to += ResponsableActiveDirectoryUtilisateurDTO.email;
            }

            return to;
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

                try
                {
                    smtp.Send(mail);
                }
                catch (Exception e)
                {
                    var a = 1;
                    Console.WriteLine(e);

                }
                
            });
            T1.Start();

        }

    }
}