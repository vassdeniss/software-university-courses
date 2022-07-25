using System.Xml.Serialization;

using CarDealer.DTOs.Car;

namespace CarDealer.DTOs.Sale
{
    [XmlType("sale")]
    public class ExportSaleDiscountDto
    {
        [XmlElement("car")]
        public ExportCarDto SoldCar { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }
}
