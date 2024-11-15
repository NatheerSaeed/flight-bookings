using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class AirlinesExtensions
{
    public static Airline ToDto(this AirlineDbModel model)
    {
        return new Airline
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AirlineDbModel ToModel(
        this AirlineUpdateInput updateDto,
        AirlineWhereUniqueInput uniqueId
    )
    {
        var airline = new AirlineDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            airline.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            airline.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return airline;
    }
}
