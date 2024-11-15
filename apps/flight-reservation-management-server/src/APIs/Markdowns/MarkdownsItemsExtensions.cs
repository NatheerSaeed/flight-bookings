using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class MarkdownsItemsExtensions
{
    public static Markdowns ToDto(this MarkdownsDbModel model)
    {
        return new Markdowns
        {
            AirlineCode = model.AirlineCode,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            TypeField = model.TypeField,
            UpdatedAt = model.UpdatedAt,
            Value = model.Value,
        };
    }

    public static MarkdownsDbModel ToModel(
        this MarkdownUpdateInput updateDto,
        MarkdownsWhereUniqueInput uniqueId
    )
    {
        var markdowns = new MarkdownsDbModel
        {
            Id = uniqueId.Id,
            AirlineCode = updateDto.AirlineCode,
            TypeField = updateDto.TypeField,
            Value = updateDto.Value
        };

        if (updateDto.CreatedAt != null)
        {
            markdowns.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            markdowns.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return markdowns;
    }
}
