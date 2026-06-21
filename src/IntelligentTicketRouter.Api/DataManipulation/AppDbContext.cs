
using Microsoft.EntityFrameworkCore;

namespace IntelligentTicketRouter.Api.DataManipulation;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<TicketLog> TicketLogs => Set<TicketLog>();
}