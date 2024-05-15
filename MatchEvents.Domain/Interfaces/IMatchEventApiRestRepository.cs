using MatchEvents.Domain.Dtos;

namespace MatchEvent.Domain.Interfaces;

public interface IMatchEventApiRestRepository
{
    Task<MatchEventInfo> GetAcbMatchEventAsync(int matchId);
}