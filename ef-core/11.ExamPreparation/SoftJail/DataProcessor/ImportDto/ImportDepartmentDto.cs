using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cells")]
        public ImportCellDto[] Cells { get; set; }
    }
}
