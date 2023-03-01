using System.Collections.Generic;

namespace Euronews.Models
{
    public class Body
    {
        public int size { get; set; }
        public string data { get; set; }
    }

    public class BodyParts
    {
        public int size { get; set; }
        public string data { get; set; }
    }

    public class Header
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Part
    {
        public string partId { get; set; }
        public string mimeType { get; set; }
        public string filename { get; set; }
        public List<Header> headers { get; set; }
        public Body body { get; set; }
    }

    public class Payload
    {
        public string partId { get; set; }
        public string mimeType { get; set; }
        public string filename { get; set; }
        public List<Header> headers { get; set; }
        public Body body { get; set; }
        public List<Part> parts { get; set; }
    }

    public class EmailModel
    {
        public string id { get; set; }
        public string threadId { get; set; }
        public List<string> labelIds { get; set; }
        public string snippet { get; set; }
        public Payload payload { get; set; }
        public int sizeEstimate { get; set; }
        public string historyId { get; set; }
        public string internalDate { get; set; }
    }

}
