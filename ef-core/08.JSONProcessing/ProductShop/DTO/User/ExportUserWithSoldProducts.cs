using Newtonsoft.Json;

using ProductShop.DTO.Product;

namespace ProductShop.DTO.User
{
    [JsonObject]
    public class ExportUserWithSoldProducts
    {
        [JsonProperty("firstName")] 
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public ExportUserSoldProductsDto[] SoldProducts { get; set; }
    }
}
