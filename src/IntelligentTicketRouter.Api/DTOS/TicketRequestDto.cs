using System.ComponentModel.DataAnnotations;

namespace IntelligentTicketRouter.Api.DTOS;

public record TicketRequestDto(
    [Required][EmailAddress] string CustomerEmail,
    [Required][MinLength(10)] string Message
);