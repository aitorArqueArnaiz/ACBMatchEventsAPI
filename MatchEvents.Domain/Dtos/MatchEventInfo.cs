
namespace MatchEvents.Domain.Dtos
{
    public class MatchEventInfo
    {
        public long TeamId { get; set; }
        public long PlayerLicense { get; set; }
        public string ActionTime { get; set; }
        public int ActionType { get; set; }
    }
}
