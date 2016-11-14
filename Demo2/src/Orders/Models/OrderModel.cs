using System;
using Newtonsoft.Json;

namespace Demo2.Orders.Models
{
    public class OrderModel
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("orderTypeId")]
        public int OrderTypeId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusId")]
        public int StatusId { get; set; }

        [JsonProperty("deadlineTime")]
        public DateTime DeadlineTime { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("isUrgently")]
        public bool IsUrgently { get; set; }
    }
}