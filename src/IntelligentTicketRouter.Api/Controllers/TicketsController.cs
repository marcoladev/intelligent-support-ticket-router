using IntelligentTicketRouter.Application.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentTicketRouter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketOrchestratorHandler _ticketHandler;
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(TicketOrchestratorHandler ticketHandler, ILogger<TicketsController> logger)
        {
            _ticketHandler = ticketHandler;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TicketCommand), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProcessTicket([FromBody] TicketCommand request)
        {
            _logger.LogInformation("Processing incoming ticket for customer: {Email}", request.CustomerEmail);

            try
            {
                var aiResult = await _ticketHandler.ProcessTicketAsync(request.CustomerEmail, request.Message);

                var response = new TicketResponse(aiResult, DateTime.UtcNow);
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