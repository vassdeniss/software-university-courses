using System.Xml.Serialization;
using ProductShop.DTOs.Product;

namespace ProductShop.DTOs.User
{
    [XmlType("User")]
    public class ExportUserAndProductCountDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public ExportSoldProductCountDto SoldProducts { get; set; }
    }
}
