
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MatchEvents.Domain.Dtos
{
    public class MatchEventInfo
    {
        [JsonProperty("id_competition")]
        public int? GameId { get; set; }
        [JsonProperty("id_team")]
        public long? TeamId { get; set; }
        [JsonProperty("id_license")]
        public long? PlayerLicense { get; set; }
        [JsonProperty("crono")]
        public string ActionTime { get; set; }
        [JsonProperty("id_license_type")]
        public int? ActionType { get; set; }
    }
}
