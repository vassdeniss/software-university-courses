using Newtonsoft.Json;

namespace ProductShop.DTO.Product
{
    [JsonObject]
    public class ExportProductRangeDto
    {
        [JsonProperty("name")] 
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string SellerFullName { get; set; }
    }
}
