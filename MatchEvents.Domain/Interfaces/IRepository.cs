using MatchEvents.Domain.Dtos;

namespace MatchEvents.Domain.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<MatchEventInfo>> GetMatchEventsAsync(int id);
        Task CreateMatchEventsAsync(int id, IEnumerable<MatchEventInfo> matchEvent);
    }
}
