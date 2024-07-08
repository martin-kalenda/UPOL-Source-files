using System.Xml;
using System.Xml.Serialization;

namespace _204
{
    [XmlRoot("predmetKatedry")]
    public class XmlSubjectItem
    {
        [XmlElement("katedra")]
        public string Department { get; set; } = "";

        [XmlElement("zkratka")]
        public string Abbreviation { get; set; } = "";

        [XmlElement("rok")]
        public int Year { get; set; }

        [XmlElement("nazev")]
        public string Name { get; set; } = "";

        [XmlElement("semestr")]
        public string Semester { get; set; } = "";

        [XmlElement("maVyuku")]
        public string IsTaught { get; set; } = "";

        [XmlElement("vyukaZS")]
        public string TaughtInWinter { get; set; } = "";

        [XmlElement("vyukaLS")]
        public string TaughtInSummer { get; set; } = "";

        [XmlElement("jazyk1")]
        public string PrimaryLanguage { get; set; } = "";

        [XmlElement("jazyk2")]
        public string? SecondaryLanguage { get; set; }

        [XmlElement("nabizetPrijezdyEcts")]
        public string OfferArrivalsEcts { get; set; } = "";

        [XmlElement("pocetStudentu")]
        public int StudentCount { get; set; }

        [XmlElement("aSkut")]
        public int AReal { get; set; }

        [XmlElement("bSkut")]
        public int BReal { get; set; }

        [XmlElement("cSkut")]
        public int CReal { get; set; }
    }
}
