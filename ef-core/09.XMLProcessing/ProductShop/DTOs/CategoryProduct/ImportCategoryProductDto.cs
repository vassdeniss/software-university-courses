using System.Xml.Serialization;

namespace ProductShop.DTOs.CategoryProduct
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDto
    {
        [XmlElement]
        public int CategoryId { get; set; }

        [XmlElement]
        public int ProductId { get; set; }
    }
}
