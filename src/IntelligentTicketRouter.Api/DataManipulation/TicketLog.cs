namespace IntelligentTicketRouter.Api.DataManipulation;


public class TicketLog
{
    public int Id { get; set; }
    public string CustomerEmail { get; set; } = string.Empty;
    public string OriginalMessage { get; set; } = string.Empty;
    public string AiAnalysisAndDraft { get; set; } = string.Empty;
    public DateTime ProcessedAt { get; set; }
}
