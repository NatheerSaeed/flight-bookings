using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class AirlinesItemsExtensions
{
    public static Airlines ToDto(this AirlinesDbModel model)
    {
        return new Airlines
        {
            Amount = model.Amount,
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

    public static AirlinesDbModel ToModel(
        this AirlinesUpdateInput updateDto,
        AirlinesWhereUniqueInput uniqueId
    )
    {
        var airlines = new AirlinesDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            PaymentStatus = updateDto.PaymentStatus,
            Reference = updateDto.Reference,
            ResponseCode = updateDto.ResponseCode,
            ResponseDescription = updateDto.ResponseDescription,
            ResponseFull = updateDto.ResponseFull
        };

        if (updateDto.CreatedAt != null)
        {
            airlines.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            airlines.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            airlines.UserId = updateDto.User;
        }

        return airlines;
    }
}
