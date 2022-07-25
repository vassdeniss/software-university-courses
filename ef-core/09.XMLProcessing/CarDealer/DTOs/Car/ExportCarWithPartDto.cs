using System.Xml.Serialization;

using CarDealer.DTOs.Part;

namespace CarDealer.DTOs.Car
{
    [XmlType("car")]
    public class ExportCarWithPartDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ExportCarPartDto[] CarParts { get; set; }
    }
}
