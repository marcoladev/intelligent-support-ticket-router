using System.ComponentModel.DataAnnotations;

namespace IntelligentTicketRouter.Application.Tickets;

public record TicketCommand(
    [Required][EmailAddress] string CustomerEmail,
    [Required][MinLength(10)] string Message
);