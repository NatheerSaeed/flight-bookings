using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class SightSeeingsItemsExtensions
{
    public static SightSeeings ToDto(this SightSeeing model)
    {
        return new SightSeeings
        {
            Attraction = model.AttractionId,
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            PackageField = model.PackageFieldId,
            Title = model.Title,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static SightSeeing ToModel(
        this SightSeeingUpdateInput updateDto,
        SightSeeingsWhereUniqueInput uniqueId
    )
    {
        var sightSeeings = new SightSeeing
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            Title = updateDto.Title
        };

        if (updateDto.Attraction != null)
        {
            sightSeeings.AttractionId = updateDto.Attraction;
        }
        if (updateDto.CreatedAt != null)
        {
            sightSeeings.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.PackageField != null)
        {
            sightSeeings.PackageFieldId = updateDto.PackageField;
        }
        if (updateDto.UpdatedAt != null)
        {
            sightSeeings.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return sightSeeings;
    }
}
