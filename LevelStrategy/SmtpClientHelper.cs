using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using NLog;
using System.Net;
using LevelStrategy.Properties;
using System.Security.Authentication;

namespace LevelStrategy
{
    public static class SmtpClientHelper
    {
        public class MailMsg
        {
            public string MailFrom;
            public IEnumerable<string> SendTo;
            public IEnumerable<string> CopyTo;
            public string Subject;
            public string Text;
            public IEnumerable<string> Attachments = null;
        }

        private static readonly ILogger Logger = LogManager.GetLogger("main");

        public static IEnumerable<string> Subscribers
        {
            get
            {
                //return new List<string> { SzyfrowanieString.deszyfruj(ConfigurationManager.AppSettings.Get("mailDev")) };
                const string path = "Subscribers.txt";
                return File.Exists(path) ? File.ReadAllLines(path).Where(s => !string.IsNullOrEmpty(s)).ToArray() : new string[0];
            }
        }

        public static void SendEmail(string title, string messageBody = "", string senderAddress = "mailforsignal@mail.ru")
        {
            //var title = "Получен сигнал";

            //var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //var body = "<b>Service version</b>: " + version + "<br /><br />" +
            //           "<b>Message</b>: " + message + "<br /><br />";
            //         //  "<b>Exception</b>: " + ex.ToString().Replace("\r\n", "<br />");
            //body += "<hr>";
            //body += "<br />" + Environment.MachineName;
            //body += "<br />" + System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

            //SendEmail(senderAddress, Subscribers, null, title, body);

            var fromAddress = new MailAddress("mailforsignal@mail.ru", "LevelStrategy");
            var toAddress = new MailAddress("mailforsignal@mail.ru", "v.pavlov");
            const string fromPassword = "2569zw92dbnzzdbn";
            string subject = title;
            string body = messageBody;

            var smtp = new SmtpClient
            {
                Host = "smtp.mail.ru",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
                try
                {
                    smtp.Send(message);
                }
                catch (AuthenticationException ex)
                {
                    Logger.Error(ex);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
        }

        public static void SendEmail(string form, IEnumerable<string> to, IEnumerable<string> copyTo, string title, string body, IEnumerable<string> attachments = null)
        {
            var message = new MailMsg
            {
                Attachments = attachments,
                CopyTo = copyTo,
                Text = body,
                Subject = title,
                MailFrom = form,
                SendTo = to
            };

            SendEmail(message);
        }

        public static void SendEmail(MailMsg message)
        {
            try
            {
                var mailMsg = new MailMessage();

                //mailMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;

                foreach (var s in message.SendTo)
                {
                    mailMsg.To.Add(s);
                }

                if (message.CopyTo != null)
                    foreach (var s in message.CopyTo)
                    {
                        mailMsg.Bcc.Add(s);
                    }


                // From
                var mailAddress = new MailAddress(message.MailFrom);
                mailMsg.From = mailAddress;

                // Subject and Body
                mailMsg.IsBodyHtml = true;
                mailMsg.Subject = message.Subject;
                mailMsg.Body = message.Text;

                if (message.Attachments != null)
                {
                    foreach (var attachment in message.Attachments)
                    {
                        mailMsg.Attachments.Add(new Attachment(attachment, System.Net.Mime.MediaTypeNames.Application.Octet));
                    }
                }

                var host = "smtp.mail.ru"; //mail.osgrm.ru
                var smtpClient = new SmtpClient(host, 25);
                smtpClient.Credentials = new NetworkCredential("mailforsignal@mail.ru", "2569zw92dbnzzdbn");
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }

}
