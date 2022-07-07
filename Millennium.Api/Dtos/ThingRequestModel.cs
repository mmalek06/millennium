using System.ComponentModel.DataAnnotations;

namespace Millennium.Api.Dtos;

public record ThingRequestModel(
    [Required] Guid Id,
    [Required][StringLength(512, MinimumLength = 3)] string Name,
    [Required] string Description);
