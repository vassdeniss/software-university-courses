using System.Xml.Serialization;

namespace ProductShop.DTOs.Product
{
    [XmlType("SoldProducts")]
    public class ExportSoldProductCountDto
    {
        [XmlElement("count")]
        public int ProductsCount { get; set; }

        [XmlArray("products")]
        public ExportSoldProductDto[] Products { get; set; }
    }
}
