using MatchEvent.Domain.Interfaces;
using MatchEvents.Domain.Dtos;
using MatchEvents.Domain.Interfaces;

namespace MatchEvents.Domain.Services
{
    public class AcbMatchEventService : IAcbMatchEventService
    {
        private readonly IMatchEventApiRestRepository _matchEventApiRestRepository;
        private readonly IRepository _inMemmoryRepositoryCache;

        public AcbMatchEventService(
            IMatchEventApiRestRepository matchEventApiRestRepository,
            IRepository inMemmoryRepository)
        {
            _matchEventApiRestRepository = matchEventApiRestRepository;
            _inMemmoryRepositoryCache = inMemmoryRepository;
        }

        public async Task<long> GetGameBiggestLeadAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<int>> GetGameLeadersAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MatchEventInfo>> GetPhpLeanAsync(int gameId)
        {
            var existingInfo = await _inMemmoryRepositoryCache.GetMatchEventsAsync(gameId);
            if (existingInfo.Any())
            {
                return await _inMemmoryRepositoryCache.GetMatchEventsAsync(gameId);
            }
            else
            {
                var response = await _matchEventApiRestRepository.GetAcbMatchEventAsync(gameId);
                await _inMemmoryRepositoryCache.CreateMatchEventsAsync(gameId, response);
                return response;
            }
        }
    }
}
