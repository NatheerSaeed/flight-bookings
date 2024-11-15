using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class PayLatersItemsExtensions
{
    public static PayLaters ToDto(this PayLatersDbModel model)
    {
        return new PayLaters
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

    public static PayLatersDbModel ToModel(
        this PayLaterUpdateInput updateDto,
        PayLatersWhereUniqueInput uniqueId
    )
    {
        var payLaters = new PayLatersDbModel
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
            payLaters.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            payLaters.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            payLaters.UserId = updateDto.User;
        }

        return payLaters;
    }
}
