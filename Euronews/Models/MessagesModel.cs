using System.Collections.Generic;

namespace Euronews.Models
{
    public class Message
    {
        public string id { get; set; }
        public string threadId { get; set; }
    }

    public class MessagesModel
    {
        public List<Message> messages { get; set; }
        public int resultSizeEstimate { get; set; }
    }
}
