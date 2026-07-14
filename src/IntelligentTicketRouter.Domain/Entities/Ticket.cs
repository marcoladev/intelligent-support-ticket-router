using IntelligentTicketRouter.Domain.Enums;

namespace IntelligentTicketRouter.Domain.Entities;

public class Ticket
{
    public Guid Id { get; private set; }    
    public string CustomerEmail { get; set; }
    public string Message { get; set; }

    public TicketCategory Category { get; set; }
    public TicketPriority Priority { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime processedAt { get; set; } = DateTime.MinValue;

    public Ticket(string customerEmail, string message, TicketCategory category, TicketPriority priority)
    {
        Id = Guid.NewGuid();
        CustomerEmail = customerEmail;
        Message = message;
        Category = category;
        Priority = priority;
        CreatedAt = DateTime.UtcNow;
    }
}