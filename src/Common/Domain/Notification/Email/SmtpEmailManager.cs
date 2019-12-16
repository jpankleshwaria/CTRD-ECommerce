using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Common.Domain.Notification.Email
{
    public static class SmtpEmailManager
    {
        public static bool IsTestCaseExecuting { get; set; }

        public static SmtpSetting settings { get; set; }

        public static void SendEmail(Message message, bool isJob = false)
        {
            SendEmail(settings.FromEmailAddress, settings.FromDisplayName, message, isJob);
        }

        public static void SendEmail(string fromEmailAddress, string fromDisplayName, Message message, bool isJob = false)
        {
            if (!IsTestCaseExecuting)
            {
                using (SmtpClient client = new SmtpClient(settings.SmtpHost, settings.SmtpPort))
                {
                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(fromEmailAddress, fromDisplayName);
                        mailMessage.IsBodyHtml = true;
                        mailMessage.Body = message.Body;

                        mailMessage.Subject = message.Subject;

                        if (message.To.Contains(","))
                        {
                            List<string> toEmails = message.To.Split(',').ToList();
                            if (toEmails != null && toEmails.Count > 0)
                                foreach (var email in toEmails)
                                    mailMessage.To.Add(new MailAddress(email));
                        }
                        else
                            mailMessage.To.Add(new MailAddress(message.To));


                        if (message.Attachments != null && message.Attachments.Count > 0)
                        {
                            foreach (var item in message.Attachments)
                            {
                                //stream supposed to be disposed by mailmessage object
                                Attachment attach = new Attachment(new MemoryStream(item.FileData), item.FileName);
                                mailMessage.Attachments.Add(attach);
                            }

                        }

                        client.EnableSsl = settings.SslEnabled;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;

                        client.Credentials = new NetworkCredential(settings.SmtpUser, settings.SmtpPwd);
                        client.Send(mailMessage);
                    }
                }
            }
        }

        public static Message PrepareEmailMessage(string body, string subject, string toEmail, IEnumerable<MessageAttachment> attachments, object obj, bool parseText = true)
        {
            body = parseText ? EmailMessageParser.ParseText(body, obj) : body;
            subject = parseText ? EmailMessageParser.ParseText(subject, obj) : subject;

            var message = new Message()
            {
                Body = body,
                Subject = subject,
                To = toEmail
            };

            if (attachments != null)
            {
                foreach (var item in attachments)
                {
                    message.Attachments.Add(item);
                }
            }

            return message;
        }
    }
}
