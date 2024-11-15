using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class BankPaymentsItemsExtensions
{
    public static BankPayments ToDto(this BankPaymentsDbModel model)
    {
        return new BankPayments
        {
            Amount = model.Amount,
            BankDetailId = model.BankDetailId,
            BookingReference = model.BookingReference,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Reference = model.Reference,
            SlipPhoto = model.SlipPhoto,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static BankPaymentsDbModel ToModel(
        this BankPaymentUpdateInput updateDto,
        BankPaymentsWhereUniqueInput uniqueId
    )
    {
        var bankPayments = new BankPaymentsDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            BankDetailId = updateDto.BankDetailId,
            BookingReference = updateDto.BookingReference,
            Reference = updateDto.Reference,
            SlipPhoto = updateDto.SlipPhoto,
            Status = updateDto.Status
        };

        if (updateDto.CreatedAt != null)
        {
            bankPayments.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            bankPayments.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            bankPayments.UserId = updateDto.User;
        }

        return bankPayments;
    }
}
