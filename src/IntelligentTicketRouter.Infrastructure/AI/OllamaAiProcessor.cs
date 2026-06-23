using IntelligentTicketRouter.Application.Interfaces;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace IntelligentTicketRouter.Infrastructure.AI;

public class OllamaAiProcessor : IOllamaAiProcessor
{
    private readonly Kernel _kernel;

    public OllamaAiProcessor(Kernel kernel)
    {
        _kernel = kernel;
    }

    public async Task<string> ProcessSupportTicketAsync(string customerEmail, string ticketMessage)
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

        var response = await chat.GetChatMessageContentAsync(history);

        return response.Content ?? "";
    }
}