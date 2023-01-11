using Controller.Models;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Controller.Exceptions;
using Controller.Exceptions.Manager;

namespace Controller.Managers
{
    //TODO: bekijken
    //source : https://www.youtube.com/watch?v=PvO_1T0FS_A
    // use https://ethereal.email/
    public class EmailManager
    {

        public void SendEmail(IReadOnlyList<Afspraak> afspraak)
        {
            //string emailadres = "peggie.pfeffer23@ethereal.email";
            //string password = "gMuQXrtRTxKn8gCQxu";
            string body = MaakBezoekersLijst(afspraak);
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("barry.beatty92@ethereal.email"));
                email.To.Add(MailboxAddress.Parse("barry.beatty92@ethereal.email"));
                email.Subject = "Lijst met aanwezige bezoekers.";
                email.Body = new TextPart(TextFormat.Plain) { Text = body };

                using var smtp = new SmtpClient();
                // voor outlook -> smtp-mail.outlook.com
                smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("barry.beatty92@ethereal.email", "6thZwRa4GqvAanGCAq");
                smtp.Send(email);
                smtp.Disconnect(true);

            }
            catch (Exception ex)
            {

                throw new EmailManagerException("Je mail werd niet correct verzonden", ex);
            }
        }

        private string MaakBezoekersLijst(IReadOnlyList<Afspraak> afspraaken)
        {
            try
            {
                string res = "";
                foreach (var afspraak in afspraaken)
                {
                    res += afspraak.ToString();
                    res += "\n";

                }
                return res;
            }
            catch (Exception ex)
            {
                throw new EmailManagerException("Kan bezoekerlijst niet maken", ex);
            }
        }
    }
}
