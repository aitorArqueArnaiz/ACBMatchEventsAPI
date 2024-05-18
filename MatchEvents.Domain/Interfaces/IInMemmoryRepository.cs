using MatchEvents.Domain.Dtos;

namespace MatchEvents.Domain.Interfaces
{
    public interface IInMemmoryRepository
    {
        Task<IEnumerable<MatchEventInfo>> GetMatchEventsAsync(int id);
        Task CreateMatchEventsAsync(int id, IEnumerable<MatchEventInfo> matchEvent);
    }
}
