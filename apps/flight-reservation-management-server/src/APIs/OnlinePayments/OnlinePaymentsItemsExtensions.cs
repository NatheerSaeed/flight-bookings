using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class OnlinePaymentsItemsExtensions
{
    public static OnlinePayments ToDto(this OnlinePaymentsDbModel model)
    {
        return new OnlinePayments
        {
            Amount = model.Amount,
            BookingReference = model.BookingReference,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            PaymentStatus = model.PaymentStatus,
            Reference = model.Reference,
            ResponseCode = model.ResponseCode,
            ResponseDescription = model.ResponseDescription,
            ResponseFull = model.ResponseFull,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static OnlinePaymentsDbModel ToModel(
        this OnlinePaymentUpdateInput updateDto,
        OnlinePaymentsWhereUniqueInput uniqueId
    )
    {
        var onlinePayments = new OnlinePaymentsDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            BookingReference = updateDto.BookingReference,
            PaymentStatus = updateDto.PaymentStatus,
            Reference = updateDto.Reference,
            ResponseCode = updateDto.ResponseCode,
            ResponseDescription = updateDto.ResponseDescription,
            ResponseFull = updateDto.ResponseFull
        };

        if (updateDto.CreatedAt != null)
        {
            onlinePayments.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            onlinePayments.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            onlinePayments.UserId = updateDto.User;
        }

        return onlinePayments;
    }
}
