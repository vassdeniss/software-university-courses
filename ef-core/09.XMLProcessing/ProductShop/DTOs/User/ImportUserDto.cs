using System.Xml.Serialization;

namespace ProductShop.DTOs.User
{
    [XmlType("User")]
    public class ImportUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }
    }
}
