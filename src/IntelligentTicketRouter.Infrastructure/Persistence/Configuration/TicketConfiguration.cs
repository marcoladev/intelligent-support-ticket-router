using Microsoft.EntityFrameworkCore;
using IntelligentTicketRouter.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentTicketRouter.Infrastructure.Persistence.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CustomerEmail)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Message)
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(x => x.Category)
        .HasMaxLength(20);

        builder.Property(x => x.Priority)
        .HasMaxLength(20);
    }
}