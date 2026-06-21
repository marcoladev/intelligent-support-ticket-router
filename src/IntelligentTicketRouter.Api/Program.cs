using IntelligentTicketRouter.Api;
using IntelligentTicketRouter.Api.DataManipulation;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "DefaultConnection missing");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)));

builder.Services.AddSingleton<Kernel>(sp =>
{
    var kernelBuilder = Kernel.CreateBuilder();

    kernelBuilder.AddOllamaChatCompletion(
        modelId: "llama3",
        endpoint: new Uri("http://localhost:11434"));


    return kernelBuilder.Build();
});

builder.Services.AddScoped<TicketOrchestrator>();
builder.Services.AddScoped<CustomerOrderPlugin>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = string.Empty;
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Intelligent Ticket Router API v1");
    });
}

app.MapControllers();

app.Run();