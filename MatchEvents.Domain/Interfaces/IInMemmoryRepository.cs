using MatchEvents.Domain.Dtos;

namespace MatchEvents.Domain.Interfaces
{
    public interface IInMemmoryRepository
    {
        /// <summary>
        /// gets the match event given a gameId.
        /// </summary>
        /// <param name="id">The game identifier.</param>
        /// <returns>The match event data.</returns>
        Task<IEnumerable<MatchEventInfo>> GetMatchEventsAsync(int id);

        /// <summary>
        /// Creates a new match event with key as the game identifier.
        /// </summary>
        /// <param name="id">The game identifier.</param>
        /// <param name="matchEvent">The match event information.</param>
        /// <returns></returns>
        Task CreateMatchEventsAsync(int id, IEnumerable<MatchEventInfo> matchEvent);
    }
}
