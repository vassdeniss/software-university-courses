using System.Xml.Serialization;

namespace CarDealer.DTOs.Supplier
{
    [XmlType("Supplier")]
    public class ImportSupplierDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        
        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
