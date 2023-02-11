using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.Tools
{

    // The EmailService class is a static class that provides a method called Send to send emails to a recipient.
    // The method takes parameters for the recipient email address, password (for the sender's email account),
    // email body, subject, and sender email address.
    // The method uses the SmtpClient class and MailMessage class from the System.Net.Mail namespace to send the email.
    // The SmtpClient class is configured with the host, port, SSL settings, delivery method, and credentials
    // (sender email address and password) to connect to the email server. The MailMessage class is used to create the
    // email with the sender, recipient, subject, and body. Finally, the email is sent using the smtp.Send method.

    public static class EmailService
    {
        public static void Send(string reciever, string password = "814578", string body = "AccountActivation", string subject = "Trial Email", string sender = "iktuerensemih@gmail.com")
        {
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress recieverEmail = new MailAddress(reciever);


            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };

            using (MailMessage message = new MailMessage(senderEmail, recieverEmail)
            {
                Subject=subject,
                Body=body,
            })
            {
                smtp.Send(message);
            }
        }
    }
}
