using Newtonsoft.Json;

namespace Demo2.Orders.Models
{
    public class OrderTypeModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}