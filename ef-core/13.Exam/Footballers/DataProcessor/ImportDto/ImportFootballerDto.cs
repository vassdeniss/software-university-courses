using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootballerDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; }

        [Required]
        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; }

        [Required]
        [XmlElement("PositionType")]
        public string PositionType { get; set; }

        [Required]
        [XmlElement("BestSkillType")]
        public string BestSkillType { get; set; }
    }
}
