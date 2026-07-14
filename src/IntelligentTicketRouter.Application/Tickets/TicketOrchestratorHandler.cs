using IntelligentTicketRouter.Application.Interfaces;

namespace IntelligentTicketRouter.Application.Tickets;

public class TicketOrchestratorHandler
{
    private readonly IOllamaAiProcessor _ollamaAiProcessor;
    private readonly ITicketRepository _ticketRepository;

    public TicketOrchestratorHandler(IOllamaAiProcessor ollamaAiProcessor, ITicketRepository ticketRepository)
    {
        _ollamaAiProcessor = ollamaAiProcessor;
        _ticketRepository = ticketRepository;
    }

    public async Task<string> ProcessTicketAsync(string customerEmail, string ticketMessage)
    {
        var result = await _ollamaAiProcessor.ProcessSupportTicketAsync(customerEmail, ticketMessage);

        await _ticketRepository.AddTicketAsync(result); 

        return result.Category.ToString();
    }
}
