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

        public async Task<(IEnumerable<long>, IEnumerable<long>)> GetGameLeadersAsync(int gameId)
        {
            var homeLeaders = new List<long>();
            var awayLeaders = new List<long>();
            var playerMatchInfoWithStatistics = await _matchEventApiRestRepository.GetAcbMatchEventWithStatisticsAsync(gameId);

            homeLeaders = playerMatchInfoWithStatistics.Where(x => x.Team != null && x.Statistics != null && x.Team.TeamId.Value == 2503)
                .OrderByDescending(x => x.Statistics.Points)
                .OrderBy(x => x.Statistics.Points).Select(x => x.Team.TeamId.Value).Distinct().ToList();

            awayLeaders = playerMatchInfoWithStatistics.Where(x => x.Team != null && x.Statistics != null && x.Team.TeamId.Value == 2511)
                .OrderByDescending(x => x.Statistics.Points)
                .OrderBy(x => x.Statistics.Points).Select(x => x.Team.TeamId.Value).Distinct().ToList();

            return (homeLeaders, awayLeaders);
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
