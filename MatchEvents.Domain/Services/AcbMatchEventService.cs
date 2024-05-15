using MatchEvent.Domain.Interfaces;
using MatchEvents.Domain.Dtos;
using MatchEvents.Domain.Interfaces;

namespace MatchEvents.Domain.Services
{
    public class AcbMatchEventService : IAcbMatchEventService
    {
        private readonly IMatchEventApiRestRepository _matchEventApiRestRepository;

        public AcbMatchEventService(IMatchEventApiRestRepository matchEventApiRestRepository)
        {
            _matchEventApiRestRepository = matchEventApiRestRepository;
        }

        public async Task<long> GetGameBiggestLeadAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<int>> GetGameLeadersAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        public async Task<MatchEventInfo> GetPhpLeanAsync(int gameId)
        {
            var matches = await _matchEventApiRestRepository.GetAcbMatchEventAsync(gameId);
            return matches;
        }
    }
}
