using Newtonsoft.Json;

namespace MatchEvents.Domain.Dtos.Player
{
    public class License
    {
        [JsonProperty("id_person")]
        public long PlayerId { get; set; }
    }
}
