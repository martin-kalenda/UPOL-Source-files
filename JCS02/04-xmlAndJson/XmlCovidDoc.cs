using System.Xml.Serialization;

namespace _204
{
    [XmlRoot("covidMovingAverages")]
    public class XmlCovidDoc
    {
        [XmlElement("modified")]
        public DateTime Modified { get; set; }

        [XmlElement("source")]
        public string Source { get; set; } = "";

        [XmlElement("data")]
        public List<XmlCovidItem> Data { get; set; } = new List<XmlCovidItem>();
    }
}
