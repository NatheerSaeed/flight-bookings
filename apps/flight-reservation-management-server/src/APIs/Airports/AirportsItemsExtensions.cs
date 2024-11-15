using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class AirportsItemsExtensions
{
    public static Airports ToDto(this AirportsDbModel model)
    {
        return new Airports
        {
            Code = model.Code,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Name = model.Name,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AirportsDbModel ToModel(
        this AirportsUpdateInput updateDto,
        AirportsWhereUniqueInput uniqueId
    )
    {
        var airports = new AirportsDbModel
        {
            Id = uniqueId.Id,
            Code = updateDto.Code,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            airports.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            airports.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return airports;
    }
}
