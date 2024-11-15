using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class TravelLocationsExtensions
{
    public static TravelLocation ToDto(this TravelLocationDbModel model)
    {
        return new TravelLocation
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TravelLocationDbModel ToModel(
        this TravelLocationUpdateInput updateDto,
        TravelLocationWhereUniqueInput uniqueId
    )
    {
        var travelLocation = new TravelLocationDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            travelLocation.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            travelLocation.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return travelLocation;
    }
}
