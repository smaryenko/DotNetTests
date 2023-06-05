using Newtonsoft.Json;

namespace Tests.Api.Helpers.Models
{
    public class PetInventoryStatus
    {
        [JsonProperty("approved")]
        public int Approved { get; set; }

        [JsonProperty("placed")]
        public int Placed { get; set; }

        [JsonProperty("delivered")]
        public int Delivered { get; set; }
    }
}
