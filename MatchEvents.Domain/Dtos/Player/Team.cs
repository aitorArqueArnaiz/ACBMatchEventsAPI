using Newtonsoft.Json;

namespace MatchEvents.Domain.Dtos.Player
{
    public class Team
    {
        [JsonProperty("id_team_denomination")]
        public long? TeamId { get; set; }
    }
}
