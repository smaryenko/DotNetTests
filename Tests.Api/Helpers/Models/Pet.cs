using Newtonsoft.Json;

namespace Tests.Api.Helpers.Models
{
    public class Pet
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("photoUrls")]
        public List<string> PhotoUrls { get; set; }

        [JsonProperty("tags")]
        public List<Category> Tags { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public enum PetStatus
    {
        available,
        pending,
        sold
    }
}
