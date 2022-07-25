using System;
using System.Xml.Serialization;

namespace CarDealer.DTOs
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
