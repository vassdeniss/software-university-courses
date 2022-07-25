using System.Xml.Serialization;

namespace ProductShop.DTOs.Category
{
    [XmlType("Category")]
    public class ExportCategoryProductCountDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int NumberOfProducts { get; set; }

        [XmlElement("averagePrice")]
        public decimal AverageProductsPrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
