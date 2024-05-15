using MatchEvents.Domain.Dtos;

namespace MatchEvents.Domain.Interfaces
{
    public interface IAcbMatchEventService
    {
        /// <summary>
        /// Method that reduces the information received from ACB API, gets the resume.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>The resume.</returns>
        Task<IEnumerable<MatchEventInfo>> GetPhpLeanAsync(int gameId);
        /// <summary>
        /// Method that calculates the game winner/leader of the match.
        /// </summary>
        /// <param name="gameId">The game idintifier.</param>
        /// <returns></returns>
        Task<IEnumerable<int>> GetGameLeadersAsync(int gameId);
        /// <summary>
        /// Method that calculates the biggest match winner.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>The biggest player of the match.</returns>
        Task<long> GetGameBiggestLeadAsync(int gameId);

    }
}
