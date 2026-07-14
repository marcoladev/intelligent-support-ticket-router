using System.Text.Json;
using IntelligentTicketRouter.Application.Interfaces;
using IntelligentTicketRouter.Domain.Entities;
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

    public async Task<Ticket> ProcessSupportTicketAsync(string customerEmail, string ticketMessage)
    {
        var chat = _kernel
            .GetRequiredService<IChatCompletionService>();

        var history = new ChatHistory();

        history.AddSystemMessage("""
        You are a support ticket classifier. 
        You must respond ONLY with a JSON object matching this schema:
        {
        "customerEmail" : "customerEmail"
        "Category": 1|2|3,
        "Priority": 1|2|3,
        "Message": "shortExplanationOfTheTicket"
        }
        """);

        history.AddUserMessage($"Customer: {customerEmail}\n\nTicket:\n{ticketMessage}");

        var settings = new PromptExecutionSettings
        {
            ExtensionData = new Dictionary<string, object>
            {
                { "format", "json" }
            }
        };

        var response = await chat.GetChatMessageContentAsync(history, settings);

        return JsonSerializer.Deserialize<Ticket>(response.Content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });
    }
}