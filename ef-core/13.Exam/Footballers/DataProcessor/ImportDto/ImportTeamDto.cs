using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        [JsonProperty("Name")]
        [RegularExpression(@"^[A-Za-z0-9\s.-]+$")]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        [JsonProperty("Nationality")]
        public string Nationality { get; set; }

        [Required]
        [JsonProperty("Trophies")]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] Footballers { get; set; }
    }
}
