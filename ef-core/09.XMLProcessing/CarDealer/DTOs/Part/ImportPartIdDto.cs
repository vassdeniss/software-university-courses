using System.Xml.Serialization;

namespace CarDealer.DTOs.Part
{
    [XmlType("partId")]
    public class ImportPartIdDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
