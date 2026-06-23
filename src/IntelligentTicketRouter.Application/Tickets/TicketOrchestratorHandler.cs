using IntelligentTicketRouter.Application.Interfaces;

namespace IntelligentTicketRouter.Application.Tickets;

public class TicketOrchestratorHandler
{
    private readonly IOllamaAiProcessor _ollamaAiProcessor;

    public TicketOrchestratorHandler(IOllamaAiProcessor ollamaAiProcessor)
    {
        _ollamaAiProcessor = ollamaAiProcessor;
    }

    public async Task<string> ProcessTicketAsync(string customerEmail, string ticketMessage)
    {
        var result = await _ollamaAiProcessor.ProcessSupportTicketAsync(customerEmail, ticketMessage);

        return result;
    }
}
