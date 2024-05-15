using MatchEvent.Domain.Interfaces;
using MatchEvents.Domain.Dtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MatchEvent.Repository.Repositories
{
    public class MatchEventApiRestRepository : IMatchEventApiRestRepository
    {
        private const string BaseUrl = "https://api2.acb.com/api/v1/openapilive/PlayByPlay/matchevents?";
        private const string Token = "H4sIAAAAAAAAA32Ry3aqMBSG36iLi7qOw4oFk9PEQyohZEYilkCirIMF5OkbOmiVQUdZ+/bv798pbrAUkVR7BUEyAhcr0IIzWcoArEDdMBrA9VNxg5BPiQqp1wDGnEGTp/009MIZD4sd0dIsSxFMw7ATUaL2ulWxN7jZGV2poTegehuvrzKiTp7iRniL7zxhoZuzTZl5uhPKTTkD055Q+qTkkR6Pka4y9qNDTDjyu/hg6zxdVnkajq+UazmZ0Bstz7gT5j5HGhmtx4MPa9s/34dyxvUj41LL22OdMOxkqdXxSZN5d9r10BwNDS2v5Vh/zPg8ntD6W9OhwzHVvfDnPU033ZFHL495uinlmTTcsv/q5Yshmc+2GdNB8fXWs32wK3a4Ej7UMx8JT13LBy3LvUdsNXDDjf2P2X3YW6+EgQZUlwEf6gXeIgdvk4W9my52z2pfAReNcY8q1KPte4+CXtn/cub9p/jJef7j/Xvf/j150Sag6C1ctS41qVe3p6Fml5U4gf/xdecli8sn/TA0Eb8CAAA=";

        public async Task<MatchEventInfo> GetAcbMatchEventAsync(int gameId)
        {
            return await GetMatchEventInformationAsyncAsync(gameId);
        }

        private async Task<MatchEventInfo> GetMatchEventInformationAsyncAsync(int gameId)
        {
            var userJson = await GetStringAsync(BaseUrl + "idMatch=" + gameId, Token);
            var user = JsonConvert.DeserializeObject<MatchEventInfo>(userJson);
            return user;
        }

        private async Task<string> GetStringAsync(string url, string token)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization
                             = new AuthenticationHeaderValue("Bearer", token);
                var response = await httpClient.GetFromJsonAsync<string>(url);
                return response;
            }
        }
    }
}
