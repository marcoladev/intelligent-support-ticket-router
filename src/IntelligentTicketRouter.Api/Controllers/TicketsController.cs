using IntelligentTicketRouter.Application.Tickets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

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

                return Ok(new TicketResponse(aiResult, DateTime.UtcNow));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while orchestrating the AI ticket response.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTicketList()
        {
            try
            {
                var tickets = await _ticketHandler.GetTicketListAsync();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the ticket list.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }
    }
}