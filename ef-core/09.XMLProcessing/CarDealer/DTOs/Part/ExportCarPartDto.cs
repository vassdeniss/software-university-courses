using System.Xml.Serialization;

namespace CarDealer.DTOs.Part
{
    [XmlType("part")]
    public class ExportCarPartDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
