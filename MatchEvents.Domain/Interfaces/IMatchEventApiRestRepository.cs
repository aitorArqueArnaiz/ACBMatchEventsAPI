using MatchEvents.Domain.Dtos;

namespace MatchEvent.Domain.Interfaces;

public interface IMatchEventApiRestRepository
{
    Task<IEnumerable<MatchEventInfo>> GetAcbMatchEventAsync(int gameId);
    Task<IEnumerable<MatchEventInfoExtended>> GetAcbMatchEventWithStatisticsAsync(int gameId);
}