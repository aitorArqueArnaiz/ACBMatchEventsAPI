using MatchEvents.Domain.Dtos;
using MatchEvents.Domain.Interfaces;

namespace MatchEvents.Domain.Services
{
    public class AcbMatchEventService : IAcbMatchEventService
    {
        public Task<int> GetGameBiggestLeadAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<int>> GetGameLeadersAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<MatchEventInfo> GetPhpLeanAsync(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
