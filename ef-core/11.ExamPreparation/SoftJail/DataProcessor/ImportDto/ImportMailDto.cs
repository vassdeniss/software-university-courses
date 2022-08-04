using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportMailDto
    {
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }

        [Required]
        [JsonProperty("sender")]
        public string Sender { get; set; }

        [Required]
        [RegularExpression("^([A-Za-z0-9\\s]+?)(\\sstr\\.)$")]
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
