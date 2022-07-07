using Millennium.Api.Dtos;
using Millennium.Api.Models;

namespace Millennium.Api.Extensions;

public static class ThingRequestModelExtensions
{
    public static Thing ToModel(this ThingRequestModel dto) =>
        new Thing(dto.Id, dto.Name, dto.Description);
}
