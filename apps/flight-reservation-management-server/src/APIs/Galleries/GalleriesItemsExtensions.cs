using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class GalleriesItemsExtensions
{
    public static Galleries ToDto(this GalleriesDbModel model)
    {
        return new Galleries
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static GalleriesDbModel ToModel(
        this GalleriesUpdateInput updateDto,
        GalleriesWhereUniqueInput uniqueId
    )
    {
        var galleries = new GalleriesDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            galleries.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            galleries.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return galleries;
    }
}
