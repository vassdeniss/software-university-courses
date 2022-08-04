using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class ImportPrisonerXmlDto
    {
        [Required]
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
