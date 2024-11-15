using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class MarkupsItemsExtensions
{
    public static Markups ToDto(this MarkupsDbModel model)
    {
        return new Markups
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static MarkupsDbModel ToModel(
        this MarkupsUpdateInput updateDto,
        MarkupsWhereUniqueInput uniqueId
    )
    {
        var markups = new MarkupsDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            markups.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            markups.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return markups;
    }
}
