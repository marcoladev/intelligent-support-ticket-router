using IntelligentTicketRouter.Application.Interfaces;
using IntelligentTicketRouter.Domain.Entities;
using IntelligentTicketRouter.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IntelligentTicketRouter.Infrastructure.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public async Task<List<Ticket>> GetTicketListAsync()
    {
        var tickets =  await _context.Tickets.ToListAsync();

        return tickets;
    }

    public async Task<Ticket> GetTicketByIdAsync(Guid ticketId)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);

        return ticket;
    }

    public async Task AddTicketAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
    }
}