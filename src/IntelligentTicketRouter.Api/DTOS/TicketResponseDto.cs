using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentTicketRouter.Api.DTOS;

public record TicketResponseDto(
    string AnalysisAndDraft,
    DateTime ProcessedAt
);