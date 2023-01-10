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

        //source : https://www.youtube.com/watch?v=PvO_1T0FS_A
        // use https://ethereal.email/
    public class EmailManager
    {
        private string email = "peggie.pfeffer23@ethereal.email";
        private string password = "gMuQXrtRTxKn8gCQxu";
        public void SendEmail(IReadOnlyList<Afspraak> afspraak)
        {
            //string body = MaakBezoekersLijst( bezoekers);
            string body = MaakBezoekersLijst(afspraak);
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("consuelo.padberg17@ethereal.email"));
                email.To.Add(MailboxAddress.Parse("consuelo.padberg17@ethereal.email")); 
                email.Subject = "test";
                email.Body = new TextPart(TextFormat.Plain) { Text = body };

                using var smtp = new SmtpClient();
                // voor outlook -> smtp-mail.outlook.com
                smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("consuelo.padberg17@ethereal.email", "tXFmhmmaqu2sCTzjtQ"); 
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
            }catch(Exception ex)
            {
                throw new EmailManagerException("Kan bezoekerlijst niet maken", ex);
            }
        }
    }
}
