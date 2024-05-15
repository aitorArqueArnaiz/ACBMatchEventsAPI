using MatchEvent.Domain.Interfaces;
using MatchEvents.Domain.Dtos;
using Newtonsoft.Json;

namespace MatchEvent.Repository.Repositories
{
    public class MatchEventApiRestRepository : IMatchEventApiRestRepository
    {
        private const string BaseUrl  = "acb-api/pbp-lean/";
        public Task<MatchEventInfo> GetAcbMatchEventAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public async Task<MatchEventInfo> GetUserAsync(int userId)
        {
            var userJson = await GetStringAsync(BaseUrl + "users/" + userId);
            // Here I use Newtonsoft.Json to deserialize JSON string to User object
            var user = JsonConvert.DeserializeObject<MatchEventInfo>(userJson);
            return user;
        }

        private static Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return httpClient.GetStringAsync(url);
            }
        }
    }
}
