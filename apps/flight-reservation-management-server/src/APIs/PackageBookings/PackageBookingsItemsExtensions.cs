using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class PackageBookingsItemsExtensions
{
    public static PackageBookings ToDto(this PackageBooking model)
    {
        return new PackageBookings
        {
            Adults = model.Adults,
            BookingStatus = model.BookingStatus,
            Children = model.Children,
            CreatedAt = model.CreatedAt,
            CustomerEmail = model.CustomerEmail,
            CustomerFirstName = model.CustomerFirstName,
            CustomerOtherName = model.CustomerOtherName,
            CustomerPhone = model.CustomerPhone,
            CustomerSurName = model.CustomerSurName,
            CustomerTitleId = model.CustomerTitleId,
            Id = model.Id,
            Infants = model.Infants,
            PackageField = model.PackageFieldId,
            PaymentStatus = model.PaymentStatus,
            Reference = model.Reference,
            TotalAmount = model.TotalAmount,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static PackageBooking ToModel(
        this PackageBookingUpdateInput updateDto,
        PackageBookingsWhereUniqueInput uniqueId
    )
    {
        var packageBookings = new PackageBooking
        {
            Id = uniqueId.Id,
            Adults = updateDto.Adults,
            BookingStatus = updateDto.BookingStatus,
            Children = updateDto.Children,
            CustomerEmail = updateDto.CustomerEmail,
            CustomerFirstName = updateDto.CustomerFirstName,
            CustomerOtherName = updateDto.CustomerOtherName,
            CustomerPhone = updateDto.CustomerPhone,
            CustomerSurName = updateDto.CustomerSurName,
            CustomerTitleId = updateDto.CustomerTitleId,
            Infants = updateDto.Infants,
            PaymentStatus = updateDto.PaymentStatus,
            Reference = updateDto.Reference,
            TotalAmount = updateDto.TotalAmount
        };

        if (updateDto.CreatedAt != null)
        {
            packageBookings.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.PackageField != null)
        {
            packageBookings.PackageFieldId = updateDto.PackageField;
        }
        if (updateDto.UpdatedAt != null)
        {
            packageBookings.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            packageBookings.UserId = updateDto.User;
        }

        return packageBookings;
    }
}
