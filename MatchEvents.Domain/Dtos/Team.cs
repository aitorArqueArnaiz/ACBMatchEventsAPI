
using Newtonsoft.Json;

namespace MatchEvents.Domain.Dtos
{
    public class Team
    {
        [JsonProperty("id_team_denomination")]
        public long? TeamId { get; set; }
    }
}
