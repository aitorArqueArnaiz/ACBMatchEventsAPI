using MatchEvents.Domain.Dtos;
using MatchEvents.Domain.Interfaces;

namespace MatchEvent.Repository.InMemmory
{
    public class InMemmoryRepository : IRepository
    {
        private readonly IDictionary<int, MatchEventInfo> _dbData = new Dictionary<int, MatchEventInfo>();

        public async Task<MatchEventInfo> CreateMatchEventsAsync(int id, MatchEventInfo matchEvent)
        {
            _dbData.Add(id, matchEvent);
            return matchEvent;
        }

        public async Task<MatchEventInfo> GetMatchEventsAsync(int id)
        {
            return _dbData[id];
        }

        public async Task UpdateMatchEventsAsync(int id, MatchEventInfo matchEvent)
        {
            _dbData[id] = matchEvent;
        }
    }
}
