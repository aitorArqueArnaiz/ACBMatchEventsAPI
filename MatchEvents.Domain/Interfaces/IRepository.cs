using MatchEvents.Domain.Dtos;

namespace MatchEvents.Domain.Interfaces
{
    public interface IRepository
    {
        Task<MatchEventInfo> GetMatchEventsAsync(int id);
        Task UpdateMatchEventsAsync(int id, MatchEventInfo matchEvent);
        Task<MatchEventInfo> CreateMatchEventsAsync(int id, MatchEventInfo matchEvent);
    }
}
