using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class ExportCoachWithFootballerDto
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        [XmlElement("CoachName")]
        public string Name { get; set; }

        [XmlArray("Footballers")]
        public GetFootballerDto[] Footballers { get; set; }
    }
}
