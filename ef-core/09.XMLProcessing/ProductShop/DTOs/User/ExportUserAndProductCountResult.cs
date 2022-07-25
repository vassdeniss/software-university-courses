using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.DTOs.User
{
    [XmlType("Users")]
    public class ExportUserAndProductCountResult
    {
        [XmlElement("count")]
        public int CountOfUsers { get; set; }

        [XmlArray("users")]
        public ExportUserAndProductCountDto[] Users { get; set; }
    }
}
