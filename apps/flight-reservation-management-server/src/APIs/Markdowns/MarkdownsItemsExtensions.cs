using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class MarkdownsItemsExtensions
{
    public static Markdowns ToDto(this MarkdownsDbModel model)
    {
        return new Markdowns
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static MarkdownsDbModel ToModel(
        this MarkdownsUpdateInput updateDto,
        MarkdownsWhereUniqueInput uniqueId
    )
    {
        var markdowns = new MarkdownsDbModel { Id = uniqueId.Id };

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
