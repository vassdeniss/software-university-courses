using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportCellDto
    {
        [Required]
        [Range(1, 1000)]
        [JsonProperty("cellNumber")]
        public int CellNumber { get; set; }

        [Required]
        [JsonProperty("hasWindow")]
        public bool HasWindow { get; set; }
    }
}
