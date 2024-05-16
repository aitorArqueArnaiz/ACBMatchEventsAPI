using MatchEvent.Domain.Interfaces;
using MatchEvents.Domain.Dtos;
using MatchEvents.Domain.Interfaces;

namespace MatchEvents.Domain.Services
{
    public class AcbMatchEventService : IAcbMatchEventService
    {
        private const long HomeTeam = 2503;
        private const long AwayTeam = 2511;

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
            long pointsDifference = 0;
            var response = await _matchEventApiRestRepository.GetAcbMatchEventWithStatisticsAsync(gameId);
            foreach (var match in response) 
            {
                var matchDiference = Math.Abs(match.ScoreLocal - match.ScoreVisitor);
                if (pointsDifference < matchDiference)
                    pointsDifference = matchDiference;
            }
            return pointsDifference;
        }

        public async Task<(IEnumerable<long>, IEnumerable<long>)> GetGameLeadersAsync(int gameId)
        {
            var homeLeaders = new List<long>();
            var awayLeaders = new List<long>();
            var playerMatchInfoWithStatistics = await _matchEventApiRestRepository.GetAcbMatchEventWithStatisticsAsync(gameId);

            homeLeaders = playerMatchInfoWithStatistics.Where(x => x.Team != null && x.Statistics != null && x.License != null && x.Team.TeamId.Value == HomeTeam)
                .OrderByDescending(x => x.Statistics.Points)
                .OrderBy(x => x.Statistics.TotalRebound).Select(x => x.License.PlayerId).Distinct().ToList();

            awayLeaders = playerMatchInfoWithStatistics.Where(x => x.Team != null && x.Statistics != null && x.License != null && x.Team.TeamId.Value == AwayTeam)
                .OrderByDescending(x => x.Statistics.Points)
                .OrderBy(x => x.Statistics.TotalRebound).Select(x => x.License.PlayerId).Distinct().ToList();

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
