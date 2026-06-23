namespace IntelligentTicketRouter.Application.Tickets;

public record TicketResponse(
    string AnalysisAndDraft,
    DateTime ProcessedAt
);