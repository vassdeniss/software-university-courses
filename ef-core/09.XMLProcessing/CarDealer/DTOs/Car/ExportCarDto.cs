using System.Xml.Serialization;

namespace CarDealer.DTOs.Car
{
    [XmlType("car")]
    public class ExportCarDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
