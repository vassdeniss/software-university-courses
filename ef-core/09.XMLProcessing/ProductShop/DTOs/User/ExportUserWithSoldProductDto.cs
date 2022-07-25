using System.Xml.Serialization;

using ProductShop.DTOs.Product;

namespace ProductShop.DTOs.User
{
    [XmlType("User")]
    public class ExportUserWithSoldProductDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ExportSoldProductDto[] SoldProducts { get; set; }
    }
}
