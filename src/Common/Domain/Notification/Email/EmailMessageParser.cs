using System;
using System.Reflection;


namespace Common.Domain.Notification.Email
{
    public static class EmailMessageParser
    {
        public static Message ParseMessage(string websiteUrl, Message messageTemplate, object args)
        {
            if (messageTemplate != null && !string.IsNullOrEmpty(messageTemplate.To))
            {
                messageTemplate.Body = ParseText(websiteUrl, messageTemplate.Body, args);
            }
            return messageTemplate;
        }

        public static string ParseText(string text, object args)
        {
            if (string.IsNullOrEmpty(text)) return null;
            var body = text;

            if (args != null)
            {
                foreach (var prop in args.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    body = body.Replace("@" + prop.Name, Convert.ToString(prop.GetValue(args, null)));
                }
            }
            return body;
        }

        public static string ParseText(string websiteUrl, string text, object args)
        {
            if (string.IsNullOrEmpty(text)) return null;
            var body = text;

            if (args != null)
            {
                foreach (var prop in args.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    body = body.Replace("@" + prop.Name, Convert.ToString(prop.GetValue(args, null)));
                }
            }
            string basePath = websiteUrl;

            body = body.Replace("@BasePath", basePath);

            return body;
        }
    }
}
