using IntelligentTicketRouter.Domain.Entities;

namespace IntelligentTicketRouter.Application.Interfaces;

public interface IOllamaAiProcessor
{
    Task<Ticket> ProcessSupportTicketAsync(string customerEmail, string ticketMessage);
}