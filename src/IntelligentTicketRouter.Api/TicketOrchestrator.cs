using IntelligentTicketRouter.Api.DataManipulation;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace IntelligentTicketRouter.Api;

public class TicketOrchestrator
{
    private readonly Kernel _kernel;
    private readonly AppDbContext _context;

    public TicketOrchestrator(
    AppDbContext context,
    CustomerOrderPlugin plugin,
    Kernel kernel)
    {
        _context = context;
        _kernel = kernel;
    }

    public async Task<string> ProcessTicketAsync(
        string customerEmail,
        string ticketMessage)
    {
        var chat = _kernel
            .GetRequiredService<IChatCompletionService>();

        var history = new ChatHistory();

        history.AddSystemMessage("""
        You are a support ticket classifier.
        Return:
        - category
        - priority
        - short explanation
        """);

        history.AddUserMessage($"""
        Customer: {customerEmail}

        Ticket:
        {ticketMessage}
        """);

        var response =
            await chat.GetChatMessageContentAsync(history);

        return response.Content ?? "";
    }
}