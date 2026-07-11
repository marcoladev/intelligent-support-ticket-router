using IntelligentTicketRouter.Application.Interfaces;
using IntelligentTicketRouter.Application.Tickets;
using IntelligentTicketRouter.Infrastructure.AI;
using IntelligentTicketRouter.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;

namespace IntelligentTicketRouter.Api;

public static class Startup
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "DefaultConnection missing");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)));

        services.AddSingleton<Kernel>(sp =>
        {
            var kernelBuilder = Kernel.CreateBuilder();

            kernelBuilder.AddOllamaChatCompletion(
                modelId: "llama3",
                endpoint: new Uri("http://localhost:11434"));

            return kernelBuilder.Build();
        });

        services.AddScoped<TicketOrchestratorHandler>();
        services.AddScoped<IOllamaAiProcessor, OllamaAiProcessor>();

        return services;
    }

}