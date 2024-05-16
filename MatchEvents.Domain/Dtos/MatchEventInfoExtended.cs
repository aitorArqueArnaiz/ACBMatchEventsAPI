using MatchEvents.Domain.Dtos.Player;
using Newtonsoft.Json;

namespace MatchEvents.Domain.Dtos
{
    public class MatchEventInfoExtended : MatchEventInfo
    {
        public PlayerMatchStatisticsInfo Statistics { get; set; }
        public License License { get; set; }
        [JsonProperty("score_local")]
        public long ScoreLocal { get; set; }
        [JsonProperty("score_visitor")]
        public long ScoreVisitor { get; set; }
    }
}
