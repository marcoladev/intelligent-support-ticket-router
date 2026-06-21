using IntelligentTicketRouter.Api.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentTicketRouter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketOrchestrator _orchestrator;
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(TicketOrchestrator orchestrator, ILogger<TicketsController> logger)
        {
            _orchestrator = orchestrator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TicketResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProcessTicket([FromBody] TicketRequestDto request)
        {
            _logger.LogInformation("Processing incoming ticket for customer: {Email}", request.CustomerEmail);

            try
            {
                var aiResult = await _orchestrator.ProcessTicketAsync(request.CustomerEmail, request.Message);

                var response = new TicketResponseDto(aiResult, DateTime.UtcNow);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while orchestrating the AI ticket response.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }
    }
}