using IntelligentTicketRouter.Domain.Entities;

namespace IntelligentTicketRouter.Application.Interfaces;

public interface ITicketRepository
{
    Task<List<Ticket>> GetTicketListAsync();
    Task<Ticket> GetTicketByIdAsync(Guid ticketId);
    Task AddTicketAsync(Ticket ticket);
}