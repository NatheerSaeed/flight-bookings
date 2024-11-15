using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class PackageBookingsItemsExtensions
{
    public static PackageBookings ToDto(this PackageBookingsDbModel model)
    {
        return new PackageBookings
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PackageBookingsDbModel ToModel(
        this PackageBookingsUpdateInput updateDto,
        PackageBookingsWhereUniqueInput uniqueId
    )
    {
        var packageBookings = new PackageBookingsDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            packageBookings.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            packageBookings.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return packageBookings;
    }
}
