using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class CarBookingsItemsExtensions
{
    public static CarBookings ToDto(this CarBooking model)
    {
        return new CarBookings
        {
            Amount = model.Amount,
            BookingReference = model.BookingReference,
            CreatedAt = model.CreatedAt,
            DropoffDate = model.DropoffDate,
            DropoffLocation = model.DropoffLocation,
            Id = model.Id,
            PickupDate = model.PickupDate,
            PickupLocation = model.PickupLocation,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
            VehicleId = model.VehicleId,
        };
    }

    public static CarBooking ToModel(
        this CarBookingUpdateInput updateDto,
        CarBookingsWhereUniqueInput uniqueId
    )
    {
        var carBookings = new CarBooking
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            BookingReference = updateDto.BookingReference,
            DropoffDate = updateDto.DropoffDate,
            DropoffLocation = updateDto.DropoffLocation,
            PickupDate = updateDto.PickupDate,
            PickupLocation = updateDto.PickupLocation,
            VehicleId = updateDto.VehicleId
        };

        if (updateDto.CreatedAt != null)
        {
            carBookings.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            carBookings.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            carBookings.UserId = updateDto.User;
        }

        return carBookings;
    }
}
