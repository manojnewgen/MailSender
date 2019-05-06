using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            string content = string.Empty;
            string textpath = @"E:\Manoj\Projects\MailSender\MailSender\ConsoleApp1\ConsoleApp1\Email.txt";

            using (StreamReader sr = new StreamReader(textpath, Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
            {
                content = sr.ReadToEnd();
            }
            Console.WriteLine($"{content}");
            content = $"{content}";

            MailMessage mail = new MailMessage("kumar.manoj@thinksys.com", "matchcrmdev@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("kumar.manoj@thinksys.com", "mitom@9058");
            mail.Subject = "test email with digital signature";

            mail.Body = content;
            mail.IsBodyHtml = true;
            //SmtpServer oServer = new SmtpServer("smtp.emailarchitect.net");

            //// User and password for ESMTP authentication, if your server doesn't require
            //// User authentication, please remove the following codes.
            //oServer.User = "test@emailarchitect.net";
            //oServer.Password = "testpassword";
            //try
            //{
            //    // Find certificate by email adddress in My Personal Store.
            //    // Once the certificate is loaded to From, the email content
            //    // will be signed automatically
            //    mail.From.Certificate.FindSubject(mail.From.Address,
            //        Certificate.CertificateStoreLocation.CERT_SYSTEM_STORE_CURRENT_USER,
            //        "My");
            //}
            mail.Headers.Add("multipart/alternative", "text/x-amp-html");
            client.Send(mail);
            Console.ReadKey();
        }
    }
}
