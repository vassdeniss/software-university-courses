using System.Xml.Serialization;

namespace CarDealer.DTOs.Customer
{
    [XmlType("customer")]
    public class ExportCustomerSaleDto
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; }

        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }

        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }
    }
}
