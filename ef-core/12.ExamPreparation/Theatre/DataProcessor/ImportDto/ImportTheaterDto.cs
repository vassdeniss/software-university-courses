using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheaterDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(sbyte), "1", "10")]
        [JsonProperty("NumberOfHalls")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Tickets")]
        public ImportTicketDto[] Tickets { get; set; }
    }
}
