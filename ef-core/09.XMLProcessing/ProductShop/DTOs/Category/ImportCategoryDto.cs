using System.Xml.Serialization;

namespace ProductShop.DTOs.Category
{
    [XmlType("Category")]
    public class ImportCategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
