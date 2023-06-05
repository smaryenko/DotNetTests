using Newtonsoft.Json;

namespace Tests.Api.Helpers.Models
{
    public class Order
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("petId")]
        public int PetId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("shipDate")]
        public string ShipDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("complete")]
        public bool Complete { get; set; }
    }

    public enum OrderStatus
    {
        placed,
        approved,
        delivered
    }
}
