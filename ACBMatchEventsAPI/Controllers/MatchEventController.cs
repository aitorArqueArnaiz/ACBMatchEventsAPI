using MatchEvents.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MatchEvent.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchEventController : ControllerBase
    {

        private readonly ILogger<MatchEventController> _logger;
        private readonly IAcbMatchEventService _AAcbMatchEventService;

        public MatchEventController(
            ILogger<MatchEventController> logger,
            IAcbMatchEventService acbMatchEventService)
        {
            _logger = logger;
            _AAcbMatchEventService = acbMatchEventService;
        }

        [HttpGet]
        [Route("api-acb/pbp-lean/{game_id}")]
        public async Task<IActionResult> GetPhpLeanAsync(int gameId)
        {
            try
            {
                var response = await _AAcbMatchEventService.GetPhpLeanAsync(gameId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("api-acb/game-leaders/{game_id}")]
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

        [HttpGet]
        [Route("api-acb/game-biggest_lead/{game_id}")]
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
