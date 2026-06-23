using IntelligentTicketRouter.Domain.Enums;

namespace IntelligentTicketRouter.Domain.Entities;

public class Ticket
{
    public Guid Id { get; private set; }
    public string CustomerEmail { get; private set; }
    public string Message { get; private set; }

    public TicketCategory? Category { get; private set; }
    public TicketPriority? Priority { get; private set; }
}