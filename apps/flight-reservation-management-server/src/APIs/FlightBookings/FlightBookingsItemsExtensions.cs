using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class FlightBookingsItemsExtensions
{
    public static FlightBookings ToDto(this FlightBookingsDbModel model)
    {
        return new FlightBookings
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static FlightBookingsDbModel ToModel(
        this FlightBookingsUpdateInput updateDto,
        FlightBookingsWhereUniqueInput uniqueId
    )
    {
        var flightBookings = new FlightBookingsDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            flightBookings.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            flightBookings.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return flightBookings;
    }
}
