using System.Xml.Serialization;

namespace CarDealer.DTOs.Supplier
{
    // nice typo
    [XmlType("suplier")]
    public class ExportSupplierDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}
