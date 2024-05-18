using MatchEvents.Domain.Dtos;
using MatchEvents.Domain.Interfaces;

namespace MatchEvent.Repository.InMemmory
{
    public class InMemmoryRepository : IInMemmoryRepository
    {
        private readonly IDictionary<int, IEnumerable<MatchEventInfo>> _dbData = new Dictionary<int, IEnumerable<MatchEventInfo>>();

        public async Task CreateMatchEventsAsync(int id, IEnumerable<MatchEventInfo> matchEvent)
        {
            _dbData.Add(id, matchEvent);
        }

        public async Task<IEnumerable<MatchEventInfo>> GetMatchEventsAsync(int id)
        {
            if (_dbData.ContainsKey(id))
                return _dbData[id];

            return new List<MatchEventInfo>();
        }
    }
}
