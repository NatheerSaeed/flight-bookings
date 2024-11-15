using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class GalleriesItemsExtensions
{
    public static Galleries ToDto(this Gallerie model)
    {
        return new Galleries
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            ImagePath = model.ImagePath,
            ImageTypeId = model.ImageTypeId,
            PackageField = model.PackageFieldId,
            ParentId = model.ParentId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static Gallerie ToModel(
        this GallerieUpdateInput updateDto,
        GalleriesWhereUniqueInput uniqueId
    )
    {
        var galleries = new Gallerie
        {
            Id = uniqueId.Id,
            ImagePath = updateDto.ImagePath,
            ImageTypeId = updateDto.ImageTypeId,
            ParentId = updateDto.ParentId
        };

        if (updateDto.CreatedAt != null)
        {
            galleries.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.PackageField != null)
        {
            galleries.PackageFieldId = updateDto.PackageField;
        }
        if (updateDto.UpdatedAt != null)
        {
            galleries.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return galleries;
    }
}
