
using System.Text.Json.Serialization;

namespace MatchEvents.Domain.Dtos
{
    public class MatchEventInfo
    {
        [JsonPropertyName("team_id")]
        public long TeamId { get; set; }
        [JsonPropertyName("player_license")]
        public long PlayerLicense { get; set; }
        [JsonPropertyName("action_time")]
        public string ActionTime { get; set; }
        [JsonPropertyName("action_type")]
        public int ActionType { get; set; }
    }
}
