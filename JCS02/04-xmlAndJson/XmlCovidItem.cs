using System.Xml.Serialization;

namespace _204
{
    public class XmlCovidItem
    {
        [XmlElement("pocatecni_datum")]
        public DateTime StartDate { get; set; }

        [XmlElement("koncove_datum")]
        public DateTime EndDate { get; set; }

        [XmlElement("klouzavy_prumer")]
        public double MovingAverage { get; set; }
    }
}
