using Newtonsoft.Json;

namespace CarDealer.DTO.Customer
{
    [JsonObject]
    public class ExportCustomersOrderedDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("BirthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("IsYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
