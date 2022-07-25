using System.Xml.Serialization;

namespace ProductShop.DTOs.Product
{
    [XmlType("Product")]
    public class ExportSoldProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
