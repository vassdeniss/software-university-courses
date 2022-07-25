using System.Xml.Serialization;

namespace CarDealer.DTOs.Car
{
    [XmlType("car")]
    public class ExportCarBMWDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
