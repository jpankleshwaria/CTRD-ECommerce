using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Notification.Email
{
    public class SmtpSetting
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPwd { get; set; }
        public bool SslEnabled { get; set; }
        public string FromEmailAddress { get; set; }
        public string FromDisplayName { get; set; }
        public string WebPortalUrl { get; set; }
    }
}
