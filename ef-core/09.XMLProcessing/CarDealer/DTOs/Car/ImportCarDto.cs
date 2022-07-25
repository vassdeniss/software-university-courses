using System.Xml.Serialization;

using CarDealer.DTOs.Part;

namespace CarDealer.DTOs.Car
{
    [XmlType("Car")]
    public class ImportCarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ImportPartIdDto[] PartsIds { get; set; }
    }
}
