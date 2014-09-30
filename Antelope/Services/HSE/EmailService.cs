using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Threading;


namespace Antelope.Services.HSE
{
    public class EmailService
    {

        public void SendEmailDiffusionFicheSecurite (){

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("Sezar@refresco.fr");
            mail.Subject = "Alerte Sécurité !!!";
            mail.Body = "Nouveau message d'alerte sécurité";
            mail.To.Add("jucok@gmx.fr");
            mail.To.Add("julien.cokelaere@refresco.fr");
            mail.IsBodyHtml = false;
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