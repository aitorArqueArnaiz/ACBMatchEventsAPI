using Microsoft.AspNetCore.Mvc;

namespace MatchEvent.Api.Controllers
{
    [ApiController]
    [Route("[acb-api/]")]
    public class MatchEventController : ControllerBase
    {

        private readonly ILogger<MatchEventController> _logger;

        public MatchEventController(ILogger<MatchEventController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "pbp-lean/{game_id}")]
        public async Task<IActionResult> GetPhpLeanAsync(int gameId)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("game-leaders/{game_id}")]
        public async Task<IActionResult> GetGameLeadersAsync(int gameId)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("ame-biggest_lead/{game_id}")]
        public async Task<IActionResult> GetGameBestLeaderAsync(int gameId)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
