
using IntelligentTicketRouter.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddApplicationServices(builder.Configuration);

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