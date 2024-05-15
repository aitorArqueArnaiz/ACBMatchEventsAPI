using MatchEvents.Domain.Dtos;

namespace MatchEvents.Domain.Interfaces
{
    public interface IAcbMatchEventService
    {
        Task<MatchEventInfo> GetPhpLeanAsync(int gameId);
        Task<IEnumerable<int>> GetGameLeadersAsync(int gameId);
        Task<int> GetGameBiggestLeadAsync(int gameId);

    }
}
