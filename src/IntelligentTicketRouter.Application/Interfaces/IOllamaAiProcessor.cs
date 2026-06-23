namespace IntelligentTicketRouter.Application.Interfaces;

public interface IOllamaAiProcessor
{
    Task<string> ProcessSupportTicketAsync(string customerEmail, string ticketMessage);
}