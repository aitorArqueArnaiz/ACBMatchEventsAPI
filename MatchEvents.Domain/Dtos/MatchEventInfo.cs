using Newtonsoft.Json;

namespace MatchEvents.Domain.Dtos
{
    public class MatchEventInfo
    {
        [JsonProperty("id_competition")]
        public int? GameId { get; set; }
        [JsonProperty("id_team_denomination")]
        public long? TeamId { get; set; }
        [JsonProperty("id_license")]
        public long? PlayerLicense { get; set; }
        [JsonProperty("crono")]
        public string ActionTime { get; set; }
        [JsonProperty("id_playbyplaytype")]
        public int? ActionType { get; set; }
    }
}
