using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTicketDto
    {
        [Required]
        [Range(typeof(decimal), "1.00", "100.00")]
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(sbyte), "1", "10")]
        [JsonProperty("RowNumber")]
        public sbyte RowNumber { get; set; }

        [Required]
        [JsonProperty("PlayId")]
        public int PlayId { get; set; }
    }
}
