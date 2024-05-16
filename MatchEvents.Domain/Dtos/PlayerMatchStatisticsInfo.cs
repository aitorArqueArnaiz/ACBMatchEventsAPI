using Newtonsoft.Json;

namespace MatchEvents.Domain.Dtos
{
    public class PlayerMatchStatisticsInfo
    {
        [JsonProperty("points")]
        public int Points { get; set; }
        [JsonProperty("total_rebound")]
        public int TotalRebound { get; set; }
    }
}
