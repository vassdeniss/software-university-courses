using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Footballer")]
    public class GetFootballerDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public string PositionType { get; set; }
    }
}
    