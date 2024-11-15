using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class CarBookingsItemsExtensions
{
    public static CarBookings ToDto(this CarBookingsDbModel model)
    {
        return new CarBookings
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CarBookingsDbModel ToModel(
        this CarBookingsUpdateInput updateDto,
        CarBookingsWhereUniqueInput uniqueId
    )
    {
        var carBookings = new CarBookingsDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            carBookings.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            carBookings.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return carBookings;
    }
}
