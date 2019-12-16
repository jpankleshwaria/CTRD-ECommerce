using System.Collections.Generic;

namespace Common.Domain.Notification.Email
{
    public class Message
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public IList<MessageAttachment> Attachments { get; set; }

        public Message()
        {
            this.Attachments = new List<MessageAttachment>();
        }
    }

    public class MessageAttachment
    {
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}
