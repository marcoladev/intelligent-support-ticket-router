namespace IntelligentTicketRouter.Application.Tickets;

public record TicketResponse(
    string categoryCreated,
    DateTime ProcessedAt
);