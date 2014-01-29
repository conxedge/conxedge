using System.Net;
using System.Net.Mail;
using System.Text;

namespace ConXEdge.Server
{
    public class Email
    {
        public void SendSMTPEMail(string strSmtpServer, string strFrom, string strFromPass
            , string strto, string strSubject, string strBody) 
        { 
            SmtpClient client = new SmtpClient(strSmtpServer); 
            client.UseDefaultCredentials = false; 
            client.Credentials = new NetworkCredential(strFrom, strFromPass); 
            client.DeliveryMethod = SmtpDeliveryMethod.Network; 
            MailMessage message = new MailMessage(strFrom, strto, strSubject, strBody); 
            message.BodyEncoding = Encoding.UTF8; 
            message.IsBodyHtml = true; 
            client.Send(message); 
        }
    }
}
