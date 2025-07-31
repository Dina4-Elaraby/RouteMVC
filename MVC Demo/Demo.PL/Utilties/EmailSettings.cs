using System.Net;
using System.Net.Mail;

namespace Demo.Presentation.Utilties
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient(host: "smtp.gmail.com", port: 587);
            client.EnableSsl = true;
            //account who send email to users, must enable two factory authentication of this account 
            client.Credentials = new NetworkCredential("dinaalaraby2003@gmail.com", "fyzxuvfhklqqdyci");
            client.Send("dinaalaraby2003@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
