using MatchEvent.Domain.Interfaces;
using MatchEvents.Domain.Dtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MatchEvent.Repository.Repositories
{
    public class MatchEventApiRestRepository : IMatchEventApiRestRepository
    {
        private readonly IConfiguration _configuration;

        public MatchEventApiRestRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<MatchEventInfo>> GetAcbMatchEventAsync(int gameId)
        {
            return await GetMatchEventInformationAsyncAsync(gameId);
        }

        public async Task<IEnumerable<MatchEventInfoExtended>> GetAcbMatchEventWithStatisticsAsync(int gameId)
        {
            return await GetMatchEventInformationWithStatisticsAsyncAsync(gameId);
        }

        /// <summary>
        /// Gets the JSON content of the API Rest call.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns></returns>
        private async Task<IEnumerable<MatchEventInfo>> GetMatchEventInformationAsyncAsync(int gameId)
        {
            var userJson = await GetStringAsync(_configuration.GetSection("ACBApiConfiguration:Endpoint").Value + "idMatch=" + gameId, _configuration.GetSection("ACBApiConfiguration:Token").Value);
            var user = JsonConvert.DeserializeObject<List<MatchEventInfo>>(userJson);
            return user;
        }

        /// <summary>
        /// Gets the JSON content of the API Rest call with player statistics.
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        private async Task<IEnumerable<MatchEventInfoExtended>> GetMatchEventInformationWithStatisticsAsyncAsync(int gameId)
        {
            var userJson = await GetStringAsync(_configuration.GetSection("ACBApiConfiguration:Endpoint").Value + "idMatch=" + gameId, _configuration.GetSection("ACBApiConfiguration:Token").Value);
            var user = JsonConvert.DeserializeObject<List<MatchEventInfoExtended>>(userJson);
            return user;
        }

        /// <summary>
        /// Method that getsnthe string content from API call reesponse.
        /// </summary>
        /// <param name="url">The ACB API rest url.</param>
        /// <param name="token">The bearer security token.</param>
        /// <returns></returns>
        private async static Task<string> GetStringAsync(string url, string token)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization
                             = new AuthenticationHeaderValue("Bearer", token);
                var response = await httpClient.GetStreamAsync(url);
                
                return await SerializeJsonResponse(response);
            }
        }

        /// <summary>
        /// Method that serializes the stream response from api call.
        /// </summary>
        /// <param name="responseData">The api call response.</param>
        /// <returns></returns>
        private async static Task<string> SerializeJsonResponse(Stream responseData)
        {
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(responseData))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                var data = serializer.Deserialize(jsonTextReader);
                return JsonConvert.SerializeObject(data, Formatting.Indented);
            }
        }
    }
}
