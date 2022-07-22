using Newtonsoft.Json;

namespace CarDealer.DTO.Customer
{
    [JsonObject]
    public class ImportCustomerDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
