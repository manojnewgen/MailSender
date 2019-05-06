using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using ConsoleApp1.Src;
using System.Net.Mime;
namespace ConsoleApp1
{
class Program
{
static void Main(string[] args)
{
string content = string.Empty;
using (StreamReader sr = new StreamReader("./anand.txt"))
{
content = sr.ReadToEnd();
}
SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
{
EnableSsl = true,
DeliveryFormat = SmtpDeliveryFormat.International,
DeliveryMethod = SmtpDeliveryMethod.Network,
UseDefaultCredentials = false,
Credentials = new NetworkCredential("anand@thinksys.com", "xxxxxxxxxxxxxxxxx")
};
MailMessage message = new MailMessage("anand@thinksys.com", "nndchaudhary8@gmail.com")
{
Subject = "ok",
BodyTransferEncoding = TransferEncoding.QuotedPrintable
};
message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString("this is text", new ContentType("text/plain")));
message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString("<b>this is html</b>", new ContentType("text/html")));
message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(content, System.Text.Encoding.UTF8, "text/x-amp-html"));
client.Send(message);
}
}
}


Send a message

